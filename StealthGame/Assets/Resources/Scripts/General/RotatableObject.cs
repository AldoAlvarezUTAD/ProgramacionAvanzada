using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTAD.Interfaces;
using UTAD.Enums;

namespace UTAD
{
	public class RotatableObject : ControlledActionBehaviour, IRotatable
	{
		#region UNITY METHODS
		private void Awake()
		{
			trans = GetComponent<Transform>();
		}

		#endregion

		#region VARIABLES
		[SerializeField, Range(0.01f, 5f)]
		protected float rotationSpeed = 1f;

		protected uint rotationAngles = 60;
		private Transform trans = null;
		#endregion

		#region PUBLIC METHODS
		public void Rotate(ObjectSelfDirection direction, float speedMultiplier)
		{
			if (!isAllowed) return;
			Vector3 dir = GetRotationDirection(direction);
			float speed = rotationSpeed * rotationAngles * Time.deltaTime;
			trans.Rotate(dir * speed * speedMultiplier);
		}
		#endregion

		#region PRIVATE METHODS
		private Vector3 GetRotationDirection(ObjectSelfDirection direction)
		{
			switch (direction) 
			{
				case ObjectSelfDirection.RIGHT:return Vector3.up;
				case ObjectSelfDirection.LEFT:return Vector3.down;
				case ObjectSelfDirection.UP: return trans.right;
				case ObjectSelfDirection.DOWN: return trans.right * -1;
				default: return Vector3.zero;
			}
		}
		#endregion
	}
}