using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{
    public class Transmission : MonoBehaviour
    {
        private WheelCollider _wheel;
        private GameObject _thisGameObject;


        private void Start()
        {
            _wheel = this.gameObject.AddComponent<WheelCollider>();
            _wheel.mass = 30f;
        }
    }
}