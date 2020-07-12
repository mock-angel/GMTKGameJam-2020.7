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

        destinationSetter.target = targetPosition;

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath(){
        seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
    }

    public void OnPathComplete (Path p) {
        Debug.Log("A path was calculated. " + p.error);

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


        reachedEndOfPath = false;

        float distanceToWaypoint;
        while (true) {

            distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distanceToWaypoint < nextWaypointDistance) {

                if (currentWaypoint + 1 < path.vectorPath.Count) {
                    currentWaypoint++;
                } else {
                    reachedEndOfPath = true;
                    break;
                }
            } else {
                break;
            }
        }

        var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint/nextWaypointDistance) : 1f;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;

        Vector3 velocity = dir * speed * speedFactor;

        transform.position += velocity * Time.deltaTime;


        //Animation
        movement.x = axis.x = dir.x;
        movement.y = axis.y = dir.y;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Mathf.Abs(axis.x) == 1 && Mathf.Abs(axis.y) == 1)
        {
            movement.x = Mathf.Sqrt(0.5f) * axis.x;
            movement.y = Mathf.Sqrt(0.5f) * axis.y;
        }

        
    } 

}