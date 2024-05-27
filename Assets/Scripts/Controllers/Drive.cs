using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public WheelCollider[] WCs;
    public GameObject[] Wheels;

    public int sign = 1;
    public float torque = 200;
    public float maxSteerAngle = 20;
    public float maxBrakeTorque = 500;

    public Rigidbody rb;
    bool dragFlag;

    public AudioSource Audio;


    void Go(float accel, float steer, float brake, bool DragStopFlag)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
        brake = Mathf.Clamp(brake, 0, 1) * maxBrakeTorque;

        float thrustTorque = accel * torque;

        for (int i = 0; i < 4; i++)
        {
            //Drag can be used to slow down an object. The higher the drag the more the object slows down.
            if (DragStopFlag) 
            {
                rb.drag = 0;
                //apply thrustTorque to motor
                WCs[i].motorTorque = thrustTorque;

                //play sound
                if (Audio.isPlaying == false)
                {
                    Audio.Play();
                }
            }
            else
            {
                rb.drag = 2f;
                Audio.Stop();
            }

            Quaternion quat;
            Vector3 position;
            if (i < 2) //Front Wheels --> apply Steering
            {
                WCs[i].steerAngle = steer;
            }
            else  //Back Wheels --> apply brake
            {
                WCs[i].brakeTorque = brake;
            }

            //Get the Wheel collider position and Rotation, apply them to the wheel
            WCs[i].GetWorldPose(out position, out quat);
            Wheels[i].transform.position = position;
            Wheels[i].transform.rotation = quat;

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Get Axis Input
        float accelValue = sign * Input.GetAxis("Vertical");
        float steerValue = Input.GetAxis("Horizontal");
        float brakeValue = Input.GetAxis("Jump");

        //Check if there is no move --> accelValue == 0
        Debug.Log(accelValue);
        if (accelValue == 0)
        {
            dragFlag = false;
        }
        else
        {
            dragFlag = true;
        }

        //Call the car moving controlling function
        Go(accelValue, steerValue, brakeValue, dragFlag);
    }

}
