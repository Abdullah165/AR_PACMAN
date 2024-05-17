using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 3f; 

    private int currentWaypointIndex = 0;
    private Rigidbody rb;

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

  
    void Update()
    {
       
        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        Vector2 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;

        
        rb.velocity = direction * speed;
    }
}
