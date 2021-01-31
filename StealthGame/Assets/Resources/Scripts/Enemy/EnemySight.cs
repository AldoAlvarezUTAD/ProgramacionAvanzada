using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD.Enemies
{
	public class EnemySight : MonoBehaviour
	{
        private void Start()
        {
            player = Player.Instance.transform;
            trans = GetComponent<Transform>();
            viewAngleRadians = Mathf.Deg2Rad * viewAngle;
        }

        #region VARIABLES
        [SerializeField, Range(0, 100)]
        private int viewDistance = 20;
        [SerializeField, Range(1, 90)]
        private int viewAngle = 60;
        private Transform player;
        private Transform trans;
        private float viewAngleRadians = 0f;
        #endregion

        #region PUBLIC METHODS
        public bool CanSeePlayer()
        {
            Vector3 toPlayer = (player.position - trans.position).normalized;
            float dot = Vector3.Dot(toPlayer, trans.forward);
            //no lo tiene en frente
            if (dot < 0) return false;
            //el player esta enfrente, pero puede que no en el angulo de vision
            float angle = Mathf.Acos(dot / (toPlayer.magnitude * trans.forward.magnitude));
            return angle <= viewAngleRadians;
        }
        public bool isLookingAtPlayer()
        {
            Vector3 toPlayer = (player.position - trans.position);
            Vector3 origin = trans.position;
            //el pivote esta muy cerca del suelo, por lo que el calculo lo hago mas arriba
            origin.y += 0.2f;

            Transform obj = ShootRaycast(origin, toPlayer);
            if (obj == null) return false;
            return obj.GetComponent<Player>() != null;
        }
        public Transform See(Vector3 origin, Vector3 direction) => ShootRaycast(origin, direction);
		#endregion
		
		#region PRIVATE METHODS
		private Transform ShootRaycast(Vector3 origin, Vector3 direction)
		{
            RaycastHit hit;
            Ray ray = new Ray(origin, direction);

            if (!Physics.Raycast(ray, out hit, viewDistance))
                return null;
            return hit.transform;
		}
		#endregion
	}
}