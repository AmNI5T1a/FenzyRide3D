using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FenzyRide3D.Scripts.Input;
using UnityEngine.UI;

public class CAR_STATS_TEST : MonoBehaviour
{
    public static CAR_STATS_TEST Instance { get; private set; }

    [SerializeField] public float RPM;
    [SerializeField] public float GearID;
    [SerializeField] public float GearRatio;
    [SerializeField] public float GearMinRPM;
    [SerializeField] public float GearMaxRPM;
    [SerializeField] public float CarMotorTorque;
    [SerializeField] public float CarBrakeTorque;
    [SerializeField] public float CarMaxSteeringAngle;
    [SerializeField] public float VerticalInput;
    [SerializeField] public float HorizontalInput;
    [SerializeField] public float ShiftTimeTransaction;
    [SerializeField] public float MotorTorqueValue;

    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Text>().text = "RPM: " + RPM.ToString();
        this.gameObject.transform.GetChild(1).GetComponent<Text>().text = "Gear: " + GearID.ToString();
        this.gameObject.transform.GetChild(2).GetComponent<Text>().text = "Gear Ratio: " + GearRatio.ToString();
        this.gameObject.transform.GetChild(3).GetComponent<Text>().text = "Gear MaxRPM: " + GearMaxRPM.ToString();
        this.gameObject.transform.GetChild(4).GetComponent<Text>().text = "Gear MinRPM: " + GearMinRPM.ToString();
        this.gameObject.transform.GetChild(5).GetComponent<Text>().text = "Car MotorTorque: " + CarMotorTorque.ToString();
        this.gameObject.transform.GetChild(6).GetComponent<Text>().text = "Car BrakeTorque: " + CarBrakeTorque.ToString();
        this.gameObject.transform.GetChild(7).GetComponent<Text>().text = "Car MaxSteeringAngle: " + CarMaxSteeringAngle.ToString();
        this.gameObject.transform.GetChild(8).GetComponent<Text>().text = "Vertical Input: " + VerticalInput.ToString();
        this.gameObject.transform.GetChild(9).GetComponent<Text>().text = "Horizontal Input: " + HorizontalInput.ToString();
        this.gameObject.transform.GetChild(10).GetComponent<Text>().text = "Shift TransitionTime: " + ShiftTimeTransaction.ToString();
        this.gameObject.transform.GetChild(11).GetComponent<Text>().text = "MotorTorque Value: " + MotorTorqueValue.ToString();
    }
}
