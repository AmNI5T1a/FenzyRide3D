using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FenzyRide3D.Scripts.CarControlling
{
    [RequireComponent(typeof(CarControlling))]
    public class GearBox : MonoBehaviour
    {
        [Header("Stats:")]
        [SerializeField] Gear[] _gears;
        [SerializeField] Gear _shiftStage;

        [Space(10)]

        [SerializeField] private float _transitionTimeBetweenGears;

        [Header("Info:")]
        [SerializeField] private Gear _currentGear;


        [SerializeField] Dictionary<ushort, Gear> gearID = new Dictionary<ushort, Gear>();

        private void Start()
        {
            ushort gearIDCounter = 0;

            foreach (Gear tempGear in _gears)
            {
                gearID.Add(gearIDCounter, tempGear);
                gearIDCounter++;
            }

            _currentGear = gearID[0];
        }
    }
}