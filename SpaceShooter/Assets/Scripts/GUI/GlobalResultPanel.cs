using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class GlobalResultPanel : MonoBehaviour
    {
        [SerializeField] private Text m_Kills;
        [SerializeField] private Text m_Score;
        [SerializeField] private Text m_Time;
        [SerializeField] private GameObject m_MainPanel;

        private void Start()
        {
            gameObject.SetActive(true);
        }

        public void ShowResult()
        {
            //Подсчет очков

            m_Kills.text = "Kills: " + PlayerPrefs.GetInt("MaxKills");
            m_Score.text = "Score: " + PlayerPrefs.GetInt("MaxScores");
            m_Time.text = "Time: " + PlayerPrefs.GetInt("MaxTime");
        }

        public void OnButtonBack()
        {
            m_MainPanel.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

