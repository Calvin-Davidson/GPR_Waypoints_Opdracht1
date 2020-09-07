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
    [SerializeField] private Path _path;
    private Vector3 startPos;

    private Waypoint _currentWaypoints;
    

    void Start()
    {
        _currentWaypoints = _path.GetNextWaypoint();
        startPos = transform.position;
    }

 
    void Update()
    {
        if (_currentWaypoints == null)
        {
            print("Einde van het path bereikd");
            this.enabled = false;
            return;
        }

        Vector3 targetPos = _path.getCurrentWaypoints().Position;

        transform.position = Vector3.MoveTowards(transform.position, targetPos,
            5 * Time.deltaTime);

        if (transform.position == targetPos)
        {
            float dist = Vector3.Distance(startPos, transform.position);
            print("Ik ben er!, de afstand was: " + dist + " 5 meter");

            startPos = transform.position;

            _currentWaypoints = _path.GetNextWaypoint();
        }
    }
}