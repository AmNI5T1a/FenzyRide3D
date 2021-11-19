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
            for (short i = 0; i < 4; i++)
            {
                UpdateWheelWorldPosition(wheelTransform: _wheelTransforms[i],
                                    wheelCollider: _wheelColliders[i]);
            }
        }

        public override void SetWheels(ref WheelCollider[] wheelColliders, ref Transform[] wheelTransforms)
        {
            this._wheelColliders = wheelColliders;
            this._wheelTransforms = wheelTransforms;
        }
    }
}