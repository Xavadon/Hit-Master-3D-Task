using UnityEngine;

namespace OK
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _target;

        [SerializeField] private float _smoothSpeed = 0.125f;
        [SerializeField] private Vector3 _offset;

        private void Start()
        {
            _target = Player._singleton.transform;
        }

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _smoothSpeed);
        }
    }
}
