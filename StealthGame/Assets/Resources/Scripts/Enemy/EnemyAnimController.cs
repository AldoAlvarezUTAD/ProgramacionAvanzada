using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD.Enemies
{
	public class EnemyAnimController : MonoBehaviour
	{

        #region VARIABLES
        [SerializeField]
        private Animator animCtrl;

        #endregion

        #region PUBLIC METHODS
        public void SetMovementAnimation(float speed)
        {
            animCtrl.SetFloat("speed", speed);
        }
        #endregion
    
	}
}