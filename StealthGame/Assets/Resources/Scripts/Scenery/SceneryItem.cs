using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AGAC.General;

namespace UTAD
{
	[DisallowMultipleComponent]
	public class SceneryItem : ActivableObject
	{
		#region UNITY METHODS
		private void Start()
		{
			SceneManager.Instance.OnLoad += Restart;
			SceneManager.Instance.OnSave += Save;
		}
		#endregion

		#region PRIVATE METHODS
		private void Restart()
		{
			Deactivate();
			Active = SceneManager.Instance.GetObjectState(this);
			if (Active)
				Activate();
		}
		private void Save() 
		{
			SceneManager.Instance.AddObjectToSave(this);
		}
		#endregion
		
	}
}