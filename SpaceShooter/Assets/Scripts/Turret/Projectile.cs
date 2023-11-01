using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Projectile : Entity
    {
        [SerializeField] private float m_Velocity;
        [SerializeField] private float m_LifeTime;
        [SerializeField] private int m_Damage;
        [SerializeField] private ImpactEffect m_ImpactEffectPref;

        private float m_Timer;

        private void Update()
        {
            float stepLen = Time.deltaTime * m_Velocity;
            Vector2 step = transform.up * stepLen;
            m_Timer += Time.deltaTime;
            if (m_Timer > m_LifeTime) Destroy(gameObject);
            transform.position += new Vector3(step.x, step.y);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepLen);
            if(hit)
            {
                Destructible dest = hit.collider.transform.root.GetComponent<Destructible>();
                if (dest != null && dest != m_Parent)
                {
                    dest.ApplayDamage(m_Damage);

                    if (m_Parent == Player.Instance.ActiveShip)
                    {
                        Player.Instance.AddScore(dest.ScoreValue);
                    }
                }
                OnProjectileLifeTimeEnd(hit.collider, hit.point);
            }
        }

        private void OnProjectileLifeTimeEnd(Collider2D col, Vector2 pos)
        {
            Destroy(gameObject);
        }

        private Destructible m_Parent;

        public void SetParentShoot(Destructible parent)
        {
            m_Parent = parent;
        }
    }
}

