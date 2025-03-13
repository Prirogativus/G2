using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Route route;
    private Ship ship;
    private int currentWaypointIndex = 0;
    float speed;

    private void Start()
    {
        ship = GetComponent<Ship>();
        ShipStats shipStats = ship.stats;
        speed = shipStats.speed;
    }
    void Update()
    {
        if (route == null || route.waypoints.Length == 0) return;
        Vector3 targetWaypoint = route.waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint) < 0.1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= route.waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        Quaternion targetRotation = Quaternion.LookRotation(targetWaypoint - transform.position);
        Vector3 currentEulerAngles = transform.rotation.eulerAngles;
        Vector3 targetEulerAngles = targetRotation.eulerAngles;
        targetEulerAngles.x = -90;
        targetEulerAngles.z -= 90;
        transform.rotation = Quaternion.Euler(targetEulerAngles);
    }
}
