using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;

        [SerializeField] private float _moveSpeed = 5f;

        private Rigidbody _rigidbody;

        private Vector3 _targetPosition;
        private Vector3 _currentForce;
        private Vector3 _direction;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _direction = (_targetPosition - _rigidbody.position).normalized;
            _currentForce = _direction * _moveSpeed;
            _rigidbody.AddForce(_currentForce, ForceMode.Acceleration);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            var inputVector = context.ReadValue<Vector2>();

            if (inputVector == Vector2.zero)
            {
                return;
            }

            var raycastVector = new Vector3(inputVector.x, inputVector.y, _mainCamera.nearClipPlane + 1);
            var ray = _mainCamera.ScreenPointToRay(raycastVector);

            if (!Physics.Raycast(ray, out var hit)) return;
            
            Debug.DrawLine(ray.origin, hit.point, Color.red);

            _targetPosition = hit.point;
        }
    }
}