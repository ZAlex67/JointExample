using UnityEngine;

public class AddMoveForce : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void AddForce()
    {
        _rigidbody.AddForce(_direction, ForceMode.Force);
    }
}