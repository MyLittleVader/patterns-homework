using System.Collections;
using UnityEngine;

namespace SecondTask
{
    public class BulletHole : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(DelayedDestroy());
        }
        
        private IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
    }
}