using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTAD.PlayerData;
using UTAD.Enums;
using UTAD.Interfaces;

namespace UTAD
{
	[RequireComponent(typeof(PlayerActionsController))]
	[RequireComponent(typeof(PlayerInputCtrl))]
	[RequireComponent(typeof(PlayerAnimCtrl))]
	[RequireComponent(typeof(PlayerMovementCtrl))]
	public class Player : SingletonObject<Player>, IRestartable
	{
		#region UNITY METHODS
		private void Awake()
		{
			animCtrl = GetComponent<PlayerAnimCtrl>();
			InputCtrl = GetComponent<PlayerInputCtrl>();
			movementCtrl = GetComponent<PlayerMovementCtrl>();
            ActionsCtrl = GetComponent<PlayerActionsController>();
            GameManager.instance.OnRestart += Restart;
		}
		#endregion

		#region VARIABLES
		public PlayerStats Stats => stats;
		[SerializeField]
		private PlayerStats stats = new PlayerStats();
		public PlayerVisibility Visibility { get; private set; } = PlayerVisibility.STAND_UP;

		public PlayerActionsController ActionsCtrl { get; protected set; } = null;
		public PlayerInputCtrl InputCtrl { get; protected set; } = null;

		private PlayerAnimCtrl animCtrl;
		private PlayerMovementCtrl movementCtrl;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            Visibility = PlayerVisibility.STAND_UP;
			animCtrl.SetMovementAnimation(0);
		}

		public void SetPosition(Transform point)
        {
            transform.position = point.position;
            transform.rotation = point.rotation;
        }
		public void UpgradeStat(PlayerStatsIDs stat)
		{
			stats[stat].Upgrade();
		}
		public void SetVisibility(PlayerVisibility visibility)
		{
			this.Visibility = visibility;
			animCtrl.SetVisibilityState(visibility);
		}
		public void Move(float input) 
		{
			if (!ActionsCtrl.CanDo(PlayerActions.MOVE)) return;
			movementCtrl.Move(input);
			animCtrl.SetMovementAnimation(input);
		}
		public void TurnAround() 
		{
			if (!ActionsCtrl.CanDo(PlayerActions.MOVE)) return;
			movementCtrl.TurnAround();
		}
		public void Rotate(float input) 
		{
			if (!ActionsCtrl.CanDo(PlayerActions.ROTATE)) return;
			movementCtrl.Rotate(input);
		}
		#endregion
		
		#region PRIVATE METHODS
		private void method()
		{
			
		}
		#endregion
	}
}