using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace UTAD.General
{
	public static class FilesController 
	{
		private static string FilesFolderPath = "SavedData";
		#region PUBLIC METHODS
		public static void CreateJSON(object obj, string fileName)
		{
#if UNITY_EDITOR
			CreateFolderPath();
			string fileContent = JsonUtility.ToJson(obj);
			string path = GetFolderPath() + "/" + fileName;
			File.WriteAllText(path, fileContent);
#endif
		}

		public static T Load<T>(string fileName) where T:new()
		{
			try {
				string path = GetFolderPath() + "/" + fileName;
				string fileContent = File.ReadAllText(path);
				return JsonUtility.FromJson<T>(fileContent);
			}
			catch (System.Exception) { return new T(); }
		}
		#endregion

		#region PRIVATE METHODS
		private static void CreateFolderPath() 
		{
			if (Directory.Exists(GetFolderPath())) return;
			Directory.CreateDirectory(GetFolderPath());
		}
		private static string GetFolderPath() => Application.dataPath + "/" + FilesFolderPath;
		
		#endregion
	}
}