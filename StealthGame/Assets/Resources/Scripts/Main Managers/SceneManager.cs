using AGAC.General;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD
{
	[RequireComponent(typeof(SceneObjectsManager))]
	public class SceneManager : SingletonObject<SceneManager>
	{
		#region UNITY METHODS
		private void Start()
		{
			
		}

		private void Update()
		{
			
		}
		#endregion

		#region VARIABLES
		private SceneObjectsManager objectsManager;
		private SceneObjectsManager ObjectsManager 
		{
			get 
			{
				if (objectsManager.Equals(null))
					objectsManager = GetComponent<SceneObjectsManager>();
				return objectsManager;
			}
		}

		public event Action OnLoad;
		public event Action OnSave;
		#endregion
		
		#region PUBLIC METHODS
		public void Load()
		{
			OnLoad?.Invoke();
		}
		public void AddObjectToSave(SceneryItem obj) => ObjectsManager.AddObject(obj);
		public bool GetObjectState(SceneryItem obj) => objectsManager[obj.GetInstanceID()];

		public void Save() 
		{

		}
		#endregion
		
		#region PRIVATE METHODS
		private void method()
		{
			
		}
		#endregion
	}
}