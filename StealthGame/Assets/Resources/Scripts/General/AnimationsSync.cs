using AGAC.StandarizedTime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UTAD
{
	public class AnimationsSync : MonoBehaviour
	{
		#region UNITY METHODS
		private void Awake()
		{
			//SceneManager.Instance.OnLoad += ResetAnimations;
            GameManager.Instance.OnRestart -= ResetAnimations;
            GameManager.Instance.OnRestart += ResetAnimations;
			endAnimation = CheckForEndAnimation();
		}
		#endregion

		#region VARIABLES
		[SerializeField]
		private Animator[] animCtrls;
		[SerializeField]
		private string animParameter = "State";
		[SerializeField]
		private int parameterValue = -1;
        [SerializeField]
        private StandardTime animDuration = new StandardTime(0, 1, 0);
        [SerializeField]
        private Transform playerTrans;

		[SerializeField]
		private UnityEvent OnAnimEnd;

		private IEnumerator endAnimation;
		#endregion
		
		#region PUBLIC METHODS
		public void Play()
		{
			if (playerTrans != null)
			{
				Player.Instance.transform.position = playerTrans.position;
				Player.Instance.transform.rotation = playerTrans.rotation;
			}
			SetAnimSpeed(1f);
			SetAnimState(parameterValue);

            endAnimation = CheckForEndAnimation();
            StartCoroutine(endAnimation);
		}
		public void Pause()
		{
			SetAnimSpeed(0f);
		}
		#endregion

		#region PRIVATE METHODS
		private void ResetAnimations() 
		{
			SetAnimSpeed(1f);
			SetAnimState(-1);
			if (endAnimation != null) 
				StopCoroutine(endAnimation);
		}

		private IEnumerator CheckForEndAnimation() 
		{
			float animTime = animDuration.ToFloat();
			while (animTime > 0) 
			{
				animTime -= Time.fixedDeltaTime /** animCtrls[0].speed*/;
				yield return new WaitForFixedUpdate();
			}
            SetAnimState(-1);
			OnAnimEnd?.Invoke();
			Player.Instance.InputCtrl.ResetMovement();
        }
		private void SetAnimSpeed(float speed)
		{
			foreach (Animator ctrl in animCtrls)
				ctrl.speed = speed;
		}
		private void SetAnimState(int state) 
		{
			foreach (Animator ctrl in animCtrls)
				ctrl.SetInteger(animParameter, state);
		}
		#endregion
	}
}