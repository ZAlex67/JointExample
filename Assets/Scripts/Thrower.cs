using System.Collections;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Sphere _sphere;

    private Coroutine _coroutine;
    private Sphere _sphereNew;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _sphereNew = Instantiate(_sphere, _spawnPoint);
        _sphereNew.gameObject.SetActive(false);
    }

    public void StartMove()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _sphereNew.gameObject.SetActive(true);
        _sphereNew.transform.position = _spawnPoint.position;

        _coroutine = StartCoroutine(MoverCube());
    }

    public void Restart()
    {
        _sphereNew.gameObject.SetActive(false);
        transform.position = _startPoint.position;
        transform.rotation = _startPoint.rotation;
        _rigidbody.isKinematic = true;
    }

    private IEnumerator MoverCube()
    {
        while (transform.position != _point.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _point.position, _speed * Time.deltaTime);
            yield return null;
        }

        _rigidbody.isKinematic = false;
    }
}