using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    public class LevelConditionBossDefeted : MonoBehaviour
    {
        [SerializeField] private SpaceShip m_BossPrefab;


        private bool m_Reached;

        private void OnDestroy()
        {
            m_BossPrefab.EventOnDeath.AddListener(CallFinishedLevel);
        }

        private void CallFinishedLevel()
        {

            if (Player.Instance != null && Player.Instance.ActiveShip != null)
            {
                if (m_BossPrefab != null)
                {
                    Debug.Log("WIN");
                    m_Reached = true;
                    LevelSequenceController.Instance.FinishCurrentLevel(m_Reached);
                }
            }
            
        }
    }
}

