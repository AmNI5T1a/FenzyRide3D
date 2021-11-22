using System;
using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{
    [Serializable]
    public class Gear
    {
        [SerializeField] public float MaxRPM;
        [SerializeField] public float MinRPM;

        [Space(10)]

        [SerializeField] public float Ratio;
    }
}