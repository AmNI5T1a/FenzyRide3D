using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FenzyRide3D.Scripts.CarControlling
{
    [RequireComponent(typeof(CarControlling))]
    public class GearBox : MonoBehaviour
    {
        [Header("References:")]
        private CarControlling _carControlling;

        [Header("Stats:")]
        [SerializeField] private Gear[] _gears;
        [SerializeField] private Gear _shiftStage;

        [Space(10)]

        [SerializeField] private float _transitionTimeBetweenGears;

        [Header("Info:")]
        [SerializeField] private Gear _currentGear;

        [Space(10)]

        [SerializeField] private short _currentGearID;

        [SerializeField] private float _currentTransition_BetweenGears_TimeLeft;



        [SerializeField] Dictionary<short, Gear> GearWithID = new Dictionary<short, Gear>();

        private void Start()
        {
            short gearIDCounter = 0;

            foreach (Gear tempGear in _gears)
            {
                GearWithID.Add(gearIDCounter, tempGear);
                gearIDCounter++;
            }

            _currentGear = GearWithID[0];
            _currentGearID = 0;
        }

        public void CalculateRealRPM_Score(ref WheelCollider[] _wheelColliders)
        {
            float calculatedRealRPM_Score = ((_wheelColliders[0].rpm + _wheelColliders[1].rpm + _wheelColliders[2].rpm + _wheelColliders[3].rpm) / 4) * _currentGear.Ratio;
            CAR_STATS_TEST.Instance.RPM = calculatedRealRPM_Score;
            CAR_STATS_TEST.Instance.GearID = _currentGearID;
            CAR_STATS_TEST.Instance.GearMaxRPM = _currentGear.MaxRPM;
            CAR_STATS_TEST.Instance.GearMinRPM = _currentGear.MinRPM;
            CAR_STATS_TEST.Instance.GearRatio = _currentGear.Ratio;
            CAR_STATS_TEST.Instance.ShiftTimeTransaction = _transitionTimeBetweenGears;

            if (_currentTransition_BetweenGears_TimeLeft <= 0)
            {
                if (calculatedRealRPM_Score > _currentGear.MaxRPM && _currentGearID != _gears.Length - 1)
                {
                    StartCoroutine(GearUp());
                }

                if (calculatedRealRPM_Score < _currentGear.MinRPM && _currentGearID != 0)
                {
                    StartCoroutine(GearDown());
                }
            }
        }

        public IEnumerator GearUp()
        {
            _currentTransition_BetweenGears_TimeLeft = _transitionTimeBetweenGears;

            _currentGear = _shiftStage;
            yield return new WaitForSeconds(_transitionTimeBetweenGears);

            _currentGear = GearWithID[(short)(_currentGearID + 1)];
            _currentGearID += 1;

            _currentTransition_BetweenGears_TimeLeft = 0;
        }

        public IEnumerator GearDown()
        {
            _currentTransition_BetweenGears_TimeLeft = _transitionTimeBetweenGears;

            _currentGear = _shiftStage;
            yield return new WaitForSeconds(_transitionTimeBetweenGears);

            _currentGear = GearWithID[(short)(_currentGearID - 1)];
            _currentGearID -= 1;

            _currentTransition_BetweenGears_TimeLeft = 0;
        }

        public Gear GetCurrentGear() => _currentGear;
    }
}