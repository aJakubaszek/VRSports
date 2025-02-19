using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Basketball
{
    public class ScoreCounter : MonoBehaviour
    {
        public static UnityEvent OnScore = new();
        public static UnityEvent<List<int>> OnHighscoresRefresh = new();

        [SerializeField] private TextMeshProUGUI scoreText;
        private int points;
        private int maxScores = 10;

        private void OnEnable()
        {
            OnScore.AddListener(AddPoint);
            BasketballTimeMode.OnGameStarted.AddListener(ResetScore);
            BasketballTimeMode.OnGameEnded.AddListener(SaveScore);
        }

        private void OnDisable()
        {
            OnScore.RemoveListener(AddPoint);
            BasketballTimeMode.OnGameStarted.RemoveListener(ResetScore);
            BasketballTimeMode.OnGameEnded.RemoveListener(SaveScore);
        }

        private void ResetScore()
        {
            points = 0;
            scoreText.SetText(points.ToString());
        }

        private void SaveScore()
        {
            var data = FileSystem.LoadPlayerData();

            if (data.scores.Count > maxScores)
            {
                var lowestScoreIndex = FindLowestScoreIndex(data);

                if(lowestScoreIndex != -1)
                {
                    data.scores.RemoveAt(lowestScoreIndex);
                }

                data.scores.Add(points);
            }

            else
            {
                data.scores.Add(points);
            }

            OnHighscoresRefresh.Invoke(data.scores);
            //FileSystem.Save(data);
        }

        private int FindLowestScoreIndex(PlayerData data)
        {
            var lowestScore = Mathf.Infinity;
            var lowestScoreIndex = -1;

            foreach (var score in data.scores)
            {
                if (score < lowestScore && score < points)
                {
                    lowestScoreIndex = data.scores.IndexOf(score);
                }
            }

            return lowestScoreIndex;
        }

        private void AddPoint()
        {
            points++;
            scoreText.SetText(points.ToString());
        }
    }
}