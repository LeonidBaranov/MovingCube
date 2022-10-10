using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    [SerializeField] private PointsProperties _pointsProperties;
    [SerializeField] private GameObject _cube;
    [SerializeField] private Text _buttonText;

    private Vector3[] _reverseArray;
    private int _count = 0;
    private bool _isPlayed = false;
    private float _movingSpeed;

    private void Reverse_array()
    {
        _reverseArray = new Vector3[_pointsProperties.Points.Length];

        for (int index = 0; index < _pointsProperties.Points.Length; index++)
        {
            _reverseArray[index] = _pointsProperties.Points[_pointsProperties.Points.Length - 1 - index].transform.position; 
        }
        for (int index = 0; index < _pointsProperties.Points.Length; index++)
        {
            _pointsProperties.Points[index].transform.position = _reverseArray[index]; 
        }
    }

    public void OnClickButton()
    {
        _isPlayed = !_isPlayed;
    }

    private void Update()
    {
        if (_isPlayed == true)
        {
            _movingSpeed = _pointsProperties.MovingSpeed;
            _buttonText.text = "Pause";

            _cube.transform.position = Vector3.MoveTowards(_cube.transform.position, _pointsProperties.Points[_count].transform.position, _pointsProperties.MovingSpeed * Time.deltaTime);

            _cube.transform.Rotate(new Vector3(_pointsProperties.RotatoinXspeed, _pointsProperties.RotatoinYspeed, _pointsProperties.RotatoinZspeed) * Time.deltaTime);

            if ((_cube.transform.position.x - _pointsProperties.Points[_count].transform.position.x <= 0.01) & 
                (_cube.transform.position.y - _pointsProperties.Points[_count].transform.position.y <= 0.01) &
                (_cube.transform.position.z - _pointsProperties.Points[_count].transform.position.z <= 0.01)) 
            {
                if (_count < _pointsProperties.Points.Length - 1)
                {
                    _count++;
                }
                else if (_count == _pointsProperties.Points.Length - 1)
                {
                    Reverse_array();
                    _count = 0;
                }
            }
        }
        else if (_isPlayed == false)
        {
            _movingSpeed = 0;
            _buttonText.text = "Play";
        }
    }
}
