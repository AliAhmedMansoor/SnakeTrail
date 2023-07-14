using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SytheProjectileTrajectory : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
        transform.rotation = Quaternion.Euler((int)transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,speed * Time.deltaTime, 0, Space.Self);
    }
}
