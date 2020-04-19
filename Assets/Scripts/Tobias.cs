using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tobias : MonoBehaviour
{

    //var startTime = float;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("NextAction", Random.Range(2f, 5f));
        Invoke("NextAction", Random.Range(5f, 10f));
    }

    public void NextAction()
	{
        GetComponent<Animator>().SetTrigger("NextAction");
	}


    public void ResetToInitialState()
    {
        GetComponent<Animator>().Rebind();
    }
}
