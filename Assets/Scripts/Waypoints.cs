using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [ReadOnly] public static Transform[] points;

    /// <summary> Awake is called when the script instance is being loaded. </summary>
    private void Awake()
    {
        // Get all waypoints under this object
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
