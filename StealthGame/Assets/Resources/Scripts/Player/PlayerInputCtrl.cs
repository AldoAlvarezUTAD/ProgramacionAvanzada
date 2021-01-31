using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTAD.Interfaces;
using UTAD.Enums;

namespace UTAD
{
	public class PlayerInputCtrl : MonoBehaviour, IRestartable
	{
        #region UNITY METHODS
        private void Awake()
        {
            GameManager.Instance.OnRestart += Restart;
        }
        private void Start()
		{
			Restart();
		}

		private void Update()
		{
			switch (GameManager.GameState)
			{
				case GameStates.IN_GAME:
					//CheckMouseInput();
					CheckDownInputs();
					CheckStayInput();
					CheckUpInputs();
					if (Input.GetKeyDown(KeyCode.Escape)) { 
						GameManager.Instance.PauseGame();
						return;
					}
					break;
				case GameStates.PAUSE:
					if (Input.GetKeyDown(KeyCode.Escape))
						GameManager.Instance.ResumeGame();
					return;
				default:return;
			}

			if (moving)
				Player.Instance.Move(speedInput);
			if (Mathf.Abs(rotationInput) > 0.1f)
				Player.Instance.Rotate(rotationInput);
		}
		private void FixedUpdate()
		{
			GetScreenWidth();
		}
		#endregion

		#region VARIABLES
		private bool moving = false;
		private float speedInput = 0f;

		private float rotationInput = 0f;
		private float ScreenWidth = 0f;
		private float halfScreen = 0f;
		#endregion

		#region PUBLIC METHODS
		public void Restart()
		{
			moving = false;
			rotationInput = 0f;
			speedInput = 0f;
			GetScreenWidth();
		}
		public void ResetMovement() 
		{
			moving = false;
			speedInput = 0f;
			Player.Instance.Move(0);
		}
		#endregion

		#region PRIVATE METHODS
		private void GetScreenWidth()
		{
			ScreenWidth = Screen.width;
			halfScreen = ScreenWidth / 2;
		}

		private void CheckDownInputs()
		{

            #region movement
            if (Input.GetKeyDown(KeyCode.W)) moving = true;
			else if (Input.GetKeyDown(KeyCode.S)) {
				Player.Instance.TurnAround();
				moving = true;
			}
            #endregion

            #region visibility
            if (Input.GetKeyDown(KeyCode.LeftControl)) 
			{
				Player.Instance.SetVisibility(PlayerVisibility.CROUCH);
			}
            #endregion
        }
		private void CheckStayInput() 
		{
			#region movement
			if (moving)
			{
				speedInput = 0.5f;
				if (Input.GetKey(KeyCode.LeftShift))
				{
					Player.Instance.SetVisibility(PlayerVisibility.STAND_UP);
					speedInput = 1f;
				}
				else if (Input.GetKey(KeyCode.LeftAlt)) speedInput = 0.25f;
			}
			else speedInput = 0f;
			#endregion

			if (Input.GetKey(KeyCode.D))
				rotationInput = 1f;
			else if (Input.GetKey(KeyCode.A))
				rotationInput = -1f;
		}

        private void CheckUpInputs() {

			if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
			{
				moving = false;
				Player.Instance.Move(0);
			}
			if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
			{
				rotationInput = 0f;
			}
			if (Input.GetKeyUp(KeyCode.LeftControl))
			{
				Player.Instance.SetVisibility(PlayerVisibility.STAND_UP);
			}
		}
		private void CheckMouseInput() 
		{
			rotationInput = 0f;
			float input = Input.mousePosition.x;
			if (input < 0 || input > ScreenWidth) return;
			rotationInput = GetScaledMouseInput(input);
		}
		private float GetScaledMouseInput(float input) 
		{
			input /= halfScreen;
			return input -1;
		}
		#endregion
	}
}