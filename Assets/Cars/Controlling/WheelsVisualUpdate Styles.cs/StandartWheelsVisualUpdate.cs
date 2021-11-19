using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{
    public class StandartWheelsVisualUpdate : AbstractWheelsVIsualUpdate, IWheelsVisualUpdate
    {
        private void UpdateWheelWorldPosition(Transform wheelTransform, WheelCollider wheelCollider)
        {
            Vector3 tempWheelPosition = wheelTransform.position;
            Quaternion tempWheelRotation = wheelTransform.rotation;

            wheelCollider.GetWorldPose(out tempWheelPosition, out tempWheelRotation);

            wheelTransform.position = tempWheelPosition;
            wheelTransform.rotation = tempWheelRotation;
        }
        public override void UpdateWheelsPositionRotation()
        {
            UpdateWheelWorldPosition(wheelTransform: _wheelTransforms[0],
                                    wheelCollider: _wheelColliders[0]);

            UpdateWheelWorldPosition(wheelTransform: _wheelTransforms[0],
                                    wheelCollider: _wheelColliders[0]);

            UpdateWheelWorldPosition(wheelTransform: _wheelTransforms[0],
                                    wheelCollider: _wheelColliders[0]);

            UpdateWheelWorldPosition(wheelTransform: _wheelTransforms[0],
                                    wheelCollider: _wheelColliders[0]);
        }

        public override void SetWheels(ref WheelCollider[] wheelColliders, ref Transform[] wheelTransforms)
        {
            this._wheelColliders = wheelColliders;
            this._wheelTransforms = wheelTransforms;
        }
    }
}