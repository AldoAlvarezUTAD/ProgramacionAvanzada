using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD.Data.Container
{
	[CreateAssetMenu(fileName = "New Upgradable Stat", menuName = "Data/Stats/Upgradable", order = 2)]
	public class UpgradableMaxStat : StatisticValue
	{
		#region VARIABLES
		[Space, Tooltip("Allows for the max value to be be upgraded as well")]
		public bool ModifyMaxValOnUpgrade = false;
		[Range(1, 100), Tooltip("The value at which the maximum value will be modified when upgraded.")]
		public int MaxValueUpgrade = 1;
		#endregion
	}
}