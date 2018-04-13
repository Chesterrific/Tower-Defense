using UnityEngine;

public class Enemy : MonoBehaviour{

    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0]; //sets first target as the first waypoint from points array
    }

    private void Update()
    {
        /* Directs our enemy towards the target.
         * Think about the enemy's and target's position in (x, y, z).
         * Subtract their positions from each other and the difference becomes a direction.
         * transform = enemy object
         * target = waypoint object
         */
        Vector3 dir = target.position - transform.position;

        /* dir.noramlized is to make sure we're only moving based on speed var.
         * Time.deltaTime is added to ignore frame rate.
         * transform gives us access to the transform component of this object.
         * Translate allows us to move our game object in any given direction.
         * Translate moves the game object X units in the x direction, Y units in the y direction, and Z units in the z direction.
         * X, Y, Z are given by us in the vector3 dir or we can use another version of translate where we pass this in ourselves.
         * https://www.youtube.com/watch?v=YfIOPWuUjn8 for future reference.
         */
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.5f) //when enemy reaches waypoint
        {
            GetNextWaypoint();
        }
        
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
}	
