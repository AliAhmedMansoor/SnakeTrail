using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public AttackIdHolder AttackID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Finish")
        {
            if(col.gameObject.transform.parent==null)
            {
                Debug.Log("Ha Prim Attack");
                Destroy(col.gameObject);
              
            }
            else if (AttackIdHolder.AirAttackId==1)
            {
                Debug.Log("Ha Air Attack");
            }
            else if(AttackIdHolder.DashAttackId==1)
            {
                Debug.Log("Ha Dash Attack");
            }
         


        }
    }
}
