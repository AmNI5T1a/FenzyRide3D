using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FenzyRide3D.Scripts.Input;
public class input_test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Acceleration();
    }

    private void Acceleration()
    {
        if(VirtualInputManager.Instance.MoveFront)
        {
            Debug.Log("Throttle: 100%");
        }else
        {
            Debug.Log("Throttle: 0%");
        }
    }
}
