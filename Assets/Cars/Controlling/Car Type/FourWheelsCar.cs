using System;
using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{
    [Serializable]
    public class FourWheelsCar
    {
        [SerializeField] public Wheel frontLeftWheel;
        [SerializeField] public Wheel frontRightWheel;
        [SerializeField] public Wheel rearLeftWheel;
        [SerializeField] public Wheel rearRightWheel;
    }
}