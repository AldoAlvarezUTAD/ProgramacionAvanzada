using AGAC.General;
using UTAD.General;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD
{
	[RequireComponent(typeof(SceneManager))]

	public class SceneObjectsManager : MonoBehaviour
	{
		#region VARIABLES
		private Dictionary<int, bool> sceneObjects = new Dictionary<int, bool>();

		public bool this[int id] =>GetObjectState(id);
		#endregion

		#region PUBLIC METHODS
		public void AddObject(ActivableObject obj)
		{
			int id = obj.GetInstanceID();
			if (sceneObjects.ContainsKey(id)) sceneObjects[id] = obj.Active;
			else sceneObjects.Add(id, obj.Active);
		}
		public void Save() 
		{
			SerializableSceneObjectsManager objects = new SerializableSceneObjectsManager(sceneObjects);
			FilesController.CreateJSON(objects, FileNames.SceneObjectsFile);
		}
		public void Load() 
		{

		}
		#endregion
		
		#region PRIVATE METHODS
		private bool GetObjectState(int id)
		{
			if (!sceneObjects.ContainsKey(id)) return false;
			return sceneObjects[id];
		}
		#endregion
	}
}