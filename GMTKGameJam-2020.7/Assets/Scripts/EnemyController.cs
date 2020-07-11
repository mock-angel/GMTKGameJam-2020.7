using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pathfinding;

public class EnemyController : MonoBehaviourPooledObject
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
        seeker = GetComponent<Seeker>();

        destinationSetter.target = targetPosition;

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath(){
        seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
    }

    public void OnPathComplete (Path p) {
        Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

        if (!p.error) {
            path = p;
            // Reset the waypoint counter so that we start to move towards the first point in the path
            currentWaypoint = 0;
        }
    }

    public Animator animator;

    private Vector3 movement;
    private Vector3 axis;

    void Update()
    {   
        if (path == null) {
            // We have no path to follow yet, so don't do anything
            return;
        }
        print("hello there");
        // Check in a loop if we are close enough to the current waypoint to switch to the next one.
        // We do this in a loop because many waypoints might be close to each other and we may reach
        // several of them in the same frame.
        reachedEndOfPath = false;
        // The distance to the next waypoint in the path
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

        // Direction to the next waypoint
        // Normalize it so that it has a length of 1 world unit
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;

        Vector3 velocity = dir * speed * speedFactor;

        transform.position += velocity * Time.deltaTime;


        //Animation
        movement.x = axis.x = dir.x;
        movement.y = axis.y = dir.y;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Mathf.Abs(axis.x) == 1 && Mathf.Abs(axis.y) == 1)
        {
            movement.x = Mathf.Sqrt(0.5f) * axis.x;
            movement.y = Mathf.Sqrt(0.5f) * axis.y;
        }
    } 

}