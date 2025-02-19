using UnityEngine;

namespace Basketball
{
    public class ParticleEnabler : MonoBehaviour
    {
        [SerializeField] private ParticleSystem scoreParticles;

        private void OnEnable()
        {
            ScoreCounter.OnScore.AddListener(PlayParticles);
        }

        private void OnDisable()
        {
            ScoreCounter.OnScore.RemoveListener(PlayParticles);
        }

        private void PlayParticles()
        {
            scoreParticles.Play();
        }
    }
}