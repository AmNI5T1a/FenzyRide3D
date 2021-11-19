namespace FenzyRide3D.Scripts.CarControlling
{
    public interface ISteering
    {
        void Steering(in float maxSteerAngle, in float currentHorizontalInput);
    }
}