﻿using System.Collections.Generic;
using Hover.Items;
using UnityEngine;

namespace Hover.Cursors {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class HoverCursorData : MonoBehaviour, IHoverCursorDataForInput {
		
		public RaycastResult? BestRaycastResult { get; set; }
		public float MaxItemHighlightProgress { get; set; }
		public float MaxItemSelectionProgress { get; set; }
		public List<StickySelectionInfo> ActiveStickySelections { get; private set; }

		[SerializeField]
		public CursorType _Type;
		
		[SerializeField]
		public CursorCapabilityType _Capability = CursorCapabilityType.Full;
		
		[SerializeField]
		public bool _IsRaycast = false;

		[SerializeField]
		public Vector3 _RaycastLocalDirection = Vector3.up;

		[SerializeField]
		public float _Size = 1;

		[SerializeField]
		[Range(0, 1)]
		public float _TriggerStrength = 0;

		private IHoverCursorIdle vIdle;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public HoverCursorData() {
			ActiveStickySelections = new List<StickySelectionInfo>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CursorType Type {
			get { return _Type; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool IsActive {
			get { return isActiveAndEnabled; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool CanCauseSelections {
			get { return (IsActive && Capability == CursorCapabilityType.Full); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public CursorCapabilityType Capability {
			get { return _Capability; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool IsRaycast {
			get { return _IsRaycast; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public Vector3 RaycastLocalDirection {
			get { return _RaycastLocalDirection; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public float Size {
			get { return _Size; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public float TriggerStrength {
			get { return _TriggerStrength; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public Vector3 WorldPosition {
			get { return transform.position; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public Quaternion WorldRotation {
			get { return transform.rotation; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public IHoverCursorIdle Idle {
			get { return vIdle; }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void SetIsRaycast(bool pIsRaycast) {
			_IsRaycast = pIsRaycast;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetRaycastLocalDirection(Vector3 pRaycastLocalDirection) {
			_RaycastLocalDirection = pRaycastLocalDirection;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetCapability(CursorCapabilityType pCapability) {
			_Capability = pCapability;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetSize(float pSize) {
			_Size = pSize;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetTriggerStrength(float pTriggerStrength) {
			_TriggerStrength = pTriggerStrength;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetWorldPosition(Vector3 pWorldPosition) {
			transform.position = pWorldPosition;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetWorldRotation(Quaternion pWorldRotation) {
			transform.rotation = pWorldRotation;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetIdle(IHoverCursorIdle pIdle) {
			vIdle = pIdle;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void SetUsedByInput(bool pIsUsed) {
			enabled = pIsUsed;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ActivateIfUsedByInput() {
			gameObject.SetActive(enabled && Capability != CursorCapabilityType.None);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Update() {
			if ( vIdle == null ) {
				vIdle = GetComponent<IHoverCursorIdle>();
			}
		}

	}

}
