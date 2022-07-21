using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    [SerializeField] private Points_Properties _pointsProperties;
    [SerializeField] private GameObject Cube;
    [SerializeField] private Text buttonText;

    private GameObject[] points;
    private Vector3[] reverse_array;

    private float speedRotationX;
    private float speedRotationY;
    private float speedRotationZ;
    private float movingSpeed;
    private int count = 0;
    private int array_size;

    private bool isPlayed = false;

    private void Start()
    {
        points = _pointsProperties.points;
        
        speedRotationX = _pointsProperties.rotatoinXspeed;
        speedRotationY = _pointsProperties.rotatoinYspeed;
        speedRotationZ = _pointsProperties.rotatoinZspeed;
        
        array_size = points.Length;
    }

    private void Reverse_array()
    {
        reverse_array = new Vector3[array_size];

        for (int index = 0; index < array_size; index++)
        {
            reverse_array[index] = points[array_size - 1 - index].transform.position; 
        }
        for (int index = 0; index < array_size; index++)
        {
            points[index].transform.position = reverse_array[index]; 
        }
    }

    public void OnClickButton()
    {
        isPlayed = !isPlayed;
    }

    private void Update()
    {
        if (isPlayed == true)
        {
            movingSpeed = _pointsProperties.movingSpeed;
            buttonText.text = "Pause";

            Cube.transform.position = Vector3.MoveTowards(Cube.transform.position, points[count].transform.position, movingSpeed * Time.deltaTime);

            Cube.transform.Rotate(new Vector3(speedRotationX, speedRotationY, speedRotationZ) * Time.deltaTime);

            if (Cube.transform.position == points[count].transform.position)
            {
                if (count < array_size - 1)
                {
                    count++;
                }
                else if (count == array_size - 1)
                {
                    Reverse_array();
                    count = 0;
                }
            }
        }
        else if (isPlayed == false)
        {
            movingSpeed = 0;
            buttonText.text = "Play";
        }
    }
}
