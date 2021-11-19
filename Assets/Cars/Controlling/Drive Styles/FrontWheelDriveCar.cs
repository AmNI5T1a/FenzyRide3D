using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{
    [RequireComponent(typeof(IWheelsVisualUpdate))]
    public class FrontWheelDriveCar : AccelerationType, IAccelerate, ISteering
    {
        [SerializeField] private FourWheelsCar _wheels;
        public override void Accelerate(in float motorTorque, in float verticalInput)
        {
            _wheels.frontLeftWheel._wheelCollider.motorTorque = motorTorque * verticalInput;
            _wheels.frontRightWheel._wheelCollider.motorTorque = motorTorque * verticalInput;
        }

        public void Steering(in float maxSteerAngle, in float currentHorizontalInput)
        {
            float currentSteeringAngle = maxSteerAngle * currentHorizontalInput;

            _wheels.frontLeftWheel._wheelCollider.steerAngle = currentSteeringAngle;
            _wheels.frontRightWheel._wheelCollider.steerAngle = currentSteeringAngle;
        }
    }
}