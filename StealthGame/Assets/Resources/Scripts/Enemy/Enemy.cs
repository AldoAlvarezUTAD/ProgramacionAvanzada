using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UTAD.Interfaces;
using UTAD.Enemies;

namespace UTAD
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(EnemyMovementController))]
    [RequireComponent(typeof(EnemyAnimController))]
    [RequireComponent(typeof(EnemySight))]
    [RequireComponent(typeof(EnemyUI))]
	public class Enemy : MonoBehaviour, IRestartable
	{
		#region UNITY METHODS
		private void Awake()
		{
            movementCtrl = GetComponent<EnemyMovementController>();
            sight = GetComponent<EnemySight>();
            trans = GetComponent<Transform>();
            UI = GetComponent<EnemyUI>();
            GameManager.Instance.OnRestart += Restart;
		}
        private void Start()
        {
            Restart();        
        }

        private void Update()
        {
            if (!alive) return;
            switch (GameManager.GameState)
            {
                case Enums.GameStates.IN_GAME:
                    movementCtrl.MoveToDestination();
                    return;
                default: return;
            }
        }
        private void FixedUpdate()
        {
            if (!alive) return;
            switch (GameManager.GameState)
            {
                case Enums.GameStates.IN_GAME:
                    if (!CheckIfSeeingPlayer())
                        ReduceAwareness();

                    UpdateUI();
                    return;
                default: return;
            }
        }
        #endregion

        #region VARIABLES
        public bool alive { get; private set; } = true;
        [SerializeField, Range(0,100)]
        [Tooltip("The percentage of awareness of the player pressence per second.")]
        private int awarenessRate = 10;
        private float awareness = 0f;

        [SerializeField]
        private UnityEvent OnRestart;
        [SerializeField]
        private Transform EnemyRender = null;
        private EnemyMovementController movementCtrl = null;
        private EnemySight sight = null;
        private EnemyUI UI = null;
        private Transform trans = null;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
		{
            gameObject.SetActive(true);
            movementCtrl.Restart();
            alive = true;
            awareness = 0f;
            UpdateUI();
            EnemyRender.transform.localPosition = Vector3.zero;
            EnemyRender.transform.localRotation = Quaternion.identity;
            OnRestart?.Invoke();
		}
        public void Die() {
            alive = false;
            awareness = 0f;
            UpdateUI();
        }
        #endregion

        #region PRIVATE METHODS
        private bool CheckIfSeeingPlayer()
		{
            if (!sight.CanSeePlayer()) return false;
            if (!sight.isLookingAtPlayer()) return false;

            ModifyAwareness(GetVisibilityMultiplier());
            if (awareness >= 100)
            {
                awareness = 100;
                GameManager.Instance.EndGame();
            }
            return true;
        }
        private void ReduceAwareness()
        {
            if (awareness <= 0) return;

            ModifyAwareness(-0.3f);

            if (awareness < 0)
                awareness = 0;
        }

        private void ModifyAwareness(float multiplier)
        {
            awareness += awarenessRate * multiplier * Time.fixedDeltaTime;
        }

        private void UpdateUI()
        {
            UI.UpdateAwareness(awareness);
        }

        private float GetVisibilityMultiplier()
        {
            switch (Player.Instance.Visibility)
            {
                case Enums.PlayerVisibility.STAND_UP:return 1f;
                case Enums.PlayerVisibility.CROUCH:return 0.4f;
                case Enums.PlayerVisibility.HIDDEN:return 0f;
                default:return 0f;
            }
        }
        #endregion
    }
}