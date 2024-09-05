using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealthTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AddHealthTrigger");
    }
}
