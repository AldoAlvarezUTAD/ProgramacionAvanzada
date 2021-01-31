using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AGAC.StandarizedTime;

namespace UTAD
{
	public class GameUI : MonoBehaviour
	{
        #region VARIABLES
        [SerializeField]
        private TMP_Text scoreText;
        [SerializeField]
        private TMP_Text timeText;
        [SerializeField]
        private TMP_Text collectibleText;
        #endregion

        #region PUBLIC METHODS
        public void SetScore(float score) => SetUI(scoreText, score.ToString());
        public void SetTime(StandardTime time) => SetUI(timeText, time.ToString());
        public void SetCollectibles(int total) => SetUI(collectibleText, total.ToString());
        #endregion

        #region PRIVATE METHODS
        private void SetUI(TMP_Text text, string value) {
            if (text == null) return;
            text.text = value;
        }
		#endregion
	}
}