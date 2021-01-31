using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AGAC.General;
using UnityEngine.Events;

namespace UTAD
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(Collider))]
	public class AcquirableItem : SceneryItem
	{
		#region UNITY METHODS
		private void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<Player>().Equals(null)) return;
			AcquireItem();
		}
		private void Start()
		{
			rb = GetComponent<Rigidbody>();
			coll = GetComponent<Collider>();

			rb.useGravity = false;
			coll.isTrigger = true;
		}
		#endregion

		#region VARIABLES
		[SerializeField]
		protected UnityEvent OnAcquire = null;

		private Rigidbody rb = null;
		private Collider coll = null;
		#endregion

		#region PUBLIC METHODS
		public void AcquireItem()
		{
			Deactivate();
			OnAcquire?.Invoke();
		}
		#endregion

		#region PROTECTED METHODS
		protected virtual bool CanAcquire() => true;
		#endregion
	}
}