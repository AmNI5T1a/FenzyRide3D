using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{
    [RequireComponent(typeof(IWheelsVisualUpdate))]
    public class FrontWheelDriveCar : AccelerationType, IAccelerate, ISteering
    {
        [SerializeField] private WheelCollider[] _wheelColliders;
        [SerializeField] private Transform[] _wheelTransforms;
        private void Awake()
        {
            this._wheelColliders = this.gameObject.GetComponent<CarControlling>()._wheelColliders;
            this._wheelTransforms = this.gameObject.GetComponent<CarControlling>()._wheelTransforms;
        }
        public override void Accelerate(in float motorTorque, in float verticalInput)
        {
            _wheelColliders[0].motorTorque = motorTorque * verticalInput;
            _wheelColliders[1].motorTorque = motorTorque * verticalInput;
        }

        public void Steering(in float maxSteerAngle, in float currentHorizontalInput)
        {
            float currentSteeringAngle = maxSteerAngle * currentHorizontalInput;

            _wheelColliders[0].steerAngle = currentSteeringAngle;
            _wheelColliders[1].steerAngle = currentSteeringAngle;
        }

        private void UpdateWheelWorldPosition(Transform wheelTransform, WheelCollider wheelCollider)
        {
            Vector3 tempWheelPosition = wheelTransform.position;
            Quaternion tempWheelRotation = wheelTransform.rotation;

            wheelCollider.GetWorldPose(out tempWheelPosition, out tempWheelRotation);

            wheelTransform.position = tempWheelPosition;
            wheelTransform.rotation = tempWheelRotation;
        }
    }
}