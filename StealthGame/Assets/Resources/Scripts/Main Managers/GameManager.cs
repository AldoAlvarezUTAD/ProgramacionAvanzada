using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UTAD.Enums;
using AGAC.StandarizedTime;

namespace UTAD
{
    [RequireComponent(typeof(GameUI))]
	public class GameManager : SingletonObject<GameManager>
	{
		#region UNITY METHODS
		private void Start()
		{
            UI = GetComponent<GameUI>();
			PauseGame();
		}

		private void FixedUpdate()
		{
            switch (GameState)
            {
                case GameStates.IN_GAME:
                    UpdateGameUI();
                    gameTime -= Time.fixedDeltaTime;
                    if (gameTime <= 0f)
                        EndGame();
                    return;
                default:return;
            }
		}
        #endregion

        #region VARIABLES
        public static GameStates GameState { get; private set; } = GameStates.AFTER_GAME;
		private bool canSave = true;
        public event Action OnRestart;
        [SerializeField]
        private Transform playerInitPosition;
		[SerializeField]
		private UnityEvent OnPause, OnResume, OnEndGame;

        [SerializeField]
        private StandardTime TimeToFinish;
        private float gameTime = 0f;
        private StandardTime stGameTime;
        private GameUI UI = null;
        private int toolsCollected = 0;
        #endregion

        #region PUBLIC METHODS
        public void SaveGame()
		{
			if (!canSave) return;
		}
		public void LoadGame()
		{

		}

		public void PauseGame() => ChangeGameState(GameStates.PAUSE, OnPause);
		public void ResumeGame() => ChangeGameState(GameStates.IN_GAME, OnResume);
        public void EndGame()
        {
            ChangeGameState(GameStates.AFTER_GAME, OnEndGame);
            UI.SetScore(CalculateScore());
        }
        public void Restart()
        {
            OnRestart?.Invoke();
            Player.Instance.SetPosition(playerInitPosition);
            toolsCollected = 0;
            gameTime = TimeToFinish.ToFloat();
            stGameTime = new StandardTime();
            stGameTime.ConvertFrom(gameTime);

            ResumeGame();
            UpdateGameUI();
        }
        public void ExitGame()
        {
            AGAC.General.GeneralMethods.CloseApp();
        }
        public void CollectTool() => toolsCollected++;
        #endregion

        #region PRIVATE METHODS
        private void UpdateGameUI()
        {
            stGameTime.ConvertFrom(gameTime);
            UI.SetTime(stGameTime);
            UI.SetCollectibles(toolsCollected);
        }

		private void ChangeGameState(GameStates state, UnityEvent stateActions) 
		{
			GameState = state;
			stateActions?.Invoke();
		}
        private float CalculateScore()
        {
            Enemy []aliveEnemies = GameObject.FindObjectsOfType<Enemy>();
            float score = toolsCollected * 3000;
            score += aliveEnemies.Length * 2000;
            return score += gameTime * 10;
        }
        #endregion
    }
}