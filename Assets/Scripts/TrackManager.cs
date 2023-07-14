using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class TrackManager : MonoBehaviour
{
   
    public GameObject[] Tracks;

    public GameObject track;
    public GameObject PreviousTrack;
   
    Vector3 endPointPos;
    Quaternion endPointRot;
    public GameObject snek;
    void Start()
    {
     


    }


    void Update()
    {


    }
    
    public void SpawnNewTrack()
    {

        PreviousTrack = track;
           int randomIndex = Random.Range(0, Tracks.Length);
            
        

      
        endPointPos= track.transform.GetChild(0).GetChild(0).position;
        endPointRot= track.transform.GetChild(0).GetChild(0).rotation;
       
        track=Instantiate(Tracks[randomIndex], endPointPos, endPointRot);
        SpawnSnek();

        
      
    }
   
    void SpawnSnek()
    {
        PathCreator Pc = track.transform.GetChild(0).gameObject.GetComponent<PathCreator>();

        float randomPoint = Random.Range(0,500);

        Vector3 snekPos = Pc.path.GetPointAtDistance(randomPoint);
        Quaternion rot= Pc.path.GetRotationAtDistance(randomPoint);

        Instantiate(snek, snekPos,rot);
        
    }
    //pathCreator.path.getPoint(t,condition);//Clamped between 0 and 1....//condition tell what to do at pathEnd i.e t=1
    

    //BezierPath bz= new BezierPAth(pointsArray,pathclosed==false,PathSpace);//Create a new bezier path

    // VertexPath v=VerterPath(bz);  Convert to Vertex path before before assigning
}
