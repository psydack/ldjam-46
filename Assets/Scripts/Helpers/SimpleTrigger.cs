using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTrigger : MonoBehaviour
{

    public UnityEvent onTriggerEnterTobiasTag;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tobias"))
        {
            onTriggerEnterTobiasTag.Invoke();
        }
    }
}
