using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

    float Yaxis;
    [SerializeField]
    float Sensitivity;
    float MaxAngle;
    float CurrentRotation;
  
    public static float CurrentRotationX;
    // Start is called before the first frame update
    void Start()
    {

        Yaxis = 0;
     
        MaxAngle = 90f;
      
    }

    // Update is called once per frame
    void Update()
    {



        Yaxis = Input.GetAxis("Mouse Y");                              //mouse displacement on X
        CurrentRotation -= Yaxis * Time.deltaTime * Sensitivity;
        CurrentRotation = Mathf.Clamp(CurrentRotation, -MaxAngle, MaxAngle);
        transform.localRotation = Quaternion.Euler(CurrentRotation, 0, 0);

    }

}
