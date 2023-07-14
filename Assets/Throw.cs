using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent.GetChild(0)==transform)
       gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, 5,0, ForceMode.Impulse);


        else
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(0,-5,0 , ForceMode.Impulse);
        }
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
