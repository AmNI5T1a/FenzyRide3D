using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{
    [RequireComponent(typeof(IWheelsVisualUpdate))]
    public class FrontWheelDriveCar : AccelerationType, IAccelerate, ISteering, IBreaking
    {
        private WheelCollider[] _wheelColliders;
        private Transform[] _wheelTransforms;
        private void Awake()
        {
            this._wheelColliders = this.gameObject.GetComponent<CarControlling>()._wheelColliders;
            this._wheelTransforms = this.gameObject.GetComponent<CarControlling>()._wheelTransforms;
        }
        public override void Accelerate(in float motorTorque, in float verticalInput, in GearBox gearBox)
        {
            _wheelColliders[0].motorTorque = (motorTorque / 4) * verticalInput * gearBox.GetCurrentGear().Ratio;
            _wheelColliders[1].motorTorque = (motorTorque / 4) * verticalInput * gearBox.GetCurrentGear().Ratio;
        }

        public void Steering(in float maxSteerAngle, in float currentHorizontalInput)
        {
            float currentSteeringAngle = maxSteerAngle * currentHorizontalInput;

            _wheelColliders[0].steerAngle = currentSteeringAngle;
            _wheelColliders[1].steerAngle = currentSteeringAngle;
        }

        public void Brake(in float brakeTorque)
        {
            foreach (WheelCollider wheel in _wheelColliders)
                wheel.brakeTorque = brakeTorque;
        }
    }
}