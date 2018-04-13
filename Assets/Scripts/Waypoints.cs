using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static Transform[] points; //array of waypoints

    private void Awake()
    {
        //creates new array with size of # of Waypoints object's children
        points = new Transform[transform.childCount];

        //basic for loop populating array with Waypoint's children
        for(int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
