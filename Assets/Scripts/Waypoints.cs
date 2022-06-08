using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    private void Awake()
    {
        //making spaces for all the children of the parent object the script is on
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            //adding in each child at the same point in the array that it is in the main parent in the hierarchy
            points[i] = transform.GetChild(i);
        }
    }
}
