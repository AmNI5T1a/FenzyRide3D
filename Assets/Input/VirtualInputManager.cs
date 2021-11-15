using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FenzyRide3D.Scripts.Input
{
    public class VirtualInputManager : Singleton<VirtualInputManager>
    {
        [Header("References:")]
        [SerializeField] private InputStrategy _inputStrategy;

        public bool MoveLeft;
        public bool MoveRight;
        public bool MoveFront;
        public bool MoveBack;
        public bool Brake;

        void Start()
        {
            _inputStrategy = this.gameObject.AddComponent<KeyboardInputStrategy>();
        }

        void Update()
        {
            _inputStrategy.Execute();
        }

        private void ChangeInputStrategy(InputStrategy newInputStrategy)
        {
            this._inputStrategy = newInputStrategy;
        }
    }
}