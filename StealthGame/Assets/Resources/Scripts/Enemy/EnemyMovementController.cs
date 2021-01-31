using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD.Enemies
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MovableObject))]
    [RequireComponent(typeof(EnemyAnimController))]
	public class EnemyMovementController : MonoBehaviour
	{
		#region UNITY METHODS
		private void Awake()
		{
            animCtrl = GetComponent<EnemyAnimController>();
            movable = GetComponent<MovableObject>();

            if (waypointsParent != null)
            {
                int childCount = waypointsParent.childCount;
                ResizeWaypointList(childCount);

                for (int child = 0; child < childCount; ++child)
                    if(waypoints[child].targetPoint==null)
                    waypoints[child].targetPoint = waypointsParent.GetChild(child);
            }
		}

		private void FixedUpdate()
		{
            if (waitTime <= 0f) return;
            switch (GameManager.GameState)
            {
                case Enums.GameStates.IN_GAME:
                    waitTime -= Time.fixedDeltaTime;
                    break;
            }
		}
        #endregion

        #region VARIABLES
        [SerializeField, Range(0.01f, 1f)]
        [Tooltip("The minimum acceptable distance from this object to the waypoint before changing its destination.")]
        private float acceptableDistance = 0.1f;
        [SerializeField]
        private Transform waypointsParent = null;
        [SerializeField]
        private List<Waypoint> waypoints = new List<Waypoint>();

        private float waitTime = 0f;
        private int currentWaypoint = 0;
        private Transform destination;
        private EnemyAnimController animCtrl;
        private MovableObject movable;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            currentWaypoint = 0;
            PlaceOn(waypoints[currentWaypoint].targetPoint);
            waitTime = waypoints[currentWaypoint].WaitTime;
            ChangeWaypoint();
            animCtrl.SetMovementAnimation(0f);
        }
        public void MoveToDestination()
        {
            if (waitTime > 0) return;

            if (GetDistanceXZ(transform, destination) > acceptableDistance)
            {
                movable.MoveTo(destination);
                animCtrl.SetMovementAnimation(1f);
                transform.LookAt(destination);
            }
            else
            {
                animCtrl.SetMovementAnimation(0f);
                waitTime = waypoints[currentWaypoint].WaitTime;
                ChangeWaypoint();
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void PlaceOn(Transform point)
        {
            transform.position = point.position;
            transform.rotation = point.rotation;
        }
        private void ChangeWaypoint()
        {
            if (++currentWaypoint >= waypoints.Count)
                currentWaypoint = 0;
            destination = waypoints[currentWaypoint].targetPoint;
        }

        private float GetDistanceXZ(Transform a, Transform b)
        {
            Vector2 aPos = GetVectorXZ(a.position);
            Vector2 bPos = GetVectorXZ(b.position);
            return Vector2.Distance(aPos, bPos);
        }
        private Vector2 GetVectorXZ(Vector3 vec) => new Vector2(vec.x, vec.z);

        private void ResizeWaypointList(int totalElements)
        {
            if (waypoints.Count == totalElements) return;

            while (waypoints.Count > totalElements)
                waypoints.RemoveAt(waypoints.Count - 1);
            while (waypoints.Count < totalElements)
                waypoints.Add(new Waypoint());
        }
		#endregion
	}
}