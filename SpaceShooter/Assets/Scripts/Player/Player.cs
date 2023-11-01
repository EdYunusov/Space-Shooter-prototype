using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    public class Player : SingletonBase<Player>
    {
        [SerializeField] private int m_HP;
        [SerializeField] private SpaceShip m_Ship;
        [SerializeField] private GameObject m_PlayerShipPrefab;
        [SerializeField] private CameraController m_CameraController;
        [SerializeField] private MovementController m_MovementController;

        public SpaceShip ActiveShip => m_Ship;

        protected override void Awake()
        {
            base.Awake();

            if (m_Ship != null) Destroy(m_Ship.gameObject);

        }

        private void Start()
        {
            Respawn();
        }

        private void OnShopDeath()
        {
            m_HP--;

            if (m_HP > 0)
            {
                Respawn();
            }
            else
            {
                LevelSequenceController.Instance.FinishCurrentLevel(false);
            }
        }

        private void Respawn()
        {
            if (LevelSequenceController.PlayerShip != null)
            {
                var newPlayerShip = Instantiate(LevelSequenceController.PlayerShip);

                m_Ship = newPlayerShip.GetComponent<SpaceShip>();

                m_CameraController.SetTarget(m_Ship.transform);
                m_MovementController.SetTargetShip(m_Ship);

                m_Ship.EventOnDeath.AddListener(OnShopDeath);
            }
        }

        #region Score

        public int Score { get; private set; }

        public int NumKill { get; private set; }

        public void AddKil()
        {
            NumKill++;
        }

        public void AddScore(int num)
        {
            Score += num;
        }
        #endregion
    }
}

