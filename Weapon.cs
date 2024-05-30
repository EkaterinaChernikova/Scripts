using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _reload;

    private Transform _target;
    private Vector3 _direction;
    private Rigidbody _newBullet;
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
            _newBullet = Instantiate(_bulletPrefab, transform.position + _direction, Quaternion.identity);

            _newBullet.transform.up = _direction;
            _newBullet.velocity = _direction * _bulletSpeed;

            yield return _fireDelay;
        }
    }
}