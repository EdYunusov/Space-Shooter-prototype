using UnityEngine;

namespace SpaceShooter
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private TurretMode m_Mode;
        public TurretMode Mode => m_Mode;

        [SerializeField] private TurretProp m_TurretProperties;

        private float m_ReFireTime;

        public bool CanFire => m_ReFireTime <= 0;

        private SpaceShip m_Ship;
        

        private void Start()
        {
            m_Ship = transform.root.GetComponent<SpaceShip>();
        }

        private void Update()
        {
            if(m_ReFireTime > 0) m_ReFireTime -= Time.deltaTime;
        }

        public void Fire()
        {
            if (m_TurretProperties == null) return;

            if (m_ReFireTime > 0) return;

            if (m_Ship.DrawEnrgy(m_TurretProperties.EnergyUsage) == false) return;
            if (m_Ship.DrawAmmo(m_TurretProperties.AmmoUsage) == false) return;

            Projectile projectile = Instantiate(m_TurretProperties.ProjectilePref).GetComponent<Projectile>();
            projectile.transform.position = transform.position;
            projectile.transform.up = transform.up;
            projectile.SetParentShoot(m_Ship);

            m_ReFireTime = m_TurretProperties.RateOfFire;
        }

        public void AssignLoadout(TurretProp props)
        { 
            if(m_Mode != props.Mode) return;

            m_ReFireTime = 0;
            m_TurretProperties = props;
        }
    }
}

