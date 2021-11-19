using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{
    public abstract class AbstractWheelsVIsualUpdate : MonoBehaviour, IWheelsVisualUpdate
    {
        [SerializeField] protected WheelCollider[] _wheelColliders;
        [SerializeField] protected Transform[] _wheelTransforms;

        public abstract void UpdateWheelsPositionRotation();
        public abstract void SetWheels(ref WheelCollider[] wheelColliders, ref Transform[] wheelTransforms);
    }
}