using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// De path follower class is verantwoordelijk voor de beweging.
/// Deze class zorgt ervoor dat het object (in Tower Defense) vaak een enemy, het path afloopt
/// tip: je kunt de transform.LookAt() functie gebruiken en vooruitbewegen.
/// </summary>
public class PathFollower : MonoBehaviour
{
    [SerializeField] private List<Waypoint> moveTo = new List<Waypoint>();
    private int currentTarget = 0;
    private Vector3 startPos;

    void Start()
    {
        if (moveTo.Count == 0)
        {
            this.enabled = false;
            print("Er is geen route, Ik stop met!");
        }
        startPos = transform.position;
    }

 
    void Update()
    {
        Vector3 targetPos = moveTo[currentTarget].Position;

        transform.position = Vector3.MoveTowards(transform.position, targetPos,
            5 * Time.deltaTime);

        if (transform.position == targetPos)
        {
            float dist = Vector3.Distance(startPos, transform.position);
            print("Ik ben er!, de afstand was: " + dist + " 5 meter");

            currentTarget += 1;
            if (currentTarget + 1 > moveTo.Count) currentTarget = 0;


            startPos = transform.position;
        }
    }
}