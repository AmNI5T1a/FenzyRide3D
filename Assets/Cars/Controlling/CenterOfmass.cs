using UnityEngine;

namespace FenzyRide3D.Scripts.CarControlling
{

    public class CenterOfmass : MonoBehaviour
    {
        [SerializeField] private float _centerOfMassSphereRadius;
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.gameObject.transform.position, _centerOfMassSphereRadius);
        }
    }
}