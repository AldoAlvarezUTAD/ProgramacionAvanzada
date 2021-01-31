using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTAD.Data.Container;
using UTAD.Data.Reader;
using UTAD.General;


namespace UTAD.PlayerData.Support
{
	[System.Serializable]
	public class PlayerStat
	{
		public PlayerStat(string id) 
		{
			ID = id;
		}

		#region VARIABLES
		[SerializeField] private UpgradableMaxStat upgradableStat;

		public CharacterStat Stat { get; private set; }

		private string ID = "defaultName";
		#endregion

		#region PUBLIC METHODS
		public void Save()
		{
			SerializableStat stat = new SerializableStat(Stat);
			FilesController.CreateJSON(stat, ID);
		}
		public void LoadSave() 
		{
			SerializableStat stat = FilesController.Load<SerializableStat>(ID);
			Stat.Load(stat);
		}
		public void LoadAnew() 
		{
			Stat.Load(upgradableStat);
		}
		#endregion
		
		#region PRIVATE METHODS
		private void method()
		{
			
		}
		#endregion
	}
}