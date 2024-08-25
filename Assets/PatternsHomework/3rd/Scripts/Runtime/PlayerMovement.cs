using UnityEngine;

namespace ThirdTask
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0f, 10f)] private float _speed = 5f;
        
        public void Move(Vector2 input)
        {
            Vector3 direction = new Vector3(input.x, 0f, input.y).normalized;
            
            transform.Translate(direction * _speed * Time.deltaTime);
        }
    }
}