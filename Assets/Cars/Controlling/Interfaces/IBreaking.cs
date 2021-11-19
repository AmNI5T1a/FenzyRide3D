using System;
using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{
    public interface IBreaking
    {
        void Brake(in float brakeTorque);
    }
}