using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;



public class TrainMovement : MonoBehaviour
{
    public PathCreator CurrentPath;

    public static float speed;
    float MaxSpeed;
    float distanceTravelled;
    bool once;

    public TrackManager trackManager;
    public int buggyNumber;
    float MinDistanceFromNextBuggy;
    float DistanceFromNextBuggy;
    Vector3 offset;
   
    void Start()
    {
        MaxSpeed = 15;
        offset =  (-transform.right);
        MinDistanceFromNextBuggy = 4f;
        once = true;
        DistanceFromNextBuggy = MinDistanceFromNextBuggy * buggyNumber;
        distanceTravelled = MinDistanceFromNextBuggy * buggyNumber;
    }

    void Update()
    {

        speed += Time.deltaTime;
        speed = Mathf.Clamp(speed, 0, MaxSpeed);

        distanceTravelled += (speed * Time.deltaTime);
        
        transform.position = CurrentPath.path.GetPointAtDistance(distanceTravelled)+offset;
        transform.rotation = CurrentPath.path.GetRotationAtDistance(distanceTravelled);



    }

  


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "TrackSpawnTrigger" && once)
        {
           
            if (transform.parent.GetChild(0) == transform)
            {
                trackManager.SpawnNewTrack();
            }
            AssignNewPath();
            once = false;
     
            Invoke("met", 5);


        }
    }

    void AssignNewPath()
    {

        CurrentPath = trackManager.PreviousTrack.transform.GetChild(0).gameObject.GetComponent<PathCreator>();
        distanceTravelled = 0;
    }
    void met()
    {
        once = true;
    }

}
