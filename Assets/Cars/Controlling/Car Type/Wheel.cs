using System;
using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{
    [Serializable]
    public class Wheel
    {
        [SerializeField] public WheelCollider _wheelCollider;
        [SerializeField] public Transform _wheelTransform;
    }
}