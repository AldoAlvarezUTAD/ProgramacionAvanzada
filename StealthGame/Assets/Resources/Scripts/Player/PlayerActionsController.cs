using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTAD.Enums;
using UTAD.Interfaces;

namespace UTAD
{
	[DisallowMultipleComponent]
	public class PlayerActionsController : MonoBehaviour, IRestartable
	{
        #region UNITY METHODS
        private void Awake()
        {
            GameManager.Instance.OnRestart += Restart;
        }
        #endregion

        #region VARIABLES
        private PlayerActions allowedActions = PlayerActions.MOVE | PlayerActions.ROTATE | PlayerActions.INTERACT | PlayerActions.ATTACk;		
		#endregion
		
		#region PUBLIC METHODS
		public void EnableActions(params PlayerActions[] actions)
		{
			foreach (PlayerActions action in actions) 
				if (isValidAction(action))
					allowedActions |= action;
		}

		public void DisableActions(params PlayerActions[] actions) 
		{
			foreach (PlayerActions action in actions)
				if (isValidAction(action))
					allowedActions &= ~action;
		}

		public bool CanDo(params PlayerActions[] actions) 
		{
			foreach (PlayerActions action in actions)
				if (!allowedActions.HasFlag(action)) 
					return false;
			return true;
		}

		public void Restart()
		{
            allowedActions = PlayerActions.MOVE | PlayerActions.ROTATE | PlayerActions.INTERACT | PlayerActions.ATTACk;
        }
		#endregion

		#region PRIVATE METHODS
		private bool isValidAction(PlayerActions action)
		{
			int counter = (int)PlayerActions.counter;
			int a = (int)action;
			return (a >= 0) && (a < counter);
		}
		#endregion
	}
}