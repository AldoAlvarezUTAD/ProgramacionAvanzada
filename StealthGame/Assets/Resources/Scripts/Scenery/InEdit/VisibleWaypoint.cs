using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD
{
	public class VisibleWaypoint : MonoBehaviour
	{
		#region UNITY METHODS
#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			Color gizmos = Gizmos.color;
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, WireSphereRange);
			Gizmos.color = gizmos;
		}
#endif
		#endregion

		#region VARIABLES
		[SerializeField, Range(0, 2)]
		private float WireSphereRange = 1;
		#endregion

		public void DrawAsSelected(Color color) 
		{
#if UNITY_EDITOR
			Color gizmos = Gizmos.color;
			Gizmos.color = color;
			Gizmos.DrawSphere(transform.position, WireSphereRange*1.2f);
			Gizmos.color = gizmos;
#endif
		}
	}
}