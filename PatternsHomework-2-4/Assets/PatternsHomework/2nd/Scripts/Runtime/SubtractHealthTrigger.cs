using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtractHealthTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("SubtractHealthTrigger");
    }
}
