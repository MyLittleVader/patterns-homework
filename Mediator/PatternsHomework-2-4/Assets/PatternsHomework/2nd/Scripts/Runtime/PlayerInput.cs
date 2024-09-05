using UnityEngine;
using UnityEngine.Events;

namespace SecondTask
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Vector2> onInputDirection;

        private void Update()
        {
            Vector2 direction = Vector2.zero;

            if (Input.GetKey(KeyCode.W))
            {
                direction += Vector2.up;
            }

            if (Input.GetKey(KeyCode.A))
            {
                direction += Vector2.left;
            }

            if (Input.GetKey(KeyCode.S))
            {
                direction += Vector2.down;
            }

            if (Input.GetKey(KeyCode.D))
            {
                direction += Vector2.right;
            }

            onInputDirection?.Invoke(direction);
        }
    }
}