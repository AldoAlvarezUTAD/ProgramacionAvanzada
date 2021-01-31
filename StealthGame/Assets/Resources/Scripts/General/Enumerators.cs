using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD.Enums
{
    public enum PlayerStatsIDs { HEALTH, MANA, counter }
    public enum PlayerVisibility { STAND_UP, CROUCH, HIDDEN }
    [System.Flags]
    public enum PlayerActions
    {
        MOVE = 1 << 0,
        ROTATE = 1 << 1,
        INTERACT = 1 << 2,
        PAUSE = 1 << 3,
        ATTACk = 1 << 4,
        counter = 1 << 5
    }

    public enum ObjectSelfDirection { FORWARD, RIGHT, UP, BACK, LEFT, DOWN }
    public enum GameStates {IN_GAME, PAUSE, AFTER_GAME }
}