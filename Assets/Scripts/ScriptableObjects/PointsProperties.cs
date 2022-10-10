using UnityEngine;

[CreateAssetMenu(menuName ="Asset", fileName = "ScriptableObjects/PointsProperties")]

public class PointsProperties : ScriptableObject
{
    [SerializeField] public GameObject[] Points;
    [SerializeField] public float MovingSpeed;
    [SerializeField] public float RotatoinXspeed;
    [SerializeField] public float RotatoinYspeed;
    [SerializeField] public float RotatoinZspeed;
}
