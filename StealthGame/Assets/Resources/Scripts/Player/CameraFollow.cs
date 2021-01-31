using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD
{
	public class CameraFollow : MonoBehaviour
	{
		#region UNITY METHODS
		private void Update()
		{
			switch (GameManager.GameState)
			{
				case Enums.GameStates.IN_GAME:
					transform.position = position.position;
					return;
				default: return;
			}
		}
		private void LateUpdate()
		{
			transform.LookAt(lookTarget);
		}
		#endregion

		#region VARIABLES
		[SerializeField]
		private Transform lookTarget;
		[SerializeField]
		private Transform position;
		#endregion
	
	}
}