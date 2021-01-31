using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AGAC.General;

namespace UTAD
{
	[DisallowMultipleComponent]
	public class SingletonObject<T> : MonoBehaviour where T : Behaviour
	{
		#region VARIABLES
		protected static T instance = null;
		public static T Instance => GetInstance();
		#endregion

		#region PRIVATE METHODS
		private static T GetInstance()
		{
			//if (instance.Equals(null))
			if (instance == null)
				instance = GeneralMethods.GetInstance<T>(string.Empty);
			return instance;
		}
		#endregion
	}
}