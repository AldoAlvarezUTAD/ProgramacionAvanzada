using UTAD.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTAD.Enums;

namespace UTAD
{
	public class PlayerMovementCtrl : MonoBehaviour
	{
		#region UNITY METHODS
		private void Start()
		{
			movementCtrl = GetComponent<IMovable>();
			rotationCtrl = GetComponent<IRotatable>();
		}
		#endregion

		#region VARIABLES
		[SerializeField]
		private Transform mainCam;

		private IMovable movementCtrl;
		private IRotatable rotationCtrl;

		#endregion

		#region PUBLIC METHODS
		public void Move(float speedInput)
		{
			float moveSpeed = speedInput * GetSpeedModifier();
			movementCtrl.Move(mainCam.forward * moveSpeed);
		}
		public void TurnAround() 
		{
			transform.Rotate(Vector3.up * 180);
			mainCam.Rotate(Vector3.up * 180);
		}
		public void Rotate(float rotationInput)
		{
			float input = Mathf.Abs(rotationInput);
			ObjectSelfDirection direction = ObjectSelfDirection.RIGHT;
			if (rotationInput < 0.1f)
				direction = ObjectSelfDirection.LEFT;

			rotationCtrl.Rotate(direction, input);
		}
		#endregion
		
		#region PRIVATE METHODS
		private float GetSpeedModifier()
		{
			switch (Player.Instance.Visibility) 
			{
				case PlayerVisibility.HIDDEN:return 0;
				case PlayerVisibility.CROUCH:return 0.4f;
				case PlayerVisibility.STAND_UP:return 1f;
				default:return 0;
			}
		}
		#endregion
	}
}