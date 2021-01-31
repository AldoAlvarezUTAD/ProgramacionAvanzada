using UTAD.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD
{
	[DisallowMultipleComponent]
	public class PlayerAnimCtrl : MonoBehaviour
	{
		#region VARIABLES
		[SerializeField]
		private Animator animCtrl;

        #endregion

        #region PUBLIC METHODS
		public void SetVisibilityState(PlayerVisibility visibility)
		{
			animCtrl.SetInteger("Visibility", (int)visibility);
		}
		public void SetMovementAnimation(float movementInput) 
		{
			animCtrl.SetFloat("speedInput", movementInput);
		}
		#endregion
	
	}
}