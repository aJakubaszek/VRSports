using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Basketball
{
    public class BasketballTimeMode : MonoBehaviour
    {
        public static UnityEvent OnGameEnded = new();
        public static UnityEvent OnGameStarted = new();

        [SerializeField] private int modeDurationInSeconds = 30;
        [SerializeField] private InputActionReference startGame;
        [SerializeField ] private TextMeshProUGUI timeLeftText;

        private float currentGameDuration;
        private bool gameIsStopped = true;

        private void Awake()
        {
            startGame.action.Enable();
        }

        private void OnEnable()
        {
            startGame.action.performed += StartCountDonw;
        }

        private void OnDisable()
        {
            startGame.action.performed -= StartCountDonw;
        }

        private void StartCountDonw(InputAction.CallbackContext context)
        {
            gameIsStopped = false;
            OnGameStarted.Invoke();
            currentGameDuration = modeDurationInSeconds;
        }

        private void Update()
        {
            if(gameIsStopped) return;

            CountDownTime();
        }

        private void CountDownTime()
        {
            currentGameDuration -= Time.deltaTime;

            if(currentGameDuration < 0)
            {
                StopGame();
                timeLeftText.SetText($"Czas: 0");
                return;
            }

            timeLeftText.SetText($"Czas: {(int)currentGameDuration}");
        }

        private void StopGame()
        {
            OnGameEnded.Invoke();
            gameIsStopped = true;
        }
    }
}