using FenzyRide3D.Scripts.CarControlling;
public interface IAccelerate
{
    public void Accelerate(in float motorTorque, in float verticalInput, in GearBox gearBox);
}