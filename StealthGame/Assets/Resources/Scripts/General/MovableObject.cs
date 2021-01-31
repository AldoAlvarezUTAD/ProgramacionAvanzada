using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTAD.Interfaces;
using UnityEngine.SocialPlatforms;

namespace UTAD
{
    [DisallowMultipleComponent]
    public class MovableObject : ControlledActionBehaviour, IMovable
    {
        #region VARiABLES
        [SerializeField, Range(0f, 5f)]
        protected float movementSpeed = 1f;
        #endregion

        #region PUBLIC METHODS
        public void MoveTo(Transform point)
        {
            if (!ConditionsToMove()) return;
            Move((point.position-transform.position).normalized);
        }
        public virtual void Move(Vector3 direction) 
        {
            if (!ConditionsToMove()) return;
            transform.position += direction/*.normalized*/ * movementSpeed * Time.deltaTime;
        }
        #endregion

        #region PROTECTED METHODS
        protected virtual bool ConditionsToMove() => isAllowed;
        #endregion
    }
}