using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CameraController : MonoBehaviour
{

    public float MovementSpeed;
    public float MovementTime;

    public Vector3 NewPosition;
    public Vector3 NewZoom;
    public Vector3 DefaultZoom;
    public Vector3 ZoomAmount;



    public Transform Cameratransform;
    public Transform LeftWall;
    public Transform RighttWall;
    public Transform UpWall;
    public Transform DownWall;

    // Start is called before the first frame update
    void Start()
    {
        NewPosition = transform.position;
        NewZoom = Cameratransform.localPosition;
        DefaultZoom = NewZoom;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if(transform.position.z - UpWall.position.z <= -80)
            NewPosition += (transform.forward * MovementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if(transform.position.z - DownWall.position.z >= -50)
            NewPosition += (transform.forward * -MovementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x - RighttWall.position.x <= -50)
                NewPosition += (transform.right * MovementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x - LeftWall.position.x >= 50)
                NewPosition += (transform.right * -MovementSpeed);
        }

        transform.position = NewPosition;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) 
        {
            NewZoom += ZoomAmount;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) 
        {
            NewZoom -= ZoomAmount;
        }

        if (Cameratransform.localPosition.y < -45)
        {
            NewZoom = new Vector3(0, -40, 40);
        }
        else if (Cameratransform.localPosition.y > 5)
        {
            NewZoom = Vector3.zero;
        }

        Cameratransform.localPosition = Vector3.Lerp(Cameratransform.localPosition, NewZoom, Time.deltaTime * MovementTime);

        Debug.Log(Cameratransform.localPosition);

    }

}
