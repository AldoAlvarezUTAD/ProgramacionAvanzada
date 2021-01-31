using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTAD.Data.Container;

namespace UTAD.Data.Reader
{
	[Serializable]
	public class CharacterStat
	{
		#region VARIABLES
		public int value { get; protected set; } = 0;
		public int maxValue { get; protected set; } = 0;
		public int level { get; protected set; } = 0;

		public int initialLevel { get; private set; } = 1;
		public int maxLevel { get; private set; } = 10;

		public bool maximizeOnUpgrade { get; private set; } = false;
		public int valueUpgrade { get; private set; } = 0;

		public bool modifyMaxValOnUpgrade { get; private set; } = false;
		public int maxValueUpgrade { get; private set; } = 0;
		#endregion

		#region PUBLIC METHODS
		public void Upgrade() 
		{
			if (level >= maxLevel) return;

			++level;
			value += valueUpgrade;
			ModifyMaxValue();
			RestoreStat();
		}

		public void Modify(int modifierValue)
		{
			value += modifierValue;
			CheckValueLimits();
		}
        #region loaders
        public void Load(SerializableStat stat)
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
		public void Load(StatisticValue stat)
		{
			ResetStatsData();
			LoadbaseData(stat);
		}
		public void LoadUpgradable(UpgradableMaxStat stat)
		{
			Load(stat);
			LoadUpgradeData(stat);
		}
        #endregion
        #endregion

        #region PROTECTED METHODS
        //Ejemplo: si el valor a aumentar depende del nivel del player, aqui se modificará
        protected virtual int GetUpgradeRateValue() => maxValueUpgrade;
        #endregion

        #region PRIVATE METHODS
        private void LoadbaseData(StatisticValue stat) 
		{
			if (stat.Equals(null)) return;

			maxValue = stat.MaxValue;
			initialLevel = stat.InitialLevel;
			maxLevel = stat.MaxLevel;
			maximizeOnUpgrade = stat.MaximizeOnUpgrade;
			valueUpgrade = stat.ValueUpgrade;

			level = initialLevel;
			value = stat.MaxValue;
		}
		private void LoadUpgradeData(UpgradableMaxStat stat) 
		{
			if (stat.Equals(null)) return;
			modifyMaxValOnUpgrade = stat.ModifyMaxValOnUpgrade;
			maxValueUpgrade = stat.MaxValueUpgrade;
		}

		private void ModifyMaxValue() 
		{
			if (!modifyMaxValOnUpgrade) return;
			maxValue += GetUpgradeRateValue();
		}
		private void RestoreStat()
		{
			if (!maximizeOnUpgrade) return;
			value = maxValue;
		}

		private void CheckValueLimits() 
		{
			if (value > maxValue) value = maxValue;
			else if (value < 0) value = 0;
		}
		private void ResetStatsData() 
		{
			value = 0;
			maxValue = 0;
			maximizeOnUpgrade = false;
			modifyMaxValOnUpgrade = false;
			valueUpgrade = 0;
			maxValueUpgrade = 0;
		}
        #endregion


        #region OPERATOR OVERLOAD
        public static CharacterStat operator +(CharacterStat stat, int value) { stat.Modify(value); return stat; }
		public static CharacterStat operator +(CharacterStat stat, float value) { stat.Modify(Mathf.FloorToInt(value)); return stat; }

		public static CharacterStat operator -(CharacterStat stat, int value) { stat.Modify(value); return stat; }
		public static CharacterStat operator -(CharacterStat stat, float value) { stat.Modify(Mathf.FloorToInt(value)); return stat; }

		public static CharacterStat operator *(CharacterStat stat, int value) { stat.Modify(value); return stat; }
		public static CharacterStat operator *(CharacterStat stat, float value) { stat.Modify(Mathf.FloorToInt(value)); return stat; }

		public static CharacterStat operator /(CharacterStat stat, int value) { stat.Modify(value); return stat; }
		public static CharacterStat operator /(CharacterStat stat, float value) { stat.Modify(Mathf.FloorToInt(value)); return stat; }

		public static bool operator <(CharacterStat stat, int value) => stat.value < value;
		public static bool operator <(CharacterStat stat, float value) => stat.value < Mathf.FloorToInt(value);
		public static bool operator <(CharacterStat stat, CharacterStat stat2) => stat.value < stat2.value;

		public static bool operator >(CharacterStat stat, int value) => stat.value > value;
		public static bool operator >(CharacterStat stat, float value) => stat.value > Mathf.FloorToInt(value);
		public static bool operator >(CharacterStat stat, CharacterStat stat2) => stat.value > stat2.value;

		public static bool operator <=(CharacterStat stat, int value) => stat.value <= value;
		public static bool operator <=(CharacterStat stat, float value) => stat.value <= Mathf.FloorToInt(value);
		public static bool operator <=(CharacterStat stat, CharacterStat stat2) => stat.value <= stat2.value;

		public static bool operator >=(CharacterStat stat, int value) => stat.value >= value;
		public static bool operator >=(CharacterStat stat, float value) => stat.value >= Mathf.FloorToInt(value);
		public static bool operator >=(CharacterStat stat, CharacterStat stat2) => stat.value >= stat2.value;
		#endregion
	}
}