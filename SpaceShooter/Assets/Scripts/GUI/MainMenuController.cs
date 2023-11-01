using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class MainMenuController : SingletonBase<MainMenuController>
    {
        [SerializeField] private SpaceShip m_DefaultShip;
        [SerializeField] private GameObject m_EpisodeSelected;
        [SerializeField] private GameObject m_ShipSelected;
        [SerializeField] private GlobalResultPanel m_GlobalResultPanel;

        private void Start()
        {
            LevelSequenceController.PlayerShip = m_DefaultShip;
        }

        public void OnButtonStartNew()
        {
            m_EpisodeSelected.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        public void OnButtonGlobalStatistic()
        {
            m_GlobalResultPanel.gameObject.SetActive(true);
            m_GlobalResultPanel.ShowResult();
            gameObject.SetActive(false);
        }

        public void OnButtonSelectShip()
        {
            m_ShipSelected.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnButtonExit()
        {
            Application.Quit();
        }
    }

}
