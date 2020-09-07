using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// De path class beheerd een array van waypoints. En houd bij bij welk waypoint een object is.
    /// Deze vormen samen het pad. 
    /// Logica die op het path niveau plaatsvindt gebeurt in deze class.
    /// Een deel van de functies welke je nodig hebt zijn hier al beschreven.
    /// </summary>
    public class Path : MonoBehaviour
    {
        [SerializeField] private List<Waypoint> moveTo = new List<Waypoint>();
        private int currentWayPoint = -1;

        /// <summary>
        /// Deze functie returned het volgende waypoint waar naartoe kan worden bewogen.
        /// </summary>
        public Waypoint GetNextWaypoint()
        {
            currentWayPoint += 1;
            if (currentWayPoint + 1 > moveTo.Count) return null;
            // dit is nu niet goed, zorg ervoor dat het goede waypoint wordt teruggegeven.
            return moveTo[currentWayPoint];
        }

        public Waypoint getCurrentWaypoints()
        {
            if (currentWayPoint > moveTo.Count) return null;
            return moveTo[currentWayPoint];
        }
    }