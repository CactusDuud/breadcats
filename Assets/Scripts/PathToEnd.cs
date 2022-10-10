using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathToEnd : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    
    public Transform target { get; private set; }
    public int waypointIndex { get; private set; } = 0;
    public float stoppingDistance  { get; private set; } = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * walkSpeed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= stoppingDistance)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            GameManager.Instance.ReduceLives(10);
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
}
