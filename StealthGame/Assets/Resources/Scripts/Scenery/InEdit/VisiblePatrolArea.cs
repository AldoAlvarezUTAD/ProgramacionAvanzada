using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD
{
	public class VisiblePatrolArea : MonoBehaviour
	{
		#region UNITY METHODS
		private void OnDrawGizmosSelected()
		{
			VisibleWaypoint[] waypoints = GetComponentsInChildren<VisibleWaypoint>();
			foreach (VisibleWaypoint waypoint in waypoints)
				waypoint.DrawAsSelected(Color.blue);
		}
		#endregion
	}
}