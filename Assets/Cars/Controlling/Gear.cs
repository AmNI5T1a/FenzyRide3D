using System;
using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{
    [Serializable]
    class Gear
    {
        [SerializeField] private float MaxRPM;
        [SerializeField] public float MinRPM;

        [Space(10)]

        [SerializeField] private float Ratio;
    }
}