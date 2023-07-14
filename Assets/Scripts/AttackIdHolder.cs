using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackIdHolder : MonoBehaviour
{
    
    public static int AirAttackId;
    public static int DashAttackId;
    void Start()
    {
       
        AirAttackId= 0;
        DashAttackId = 0;
    }

    

    public  void AirAttackID()
    {
        if (AirAttackId == 0)
            AirAttackId = 1;
        else if(AirAttackId==1)
            AirAttackId = 0;
    }
    public  void DashAttackID()
    {
        if (DashAttackId == 0)
            DashAttackId = 1;
        else if(DashAttackId==1)
            DashAttackId = 0;
    }
}
