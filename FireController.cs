using System.Collections;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _reload;

    private Transform _target;
    private Vector3 _direction;
    private GameObject _newBullet;
    private WaitForSeconds _fireDelay;

    private void Start()
    {
        _fireDelay = new WaitForSeconds(_reload);
        StartCoroutine(OpenFire());
    }

    private IEnumerator OpenFire()
    {
        while (true)
        {
            _direction = (_target.position - transform.position).normalized;
            _newBullet = Instantiate(_bullet, transform.position + _direction, Quaternion.identity);

            _newBullet.GetComponent<Rigidbody>().transform.up = _direction;
            _newBullet.GetComponent<Rigidbody>().velocity = _direction * _bulletSpeed;

            yield return _fireDelay;
        }
    }
}