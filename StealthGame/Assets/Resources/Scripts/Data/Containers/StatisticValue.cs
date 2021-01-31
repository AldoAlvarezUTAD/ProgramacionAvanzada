using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD.Data.Container
{
	[CreateAssetMenu(fileName = "New Stat", menuName = "Data/Stats/Regular", order = 1)]
	public class StatisticValue : ScriptableObject
	{
		#region VARIABLES
		public int MaxValue = 10;

		public int InitialLevel = 1;
		public int MaxLevel = 1;

		[Tooltip("Sets the value to its maximum value possible when upgraded.")]
		public bool MaximizeOnUpgrade = false;
		[Range(1, 20), Tooltip("The value at which the stat value will be incresed when upgraded.")]
		public int ValueUpgrade = 1;
		#endregion
	}
}