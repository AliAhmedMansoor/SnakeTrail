using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class DrawTrack : MonoBehaviour
{
    RoadMeshCreator roadMeshCreator;
    // Start is called before the first frame update
    void Start()
    {
        roadMeshCreator = GetComponent<RoadMeshCreator>();
        roadMeshCreator.AssignMeshComponents();

        roadMeshCreator.AssignMaterials();
        roadMeshCreator.CreateRoadMesh();

        roadMeshCreator.meshHolder.AddComponent(typeof(MeshCollider));
        roadMeshCreator.meshHolder.layer = 8;
        
        Destroy(roadMeshCreator.meshHolder, 200);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
