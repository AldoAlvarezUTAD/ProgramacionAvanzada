using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTAD.Enums;

namespace UTAD
{
	[DisallowMultipleComponent]
	public  sealed class PlayerActionsHelper : MonoBehaviour
	{
		#region VARIABLES
		[SerializeField]
		private PlayerActions ActionToAllow = PlayerActions.MOVE;
		[SerializeField]
		private PlayerActions ActionToImpede = PlayerActions.MOVE;
		#endregion

		#region PUBLIC METHODS
		public void Impedections()
		{
			Player.Instance.ActionsCtrl.DisableActions(ActionToImpede);
		}
		public void AllowActions() 
		{ 
			Player.Instance.ActionsCtrl.EnableActions(ActionToAllow);
		}
		#endregion
	}
}