using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pathfinding;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;

    public AIDestinationSetter destinationSetter;
    public Transform targetPosition;
    public Path path;

    public Seeker seeker;

    public float nextWaypointDistance = 3;

    private int currentWaypoint = 0;

    private bool reachedEndOfPath = false;
    void Start(){
        destinationSetter.target = targetPosition;
        
        return;
        seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
    }

    public void OnPathComplete (Path p) {
        Debug.Log("Path calculated. :" + p.error);

        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    public Animator animator;

    private Vector3 movement;
    private Vector3 axis;

    void Update()
    {   
        return;
        //Animation
        movement.x = axis.x = 0;
        movement.y = axis.y = 0;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Mathf.Abs(axis.x) == 1 && Mathf.Abs(axis.y) == 1)
        {
            movement.x = Mathf.Sqrt(0.5f) * axis.x;
            movement.y = Mathf.Sqrt(0.5f) * axis.y;
        }

        return;

        //We dont hv a path to follow yet, so dont do anything
        if (path == null)  return;
        reachedEndOfPath = false;

        float distanceToWaypoint;
        while (true) {
            // If you want maximum performance you can check the squared distance instead to get rid of a
            // square root calculation. But that is outside the scope of this tutorial.
            distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distanceToWaypoint < nextWaypointDistance) {
                // Check if there is another waypoint or if we have reached the end of the path
                if (currentWaypoint + 1 < path.vectorPath.Count) {
                    currentWaypoint++;
                } else {
                    // Set a status variable to indicate that the agent has reached the end of the path.
                    // You can use this to trigger some special code if your game requires that.
                    reachedEndOfPath = true;
                    break;
                }
            } else {
                break;
            }
        }

        var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint/nextWaypointDistance) : 1f;

        // Normalize.
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;

        Vector3 velocity = dir * speed * speedFactor;

        transform.position += velocity * Time.deltaTime;

        

        
    } 

    public void OnDisable () {
        seeker.pathCallback -= OnPathComplete;
    }
}