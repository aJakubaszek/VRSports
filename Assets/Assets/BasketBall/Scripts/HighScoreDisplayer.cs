using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Basketball
{
    public class HighScoreDisplayer : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> scoresTexts;

        private void Awake()
        {
            var scores = FileSystem.LoadPlayerData().scores;

            RefreshHighScoreList(scores);
        }

        private void OnEnable()
        {
            ScoreCounter.OnHighscoresRefresh.AddListener(RefreshHighScoreList);
        }

        private void RefreshHighScoreList(List<int> scores)
        {
            var sortedScores = scores.OrderByDescending(x => x).ToList();

            for (int i = 0; i < scoresTexts.Count; i++)
            {
                TextMeshProUGUI scoreText = scoresTexts[i];

                if (i >= sortedScores.Count)
                {
                    scoreText.gameObject.SetActive(false);
                }

                else
                {
                    scoreText.gameObject.SetActive(true);
                    scoreText.SetText(sortedScores[i].ToString());
                }
            }
        }
    }
}