using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Variable for refernece other object
    public static CameraController instance;

    //Variable for camera move speed
    public float moveSpeed;

    //Variable for moving camera to other room
    public Transform target;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //For moving the camera
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), moveSpeed * Time.deltaTime);
        }
    }


    //For changing the target
    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
