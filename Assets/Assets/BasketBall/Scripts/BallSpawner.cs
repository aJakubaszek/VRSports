using UnityEngine;
using UnityEngine.InputSystem;

namespace Basketball
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private InputActionReference spawnBallInput;
        private Vector3 startPosition;
        private Rigidbody rb;

        private void Awake()
        {
            startPosition = transform.position;
            rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            spawnBallInput.action.Enable();
            spawnBallInput.action.performed += SpawnBall;
        }

        private void OnDisable()
        {

            spawnBallInput.action.Disable();
            spawnBallInput.action.performed -= SpawnBall;
        }

        private void SpawnBall(InputAction.CallbackContext context)
        {
            transform.position = startPosition;
            rb.velocity = Vector3.zero;
        }
    }
}