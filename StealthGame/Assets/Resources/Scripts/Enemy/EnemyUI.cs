using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UTAD
{
	public class EnemyUI : MonoBehaviour
	{
		#region UNITY METHODS
		private void Awake()
		{
            int totalRanges = awarenessColors.Length - 1;
            float rangeSize = 100 / (totalRanges+1);
            awarenessRanges = new float[totalRanges];
            for (int range = 0; range < totalRanges; ++range)
                awarenessRanges[range] = (range + 1) * rangeSize;
		}
        #endregion

        #region VARIABLES
        [SerializeField] private Color[] awarenessColors = new Color[3];
        [SerializeField] private Image awarenessIcon = null;
        private float []awarenessRanges;
		#endregion
		
		#region PUBLIC METHODS
		public void UpdateAwareness(float awareness)
		{
            if (awarenessIcon == null) return;
            awarenessIcon.fillAmount = awareness / 100;
            awarenessIcon.color = GetAwarenessColor(awareness);
		}
		#endregion
		
		#region PRIVATE METHODS
		private Color GetAwarenessColor(float awareness)
		{
            awareness = Mathf.Clamp(awareness, 0, 100);
            for (int range = 0; range < awarenessRanges.Length; ++range)
                if (awareness < awarenessRanges[range])
                    return awarenessColors[range];
            return awarenessColors[awarenessRanges.Length];
        }
        #endregion
    }
}