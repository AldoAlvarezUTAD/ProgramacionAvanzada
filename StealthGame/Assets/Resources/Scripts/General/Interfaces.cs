using UTAD.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD.Interfaces 
{
    public interface IControlledAction 
    {
        bool isAllowed { get; }

        void AllowAction();
        void ImpedeAction();
    }
    public interface IMovable : IControlledAction
    {
        void Move(Vector3 direction);
        void MoveTo(Transform point);
    }

    public interface IRotatable : IControlledAction
    {
        void Rotate(ObjectSelfDirection direction, float speedMultiplier);
    }

    public interface IDamageable 
    {
        float Health { get; }
        bool isAlive { get; }

        void RestoreHealth(float amount);
        void TakeDamage(float amount);
        void Die();
    }

    public interface IRestartable 
    {
        void Restart();
    }
}