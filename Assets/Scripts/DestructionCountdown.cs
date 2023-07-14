using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionCountdown : MonoBehaviour
{
    int time = 200;
    // Start is called before the first frame update
    void Awake()
    {
        
        Destroy(transform.parent.gameObject, time);
     
    }

    // Update is called once per frame
    void Update()
    {

    }
}
