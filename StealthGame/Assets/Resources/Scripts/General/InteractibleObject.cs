using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UTAD
{
	[RequireComponent(typeof(Collider))]
	[RequireComponent(typeof(Rigidbody))]
	public class InteractibleObject : MonoBehaviour
	{
		#region UNITY METHODS
		private void OnTriggerEnter(Collider other)
		{
			if (!other.CompareTag("Player")) return;
			checkInteraction = true;
		}
		private void OnTriggerExit(Collider other)
		{
			if (!other.CompareTag("Player")) return;
			checkInteraction = false;
		}
		private void Start()
		{
            coll = GetComponent<Collider>();
            rb = GetComponent<Rigidbody>();
			coll.isTrigger = true;
			rb.useGravity = false;
		}
		private void Update()
		{
			if (!checkInteraction) return;
			if (Input.GetKeyDown(input))
				Interact();
		}
		private void OnDisable()
		{
			checkInteraction = false;
		}
		#endregion

		#region VARIABLES
		[SerializeField] private KeyCode input = KeyCode.Space;
		[SerializeField] private UnityEvent OnInteract;

		private bool checkInteraction = false;

		private Collider coll = null;
		private Rigidbody rb = null;
		#endregion
			
		#region PRIVATE METHODS
		private void Interact()
		{
            checkInteraction = false;
			OnInteract?.Invoke();
		}
		#endregion
	}
}