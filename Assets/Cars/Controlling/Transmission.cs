using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{
    public class Transmission : MonoBehaviour
    {
        [SerializeField] private float weight;

        [SerializeField] private LinkedList<WheelCollider> _wheels;
        void Start()
        {
            for (int i = 0; i < 4; i++)
            {
                WheelCollider wheel = this.gameObject.transform.GetChild(0).gameObject.AddComponent<WheelCollider>();
                wheel.mass = weight;
                _wheels.AddLast(wheel);
            }
        }
    }
}