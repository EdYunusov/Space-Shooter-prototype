using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionPosition : MonoBehaviour
    {
        private bool m_Reached;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            SpaceShip ship = collision.transform.root.GetComponent<SpaceShip>();

            if (ship != null)
            {
                m_Reached = true;
                Debug.Log("Reached!");
                LevelSequenceController.Instance.FinishCurrentLevel(m_Reached);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            SpaceShip ship = collision.transform.root.GetComponent<SpaceShip>();

            if (ship != null)
            {
                m_Reached = false;
            }
        }
    }

}
