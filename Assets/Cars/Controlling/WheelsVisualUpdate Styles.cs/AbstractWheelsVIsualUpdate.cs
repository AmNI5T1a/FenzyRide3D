using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{
    public abstract class AbstractWheelsVIsualUpdate : MonoBehaviour, IWheelsVisualUpdate
    {
        protected WheelCollider[] _wheelColliders;
        protected Transform[] _wheelTransforms;

        public abstract void UpdateWheelsPositionRotation();
        public abstract void SetWheels(ref WheelCollider[] wheelColliders, ref Transform[] wheelTransforms);
    }
}