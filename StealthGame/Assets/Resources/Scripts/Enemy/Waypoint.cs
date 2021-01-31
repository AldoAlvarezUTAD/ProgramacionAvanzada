using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD
{
    [System.Serializable]
    public class Waypoint
    {
        [SerializeField, Range(0, 10f)]
        private float waitTime = 0f;

        public Transform targetPoint = null;
        public float WaitTime => waitTime;
    }
}