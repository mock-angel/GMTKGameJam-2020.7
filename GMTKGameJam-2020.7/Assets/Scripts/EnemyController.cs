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

    Rigidbody2D rb;

    void Start(){

        destinationSetter.target = targetPosition;

        InvokeRepeating("UpdatePath", 0f, .5f);
        rb = GetComponent<Rigidbody2D>();
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

    void FixedUpdate()
    {   
        if (path == null) {
            // We have no path to follow yet, so don't do anything
            return;
        }
        
        if(currentWaypoint >= path.vectorPath.Count)
            reachedEndOfPath = true;
        else reachedEndOfPath = false;
        

        if(reachedEndOfPath) return;
        
        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        
        //transform.position = transform.position;

        rb.velocity = new Vector2(0, 0);
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
            currentWaypoint++;


        //Animation
        movement.x = axis.x = direction.x;
        movement.y = axis.y = direction.y;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Mathf.Abs(axis.x) == 1 && Mathf.Abs(axis.y) == 1)
        {
            movement.x = Mathf.Sqrt(0.5f) * axis.x;
            movement.y = Mathf.Sqrt(0.5f) * axis.y;
        }


        //reachedEndOfPath = false;
        return;

        //Method 2.

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

        Vector3 dir = (path.vectorPath[currentWaypoint] - (Vector3)transform.position).normalized;

        Vector3 velocity = dir * speed * speedFactor;

        transform.position += velocity * Time.deltaTime;
        
        //rb.MovePosition(rb.position + (Vector2)velocity * Time.deltaTime);


        
        
    } 

}