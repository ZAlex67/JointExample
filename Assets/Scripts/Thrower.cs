using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Sphere _sphere;

    private Sphere _sphereNew;
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _sphereNew = Instantiate(_sphere, _spawnPoint);
        _sphereNew.gameObject.SetActive(false);
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    public void StartMove()
    {
        _sphereNew.gameObject.SetActive(true);
        _sphereNew.transform.position = _spawnPoint.position;
        _rigidbody.isKinematic = false;
    }

    public void Restart()
    {
        _sphereNew.gameObject.SetActive(false);
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        _rigidbody.isKinematic = true;
    }
}