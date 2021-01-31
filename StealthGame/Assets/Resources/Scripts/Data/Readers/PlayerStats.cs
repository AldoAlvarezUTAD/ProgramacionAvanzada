using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTAD.Enums;
using UTAD.Data.Reader;
using UTAD.PlayerData.Support;

namespace UTAD.PlayerData
{
	[System.Serializable]
	public sealed class PlayerStats
	{
		public PlayerStats() 
		{
			CreatePlayerStats();
		}

		#region VARIABLES
		[SerializeField] private PlayerStat[] stats = null;

		public CharacterStat this[PlayerStatsIDs ID] => GetStatWithID(ID);

		[SerializeField] private bool foldout = true;
		#endregion

		#region PUBLIC METHODS
		public void LoadAnew()
		{
			foreach (PlayerStat stat in stats)
				stat.LoadAnew();
		}
		public void LoadSave() 
		{
			foreach (PlayerStat stat in stats)
				stat.LoadSave();
		}
		public void Save()
		{
			foreach (PlayerStat stat in stats)
				stat.Save();
		}
		#endregion

		#region PRIVATE METHODS
		private CharacterStat GetStatWithID(PlayerStatsIDs ID) 
		{
			int id = (int)ID;
			if (id < 0 || id > stats.Length) return null;
			return stats[id].Stat;
		}
		private void CreatePlayerStats() 
		{
			int total = (int)PlayerStatsIDs.counter;
			stats = new PlayerStat[total];
			for (int stat = 0; stat < total; ++stat) 
			{
				PlayerStatsIDs ID = (PlayerStatsIDs)stat;
				string fileName = GetStatFileName(ID);
				stats[stat] = new PlayerStat(fileName);
			}
		}
		private string GetStatFileName(PlayerStatsIDs ID) 
		{
			switch (ID) 
			{
				case PlayerStatsIDs.HEALTH:return FileNames.HealthFile;
				case PlayerStatsIDs.MANA:return FileNames.ManaFile;
				default:return string.Empty;
			}
		}
		#endregion
	}
}