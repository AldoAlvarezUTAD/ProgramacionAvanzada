using UTAD.Data.Reader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD
{
	[System.Serializable]
	public class SerializableStat 
	{
		public SerializableStat() { }
		public SerializableStat(CharacterStat stat)
		{
			value = stat.value;
			maxValue = stat.maxValue;
			level = stat.level;

			initialLevel = stat.initialLevel;
			maxLevel = stat.maxLevel;

			maximizeOnUpgrade = stat.maximizeOnUpgrade;
			valueUpgrade = stat.valueUpgrade;

			modifyMaxValOnUpgrade = stat.modifyMaxValOnUpgrade;
			maxValueUpgrade = stat.maxValueUpgrade;
		}

		#region VARIABLES
		public int value = 0;
		public int maxValue = 0;
		public int level = 0;

		public int initialLevel = 1;
		public int maxLevel = 10;

		public bool maximizeOnUpgrade = false;
		public int valueUpgrade = 0;

		public bool modifyMaxValOnUpgrade = false;
		public int maxValueUpgrade = 0;
		#endregion

	}
}