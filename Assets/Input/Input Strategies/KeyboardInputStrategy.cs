using UnityEngine;

namespace FenzyRide3D.Scripts.Input
{
    public class KeyboardInputStrategy : MonoBehaviour, InputStrategy
    {
        public void Execute()
        {
            if (UnityEngine.Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance.MoveRight = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveRight = false;
            }

            if (UnityEngine.Input.GetKey(KeyCode.A))
            {
                VirtualInputManager.Instance.MoveLeft = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveLeft = false;
            }

            if (UnityEngine.Input.GetKey(KeyCode.W))
            {
                VirtualInputManager.Instance.MoveFront = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveFront = false;
            }

            if (UnityEngine.Input.GetKey(KeyCode.S))
            {
                VirtualInputManager.Instance.MoveBack = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveBack = false;
            }

            if (UnityEngine.Input.GetKey(KeyCode.Space))
            {
                VirtualInputManager.Instance.Brake = true;
            }
            else
            {
                VirtualInputManager.Instance.Brake = false;
            }
        }
    }
}