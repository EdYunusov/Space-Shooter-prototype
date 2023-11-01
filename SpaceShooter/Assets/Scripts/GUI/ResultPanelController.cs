using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class ResultPanelController : SingletonBase<ResultPanelController>
    {
        [SerializeField] private Text m_Kills;
        [SerializeField] private Text m_Score;
        [SerializeField] private Text m_Time;
        [SerializeField] private Text m_Result;
        [SerializeField] private Text m_ButtonNextText;

        private bool m_Success;
        public int m_AllScore;
        public int m_AllKills;
        public int m_AllTime;

        public int AllScores => m_AllScore;

        public int AllKills => m_AllKills;
        public int AllTime => m_AllTime;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void ShowResult(PlayerStatistics levelResults, bool success)
        {
            
            gameObject.SetActive(true);

            //Подсчет очков

            m_Kills.text = "Kills: " + levelResults.kills.ToString();
            m_Score.text = "Score: " + levelResults.score.ToString();
            m_Time.text = "Time: " + levelResults.time.ToString();

            m_AllScore += levelResults.score;
            m_AllKills += levelResults.kills;
            m_AllTime += levelResults.time;

            m_Success = success;

            m_Result.text = success ? "Win" : "Lose";

            m_ButtonNextText.text = success ? "Next" : "Restart";

            SaveAllScores();

            Time.timeScale = 0;
        }

        public void OnButtonNextAction()
        {
            gameObject.SetActive(false);

            Time.timeScale = 1;

            if(m_Success)
            {
                LevelSequenceController.Instance.AvanceLevel();
            }
            else
            {
                LevelSequenceController.Instance.RestartLevel();
            }
        }

        public void SaveAllScores()
        {
            PlayerPrefs.SetInt("MaxScores", m_AllScore);
            PlayerPrefs.SetInt("MaxKills", m_AllKills);
            PlayerPrefs.SetInt("MaxTime", m_AllTime);
        }

        public void LoadAllScores()
        {
            m_AllScore = PlayerPrefs.GetInt("MaxScores", 0);
            m_AllKills = PlayerPrefs.GetInt("MaxKills", 0);
            m_AllTime = PlayerPrefs.GetInt("MaxTime", 0);
        }
    }
}

