using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FenzyRide3D.Scripts.Input;

namespace FenzyRide3D.Scripts.CarControlling
{
    [RequireComponent(typeof(Rigidbody))]
    public class CarControlling : MonoBehaviour
    {
        [Serializable]
        private class Wheels<T>
        {
            [SerializeField] public T FrontLeftWheel;
            [SerializeField] public T FrontRightWheel;
            [SerializeField] public T RearLeftWheel;
            [SerializeField] public T RearRightWheel;

            public T[] GetWheels()
            {
                T[] wheelsArray = new T[] { FrontLeftWheel, FrontRightWheel, RearLeftWheel, RearRightWheel };
                return wheelsArray;
            }
        }


        [Header("References:")]
        [SerializeField] private Wheels<WheelCollider> _wheelColliders;
        [SerializeField] private Wheels<Transform> _wheelTransforms;
        [SerializeField] private GameObject _centerOfMass;

        [Header("Stats:")]
        [SerializeField] private float _maxSteeringAngle;
        [SerializeField] private float _motorTorque;
        [SerializeField] private float _brakesTorque;
        [SerializeField] private float _linearInterpolationValue;

        [Header("PlayMode stats:")]
        [SerializeField] private float _currentVerticalInput;
        [SerializeField] private float _currentHorizontalInput;

        [SerializeField] private float _currentSteeringAngle;
        [SerializeField] private float _currentMotorTorqueValue;



        private void Start()
        {

        }
        private void FixedUpdate()
        {
            GetVerticalInput();
            GetHorizontalInput();
            Steering();
            Acceleration();
            Brakes();

            UpdateEachWheelTransform(wheelTransforms: _wheelTransforms,
                                    wheelColliders: _wheelColliders);


            // * Calculate motor torque 
            _currentMotorTorqueValue = (_wheelColliders.RearLeftWheel.motorTorque
                                    + _wheelColliders.RearRightWheel.motorTorque
                                    + _wheelColliders.FrontLeftWheel.motorTorque
                                    + _wheelColliders.FrontRightWheel.motorTorque) / 4f;


            // * Set center of mass 
            this.gameObject.GetComponent<Rigidbody>().centerOfMass = _centerOfMass.transform.localPosition;
        }

        private void GetVerticalInput()
        {
            if (!VirtualInputManager.Instance.MoveFront && !VirtualInputManager.Instance.MoveBack)
            {
                _currentVerticalInput = Mathf.Lerp(_currentVerticalInput, 0f, _linearInterpolationValue);
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

        private void Steering()
        {
            _currentSteeringAngle = _maxSteeringAngle * _currentHorizontalInput;


            _wheelColliders.FrontLeftWheel.steerAngle = _currentSteeringAngle;
            _wheelColliders.FrontRightWheel.steerAngle = _currentSteeringAngle;
        }

        private void Acceleration()
        {
            _wheelColliders.RearLeftWheel.motorTorque = _motorTorque * _currentVerticalInput;
            _wheelColliders.RearRightWheel.motorTorque = _motorTorque * _currentVerticalInput;
        }

        private void Brakes()
        {
            if (VirtualInputManager.Instance.Brake)
            {
                _wheelColliders.RearLeftWheel.motorTorque = 0f;
                _wheelColliders.RearRightWheel.motorTorque = 0f;

                _wheelColliders.RearLeftWheel.brakeTorque = _brakesTorque;
                _wheelColliders.RearRightWheel.brakeTorque = _brakesTorque;
                _wheelColliders.FrontLeftWheel.brakeTorque = _brakesTorque;
                _wheelColliders.FrontRightWheel.brakeTorque = _brakesTorque;
            }
            else
            {
                _wheelColliders.RearLeftWheel.brakeTorque = 0f;
                _wheelColliders.RearRightWheel.brakeTorque = 0f;
                _wheelColliders.FrontLeftWheel.brakeTorque = 0f;
                _wheelColliders.FrontRightWheel.brakeTorque = 0f;
            }
        }

        private void UpdateEachWheelTransform(Wheels<Transform> wheelTransforms, Wheels<WheelCollider> wheelColliders)
        {
            UpdateWheelWorldPosition(wheelTransform: wheelTransforms.FrontLeftWheel,
                                    wheelCollider: wheelColliders.FrontLeftWheel);

            UpdateWheelWorldPosition(wheelTransform: wheelTransforms.FrontRightWheel,
                                    wheelCollider: wheelColliders.FrontRightWheel);

            UpdateWheelWorldPosition(wheelTransform: wheelTransforms.RearLeftWheel,
                                    wheelCollider: wheelColliders.RearLeftWheel);

            UpdateWheelWorldPosition(wheelTransform: wheelTransforms.RearRightWheel,
                                    wheelCollider: wheelColliders.RearRightWheel);
        }

        private void UpdateWheelWorldPosition(Transform wheelTransform, WheelCollider wheelCollider)
        {
            Vector3 tempWheelPosition = wheelTransform.position;
            Quaternion tempWheelRotation = wheelTransform.rotation;

            wheelCollider.GetWorldPose(out tempWheelPosition, out tempWheelRotation);

            wheelTransform.position = tempWheelPosition;
            //wheelTransform.transform.position = new Vector3(wheelTransform.position.x, tempWheelPosition.y, wheelTransform.position.z);
            wheelTransform.rotation = tempWheelRotation;
        }
    }
}