using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UTAD.Interfaces;

namespace UTAD
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]
	public class InterestPoint : MonoBehaviour, IRestartable
	{
		#region UNITY METHODS
		private void Awake()
		{
            GameManager.Instance.OnRestart += Restart;
		}

		private void OnTriggerEnter(Collider other)
		{
            if (other.CompareTag(otherTag))
                OnEnter?.Invoke();
		}
        #endregion

        #region VARIABLES
        [SerializeField]
        private string otherTag = "Player";
        [SerializeField]
        private UnityEvent OnEnter, OnRestart;
		#endregion
		
		#region PUBLIC METHODS
		public void Restart()
		{
            OnRestart?.Invoke();
        }
		#endregion
		
		#region PRIVATE METHODS
		private void method()
		{
			
		}
		#endregion
	}
}