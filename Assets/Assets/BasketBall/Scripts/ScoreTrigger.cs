using System;
using UnityEngine;

namespace Basketball
{
    public class ScoreTrigger : MonoBehaviour
    {
        [SerializeField] private float scoreCooldown = 1f;
        private float lastTimeBallScores;

        private void OnTriggerEnter(Collider other)
        {
            if (lastTimeBallScores > lastTimeBallScores + scoreCooldown) return;

            if(other.TryGetComponent<Ball>(out var _))
            {
                lastTimeBallScores = Time.time;
                ScoreCounter.OnScore.Invoke();
            }
        }
    }
}