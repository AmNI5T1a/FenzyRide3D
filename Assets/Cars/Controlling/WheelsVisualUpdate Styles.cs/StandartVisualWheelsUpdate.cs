using UnityEngine;


namespace FenzyRide3D.Scripts.CarControlling
{
    public class StandartVisualWheelsUpdate : MonoBehaviour, IWheelsVisualUpdate
    {
        public void UpdateWheelsPositionRotation()
        {
            // UpdateWheelWorldPosition(wheelTransform: wheelTransforms.FrontLeftWheel,
            //                         wheelCollider: wheelColliders.FrontLeftWheel);

            // UpdateWheelWorldPosition(wheelTransform: wheelTransforms.FrontRightWheel,
            //                         wheelCollider: wheelColliders.FrontRightWheel);

            // UpdateWheelWorldPosition(wheelTransform: wheelTransforms.RearLeftWheel,
            //                         wheelCollider: wheelColliders.RearLeftWheel);

            // UpdateWheelWorldPosition(wheelTransform: wheelTransforms.RearRightWheel,
            //                         wheelCollider: wheelColliders.RearRightWheel);
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