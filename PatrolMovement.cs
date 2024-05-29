using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    [SerializeField] private Transform _placesGroup;

    private Transform _targetPlace;
    private Transform[] _arrayPlaces;

    private float _movementSpeed = 2.0f;
    private int _placeNumber;

    private void Start()
    {
        _arrayPlaces = new Transform[_placesGroup.childCount];

        for (int i = 0; i < _placesGroup.childCount; i++)
        {
            _arrayPlaces[i] = _placesGroup.GetChild(i).GetComponent<Transform>();
        }

        _targetPlace = _arrayPlaces[_placeNumber];
        transform.LookAt(_targetPlace);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _movementSpeed);

        if (transform.position == _targetPlace.position)
        {
            SetNextPlace();
        }
    }

    private void SetNextPlace()
    {
        _placeNumber++;

        if (_placeNumber == _arrayPlaces.Length)        
        {
            _placeNumber = 0;
        }

        _targetPlace = _arrayPlaces[_placeNumber];
        transform.LookAt(_targetPlace);
    }
}