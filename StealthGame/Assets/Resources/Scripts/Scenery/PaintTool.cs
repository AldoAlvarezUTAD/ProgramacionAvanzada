using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTAD
{
    [RequireComponent(typeof(RotatableObject))]
	public class PaintTool : MonoBehaviour
	{
		#region UNITY METHODS
		private void Start()
		{
            rotatable = GetComponent<RotatableObject>();	
		}

		private void Update()
		{
            rotatable.Rotate(Enums.ObjectSelfDirection.RIGHT, 1f);
		}
        #endregion

        #region VARIABLES
        private RotatableObject rotatable = null;
		
		#endregion
		
		#region PUBLIC METHODS
		public void Method()
		{
			
		}
		#endregion
		
		#region PRIVATE METHODS
		private void method()
		{
			
		}
		#endregion
	}
}