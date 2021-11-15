using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _objectToFollow;


    private void FixedUpdate()
    {
        this.gameObject.transform.LookAt(_objectToFollow.transform);
    }
}
