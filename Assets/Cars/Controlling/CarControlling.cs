using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FenzyRide3D.Scripts.Input;

namespace FenzyRide3D.Scripts.CarControlling
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(GearBox))]
    [RequireComponent(typeof(IAccelerate))]
    [RequireComponent(typeof(ISteering))]
    [RequireComponent(typeof(IWheelsVisualUpdate))]
    public class CarControlling : MonoBehaviour
    {
        [Header("References:")]

        [SerializeField] private GameObject _centerOfMass;

        [Space(10)]

        [SerializeField] private GearBox _gearBox;

        [Space(10)]

        [SerializeField] private IAccelerate _accelerator;

        [Header("Stats:")]
        [SerializeField] private float _maxSteeringAngle;
        [SerializeField] public float _motorTorque;
        [SerializeField] private float _brakesTorque;

        [Header("Info:")]
        [SerializeField] private float _currentVerticalInput;
        [SerializeField] private float _currentHorizontalInput;

        [SerializeField] private float _currentSteeringAngle;
        [SerializeField] private float _currentMotorTorqueValue;

        private void Awake()
        {
            GearBoxCheck();
        }

        private void GearBoxCheck()
        {
            if (_gearBox == null)
            {
                _gearBox = this.gameObject.GetComponent<GearBox>();

                if (_gearBox == null)
                {
                    Debug.LogError("CarControlling can't work without GearBox");

                    // * Possible solution: initialize gearbox with ctor
                    // ! ctor is missing
                }
            }
        }

        private void FixedUpdate()
        {
            GetVerticalInput();
            GetHorizontalInput();
            Accelerate();
            Steering();
            UpdateVisuals();

            // Brakes();

            // UpdateEachWheelTransform(wheelTransforms: _wheelTransforms,
            //                         wheelColliders: _wheelColliders);


            // * Calculate motor torque 
            // _currentMotorTorqueValue = (_wheelColliders.RearLeftWheel.motorTorque
            //                         + _wheelColliders.RearRightWheel.motorTorque
            //                         + _wheelColliders.FrontLeftWheel.motorTorque
            //                         + _wheelColliders.FrontRightWheel.motorTorque) / 4f;


            // * Set center of mass 
            this.gameObject.GetComponent<Rigidbody>().centerOfMass = _centerOfMass.transform.localPosition;
        }

        private void GetVerticalInput()
        {
            if (!VirtualInputManager.Instance.MoveFront && !VirtualInputManager.Instance.MoveBack)
            {
                _currentVerticalInput = 0f;
                return;
            }

            if (VirtualInputManager.Instance.MoveFront)
            {
                if (_currentVerticalInput >= 1f)
                    return;
                if (_currentVerticalInput < 0f)
                    _currentVerticalInput = 0f;

                _currentVerticalInput += 0.1f;

            }

            if (VirtualInputManager.Instance.MoveBack)
            {
                if (_currentVerticalInput <= -1f)
                    return;
                if (_currentVerticalInput > 0f)
                    _currentVerticalInput = 0f;

                _currentVerticalInput -= 0.1f;
            }
        }

        private void GetHorizontalInput()
        {
            if (!VirtualInputManager.Instance.MoveLeft && !VirtualInputManager.Instance.MoveRight)
            {
                _currentHorizontalInput = 0f;
                return;
            }

            if (VirtualInputManager.Instance.MoveRight)
            {
                if (_currentHorizontalInput >= 1f)
                    return;
                if (_currentHorizontalInput < 0f)
                    _currentHorizontalInput = 0f;

                _currentHorizontalInput += 0.1f;

            }

            if (VirtualInputManager.Instance.MoveLeft)
            {
                if (_currentHorizontalInput <= -1f)
                    return;
                if (_currentHorizontalInput > 0f)
                    _currentHorizontalInput = 0f;

                _currentHorizontalInput -= 0.1f;
            }
        }

        private void Accelerate()
        {
            this.gameObject.GetComponent<IAccelerate>().Accelerate(_motorTorque, _currentVerticalInput);
        }

        private void Steering()
        {
            this.gameObject.GetComponent<ISteering>().Steering(maxSteerAngle: _maxSteeringAngle, currentHorizontalInput: _currentHorizontalInput);
        }

        // private void Brakes()
        // {
        //     if (VirtualInputManager.Instance.Brake)
        //     {
        //         _wheelColliders.RearLeftWheel.motorTorque = 0f;
        //         _wheelColliders.RearRightWheel.motorTorque = 0f;

        //         _wheelColliders.RearLeftWheel.brakeTorque = _brakesTorque;
        //         _wheelColliders.RearRightWheel.brakeTorque = _brakesTorque;
        //         _wheelColliders.FrontLeftWheel.brakeTorque = _brakesTorque;
        //         _wheelColliders.FrontRightWheel.brakeTorque = _brakesTorque;
        //     }
        //     else
        //     {
        //         _wheelColliders.RearLeftWheel.brakeTorque = 0f;
        //         _wheelColliders.RearRightWheel.brakeTorque = 0f;
        //         _wheelColliders.FrontLeftWheel.brakeTorque = 0f;
        //         _wheelColliders.FrontRightWheel.brakeTorque = 0f;
        //     }
        // }

        private void UpdateVisuals()
        {
            this.gameObject.GetComponent<IWheelsVisualUpdate>().UpdateWheelsPositionRotation();
        }
    }
}