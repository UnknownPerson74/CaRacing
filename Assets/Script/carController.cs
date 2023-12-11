using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class carController : MonoBehaviour
{
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider backLeft;
    [SerializeField] WheelCollider backRight;

    [SerializeField] Transform FL;
    [SerializeField] Transform FR;
    [SerializeField] Transform BL;
    [SerializeField] Transform BR;

    public float acceralation = 500f;
    public float turnAngle = 15f;
    public float breakingForce = 1000f;

    

    private float currentAcceralation = 0f;
    private float currentBreakingForce = 0f;
    private float currentTurnAngle = 0f;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
       
        currentAcceralation = acceralation * Input.GetAxis("Vertical");
        

        currentTurnAngle = turnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        //frontLeft.motorTorque = currentAcceralation;
        //frontRight.motorTorque = currentAcceralation;
        backLeft.motorTorque = currentAcceralation;
        backRight.motorTorque = currentAcceralation;

        frontLeft.brakeTorque = currentBreakingForce;
        frontRight.brakeTorque= currentBreakingForce;
        backLeft.brakeTorque = currentBreakingForce;
        backRight.brakeTorque = currentBreakingForce;

        //Rotation of wheel on its axis
        FL.Rotate(frontLeft.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        FR.Rotate(frontRight.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        BL.Rotate(backLeft.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        BR.Rotate(backRight.rpm / 60 * 360 * Time.deltaTime, 0, 0);

        updateWheel(frontLeft, FL);
        updateWheel(backLeft, BL);
        updateWheel(frontRight, FR);
        updateWheel(backRight, BR);

        Applybreak();
       

    }
    void updateWheel(WheelCollider col, Transform trans)
    {
        //Get the wheelCollider state
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        //set wheel transform state
        trans.rotation = rotation;
        trans.position = position;
    }
    void Applybreak()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakingForce = breakingForce;
            
        }
        else
        {
            currentBreakingForce = 0;
        }
    }
    
}
