using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UTAD.Interfaces;

namespace UTAD
{
	public class HidingSpot : MonoBehaviour, IRestartable
	{
		#region UNITY METHODS
		private void Awake()
		{
			GameManager.Instance.OnRestart -= Restart;
			GameManager.Instance.OnRestart += Restart;
		}
		private void Update()
		{
			if (!hasPlayer) return;
			if (Input.GetKeyDown(KeyCode.E))
				LeaveHiding();
		}
		#endregion

		#region VARIABLES
		[Header("Player")]
		[SerializeField]
		private Collider PlayerCollider = null;
		[SerializeField]
		private Rigidbody PlayerRigidBody = null;
		[Header("Hiding spot")]
		[SerializeField]
		private Camera hidingCamera = null;
		[SerializeField]
		private Transform cameraPosition = null;
		[SerializeField]
		private Transform playerLeavePosition = null;
		[Header("Anim Controller")]
		[SerializeField]
		private AnimationsSync Exit;
		[Space]
		[SerializeField]
		private UnityEvent OnLeaveHiding, OnRestart;


		private bool hasPlayer = false;
		#endregion

		#region PUBLIC METHODS
		public void Restart() 
		{
			OnRestart?.Invoke();
			if (!hasPlayer) return;
			SetCameraDepth(-10);
			SetPlayerState(true);
		}
		public void HidePlayer()
		{
			if (hasPlayer) return;
			SetCameraDepth(10);
			SetObjectPosition(hidingCamera.transform, cameraPosition);
			SetPlayerState(false);
			hasPlayer = true;
		}
		public void ShowPlayer() 
		{
			if (!hasPlayer) return;

			SetCameraDepth(-10);
			SetObjectPosition(Player.Instance.transform, playerLeavePosition);
			SetPlayerState(true);
			hasPlayer = false;
		}
		#endregion

		#region PRIVATE METHODS
		private void SetPlayerState(bool state) 
		{
			PlayerCollider.enabled = state;
			PlayerRigidBody.useGravity = state;
			PlayerRigidBody.isKinematic = !state;
		}
		private void SetObjectPosition(Transform obj, Transform point) 
		{
			if (obj == null || point == null) return;
			obj.position = point.position;
			obj.rotation = point.rotation;
		}
		private void LeaveHiding() 
		{
			OnLeaveHiding?.Invoke();
			Exit.Play();
		}
		private void SetCameraDepth(float value) => hidingCamera.depth = value;
		#endregion
	}
}