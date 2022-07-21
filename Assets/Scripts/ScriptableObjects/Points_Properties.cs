using UnityEngine;

[CreateAssetMenu(menuName ="Points", fileName = "ScriptableObjects/Points_Properties")]

public class Points_Properties : ScriptableObject
{
    public GameObject[] points;
    public float movingSpeed;
    public float rotatoinXspeed;
    public float rotatoinYspeed;
    public float rotatoinZspeed;
}
