using UTAD.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD
{
	public class ControlledActionBehaviour : MonoBehaviour, IControlledAction
	{

		#region VARIABLES
		public bool isAllowed { protected set; get; } = true;
		#endregion

		#region PUBLIC METHODS
		public void AllowAction() => isAllowed = true;
		public void ImpedeAction() => isAllowed = false;
		#endregion
	}
}