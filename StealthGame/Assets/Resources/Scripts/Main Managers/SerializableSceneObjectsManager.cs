using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UTAD
{
	//TODO: Implementar sistema de guardado
	//sobre scene objects manager y que se agreguen solo en el editor los objetos, los estados se guardaran y recuperaran de un
	//scriptable object inamobible de tamaño ni identificadores
	[System.Serializable]
	public sealed class SerializableSceneObjectsManager 
	{
		public SerializableSceneObjectsManager() { }
		public SerializableSceneObjectsManager(Dictionary<int, bool> objects) 
		{
			int totalKeys = objects.Keys.Count;
			ObjectsIDs = new int[totalKeys];
			ObjectsState = new bool[totalKeys];


			int i = 0;
			foreach (var obj in objects) 
			{
				ObjectsIDs[i] = obj.Key;
				ObjectsState[i] = obj.Value;
				++i;
			}
		}

		#region VARIABLES
		public int[] ObjectsIDs = null;
		public bool[] ObjectsState = null;		
		#endregion

		public Dictionary<int, bool> GetDictionary() 
		{
			if (ObjectsIDs.Equals(null) || ObjectsState.Equals(null)) return null;
			if (ObjectsIDs.Length != ObjectsState.Length) return null;
			Dictionary<int, bool> objects = new Dictionary<int, bool>();
			for (int i = 0; i < ObjectsIDs.Length; ++i)
			{
				objects.Add(ObjectsIDs[i], ObjectsState[i]);
			}
			return objects;
		}
	}
}