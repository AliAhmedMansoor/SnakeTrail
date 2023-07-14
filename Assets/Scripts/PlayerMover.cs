using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    CharacterController controller;
   
    
   
  
    public int Gravity;
    public static bool isGrounded;
   
    [SerializeField]
    Transform GroundChecker;
    public float radiusOfSphereCheck;
    [SerializeField]
    LayerMask GroundlayerMask;
    bool PressSpace;

    public Transform cam;
  
    float ChangeOnX;
    public static float ChangeOnZ;
   
    public float temp;
    bool isMoving;

    bool ShiftPressDown;
    public static  bool AllowedToJump;
    Collider[] col;


    public float InAirXSpeed;
    public float height;
    public static float downwardVel;
    Vector3 Move;
    public float SprintSpeed;
    public float speedX;
    public static float speedY;
    public float SlideVel;
    public float SlideAcceleration;
    float CurrentSldeVel;
    public static bool isDashing;



    public static bool leftCtrlPress;
    public static bool crochDetect;
    Collider[] coll;
    void Start()
    {
 
        CurrentSldeVel = SlideVel;
        AllowedToJump =false;
        controller = gameObject.GetComponent<CharacterController>();
        Move = new Vector3(0, 0, 0);
        leftCtrlPress = false;

    }
    void Update()
    {
        

       isGrounded = Physics.CheckSphere(GroundChecker.position, radiusOfSphereCheck, GroundlayerMask);
        //on Ground Check
         coll = Physics.OverlapSphere(GroundChecker.position, radiusOfSphereCheck, GroundlayerMask);
      
        foreach (Collider c in coll)
        {
            if (c.gameObject.tag == "Ground")
            {
                if (c.gameObject.transform.parent.parent != transform.parent)
                {
                    transform.parent = c.gameObject.transform.parent.parent;
                
                    break;
                }
                
            }
           
        }
      

        PressSpace = Input.GetButtonDown("Jump");
        //Get Input

        if (PressSpace && isGrounded)
        {

           
            downwardVel = Mathf.Sqrt(-2 * Gravity * height);
            AllowedToJump = true;
        }
        else if(!isGrounded)
        {

            if(!AllowedToJump)
            AllowedToJump = true;
        }

       

        if (AllowedToJump)
        {
            if(transform.parent!=null)
            transform.parent = null;
           

            downwardVel += (Gravity * Time.deltaTime);
            controller.Move(downwardVel * transform.up * Time.deltaTime);
           
            if (downwardVel<=0 && isGrounded)
            {
               
                AllowedToJump = false;
                downwardVel = 0;
                
              
            }    
        }
        //Jumping mechanics 



        GetChangeOnXZ();
        if (!isDashing)
        {
          Move = (ChangeOnX * transform.right * speedX) + (ChangeOnZ * transform.forward * speedY);
          
        }
        else
        {
            Move = (ChangeOnX * transform.right * speedX) + (ChangeOnZ * cam.forward * speedY);

        }
        controller.Move(Move * Time.deltaTime);

        PowerSlide();
        SprintCheck();
        
        crochChecker();
        
    
    }

    void SprintCheck()
    {

        ShiftPressDown = Input.GetKeyDown(KeyCode.LeftShift);
        if(ShiftPressDown && isGrounded)
        {
            if(speedY==10)
            {
                speedY = 5;
            }
            else
            {
                speedY = 10;
            }
            
        }
   
    }
    void PowerSlide()
    {
        if (speedY ==10 || leftCtrlPress)
        {
           

            leftCtrlPress = Input.GetKey(KeyCode.LeftControl);
            if (leftCtrlPress)
            {

                speedY = CurrentSldeVel;
                transform.localScale = new Vector3(0.25f, 0.1f, 0.25f);
                if (isGrounded)
                {
                    CurrentSldeVel += (SlideAcceleration * Time.deltaTime);
                   
                }
                if (CurrentSldeVel <= 0)
                {
                    CurrentSldeVel = 0;

                }
            }

        }
        else if (CurrentSldeVel != SlideVel && isGrounded)
        {
            if (speedY >= 8)
                speedY = 10;
            else
                speedY = 5;

            CurrentSldeVel = SlideVel;
           
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
       
    }
    void GetChangeOnXZ()
    {
        ChangeOnX = Input.GetAxis("Horizontal");
        ChangeOnZ = Input.GetAxis("Vertical");
        if(ChangeOnZ!=1)
        {
            speedY = 5;
        }
      
    }
    public void ForceDueToRope(float CurrentDistance,float MaxDistance)
    {
        controller.Move(downwardVel * transform.up * Time.deltaTime);
    }

    void crochChecker()
    {
        crochDetect = Input.GetKey(KeyCode.LeftControl);
        if (crochDetect && transform.localScale.y != 0.1f)
        {

            transform.localScale = new Vector3(0.25f, 0.1f, 0.25f);
        }
        else if(transform.localScale.y != 0.25f  && !crochDetect)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
    }
}
