using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAttackReaction : MonoBehaviour
{
    public GameObject SnekCut;
    bool once;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        if(col.tag=="Finish")
        {
            
            if (AttackIdHolder.AirAttackId == 1)
            {

                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                PlayerMover.downwardVel = 20;
                PlayerMover.AllowedToJump = true;
                Instantiate(SnekCut, transform.position, transform.rotation);
                BloodPSRefHolder.Ps.position = transform.position;
                BloodPSRefHolder.Ps.gameObject.GetComponent<ParticleSystem>().Play();
                SnekCut.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 100000, ForceMode.Impulse);
                SnekCut.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, 0, -100000, ForceMode.Impulse);
                Destroy(gameObject);

            }

            else if (AttackIdHolder.DashAttackId == 1)
            {

                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                ManaHandeler.UpdateMana = true;
                Instantiate(SnekCut, transform.position, transform.rotation);
                BloodPSRefHolder.Ps.position = transform.position;
                BloodPSRefHolder.Ps.gameObject.GetComponent<ParticleSystem>().Play();
               
                Destroy(gameObject);

            }

          
        }
    }
}
