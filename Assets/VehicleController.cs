using UnityEngine;

public class VehicleController : MonoBehaviour
{
    // Wheel Colliders
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    // Wheel Transforms
    public Transform frontLeftTransform;
    public Transform frontRightTransform;
    public Transform rearLeftTransform;
    public Transform rearRightTransform;

    // Control parameters
    public float maxMotorTorque = 1500f; // Maximum torque the motor can apply to wheel
    public float maxSteeringAngle = 30f; // Maximum steering angle the wheel can have

    void FixedUpdate()
    {
        // Get input from user
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        // Apply steering to front wheels
        frontLeftWheel.steerAngle = steering;
        frontRightWheel.steerAngle = steering;

        // Apply motor torque to rear wheels
        rearLeftWheel.motorTorque = motor;
        rearRightWheel.motorTorque = motor;

        // Apply brake
        if (Input.GetKey(KeyCode.Space))
        {
            rearLeftWheel.brakeTorque = maxMotorTorque;
            rearRightWheel.brakeTorque = maxMotorTorque;
        }
        else
        {
            rearLeftWheel.brakeTorque = 0;
            rearRightWheel.brakeTorque = 0;
        }

        // Update wheel positions based on physics
        UpdateWheelPosition(frontLeftWheel, frontLeftTransform);
        UpdateWheelPosition(frontRightWheel, frontRightTransform);
        UpdateWheelPosition(rearLeftWheel, rearLeftTransform);
        UpdateWheelPosition(rearRightWheel, rearRightTransform);
    }

    void UpdateWheelPosition(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        transform.position = position;
        transform.rotation = rotation;
    }
}

