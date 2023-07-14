using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public Animator anim;
    bool PrimMousePressDown;
    bool MousePressUp;
    bool AirMousePressDown;

    bool DashMousePressDown;

    public float PrimaryAttackRealeaseTime;
    float CurrentPrimaryAttackRealeaseTime;

  

    bool isGrounded;
    public float AirAttackRealeaseTime;
    float CurrentAirAttackRealeaseTime;
    public int DashCount;
    int CurrentDashCount;
    float speedY;
    bool DashAnimFin;
 
    // Start is called before the first frame update
    void Start()
    {
       
        DashAnimFin = true;
        CurrentDashCount = 0;
        CurrentAirAttackRealeaseTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = PlayerMover.isGrounded;
        PrimaryAttackHandelerer();
        StompAttackHandelerer();
        DashDetector();
    }
  
    void PrimaryAttackHandelerer()
    {
        //PrimaryAttack
        //PrimaryAttackRelease
        if (!PrimMousePressDown && isGrounded)
            PrimMousePressDown = Input.GetMouseButtonDown(0);
      
        if (PrimMousePressDown && isGrounded || CurrentPrimaryAttackRealeaseTime>0)
        {
            if (CurrentPrimaryAttackRealeaseTime == 0)
                anim.Play("Base Layer.PrimaryAttack", 0, 0);


            CurrentPrimaryAttackRealeaseTime += (Time.deltaTime);
            MousePressUp = Input.GetMouseButtonUp(0);

            if(MousePressUp || CurrentPrimaryAttackRealeaseTime >= PrimaryAttackRealeaseTime)
            {
                PrimMousePressDown = false;
                CurrentPrimaryAttackRealeaseTime = -1;
               
            }
        }
        else
        {

            if (CurrentPrimaryAttackRealeaseTime != 0)
            {
                anim.Play("Base Layer.PrimaryAttackRelease", 0, 0);
                CurrentPrimaryAttackRealeaseTime = 0;

               

            }
        }



    }

    void StompAttackHandelerer()
    {
        //InAirAttack
        //InAirAttackRelease
       
        if (!isGrounded && !AirMousePressDown && PlayerMover.crochDetect && (int)PlayerMover.ChangeOnZ==0)
           AirMousePressDown = Input.GetMouseButtonDown(0);


        if (AirMousePressDown)
        {
          
            if (CurrentAirAttackRealeaseTime == 0)
                anim.Play("Base Layer.InAirAttack", 0, 0);

            CurrentAirAttackRealeaseTime += Time.deltaTime;
            MousePressUp = Input.GetMouseButtonUp(0);

            if (MousePressUp || CurrentAirAttackRealeaseTime >= AirAttackRealeaseTime)
            {
                AirMousePressDown = false;

            }
        }
        else
        {
            if (CurrentAirAttackRealeaseTime != 0)
            {
                anim.Play("Base Layer.InAirAttackRelease", 0, 0);
                CurrentAirAttackRealeaseTime = 0;
            }
        }
    }
    void DashDetector()
    {
        if (isGrounded)
        {
            if (CurrentDashCount != 0)
            {
                CurrentDashCount = 0;
            }
        }

        
              
                DashMousePressDown = Input.GetMouseButtonDown(0);
       
       

        if (DashMousePressDown && DashAnimFin && PlayerMover.ChangeOnZ > 0 && !PlayerMover.crochDetect)
        {
            DashAnimFin = false;
            anim.Play("Base Layer.DashAnimation",0,0);
         
        }
       
        
    }

    void UltraSpeedHandelerer()
    {
        if (CurrentDashCount != DashCount)
        {
            speedY = PlayerMover.speedY;
            PlayerMover.isDashing = true;

            PlayerMover.speedY = 50;
        }
    }
    void BackToNormalSpeed()
    {
        if (CurrentDashCount != DashCount)
        {
            PlayerMover.speedY = 10;
            PlayerMover.isDashing = false;
            CurrentDashCount++;
            DashAnimFin = true;
            PlayerMover.downwardVel = 0;


        }
        else
        {
            DashAnimFin = true;
        }
    }

}