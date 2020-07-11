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
    }

    public Animator animator;

    private Vector3 movement;
    private Vector3 axis;

    void Update()
    {   
        
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
    } 
}