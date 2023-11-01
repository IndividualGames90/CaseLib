using UnityEngine;

namespace IndividualGames.CaseLib.Transformation
{
    /// <summary>
    /// Handles rotation animation on Transform.
    /// </summary>
    public class RotateAroundItself : MonoBehaviour
    {
        [SerializeField] private Transform _rotateThis;
        [SerializeField] private float _rotationSpeed = 10f;
        [SerializeField] private bool _rotateAroundY = false;

        private void Awake()
        {
            if (_rotateThis == null)
            {
                _rotateThis = transform;
            }
        }

        private void FixedUpdate()
        {
            if (_rotateAroundY)
            {
                RotateAroundOnY();
            }
        }

        private void RotateAroundOnY()
        {
            _rotateThis.localRotation *= Quaternion.AngleAxis(_rotationSpeed * Time.deltaTime, Vector3.up);
        }
    }
}