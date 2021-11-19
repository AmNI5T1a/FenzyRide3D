using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{
    public abstract class AccelerationType : MonoBehaviour, IAccelerate
    {
        public abstract void Accelerate(in float motorTorque, in float verticalInput);
    }
}