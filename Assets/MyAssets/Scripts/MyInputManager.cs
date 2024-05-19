using System;
using PolySpatial.Template;
using Unity.PolySpatial.InputDevices;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

namespace PetVisionPro.Scripts
{
	public class MyInputManager : MonoBehaviour
	{
		private GameObject _SelectedObject;
		private bool _ActiveDirectPinch;

		private void OnEnable()
		{
			EnhancedTouchSupport.Enable();
		}

		private void Update()
		{
			var ActiveTouches = Touch.activeTouches;
			if (ActiveTouches.Count > 0)
			{
				var PrimaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(ActiveTouches[0]);
				var TouchPhase = ActiveTouches[0].phase;

				//Begin touch
				if (TouchPhase == TouchPhase.Began &&
				    (PrimaryTouchData.Kind == SpatialPointerKind.IndirectPinch || PrimaryTouchData.Kind == SpatialPointerKind.DirectPinch))
				{
					if (PrimaryTouchData.targetObject)
					{
						if (PrimaryTouchData.targetObject.TryGetComponent<ITouchObjectFunctions>(out var Comp))
						{
							_SelectedObject = Comp.GetMainObject();
							Comp.StartSelect();
							//_SelectedObject.Start();
						}

						_ActiveDirectPinch = PrimaryTouchData.Kind == SpatialPointerKind.DirectPinch;
					}
				}

				//Moving touch
				if (TouchPhase == TouchPhase.Moved)
				{
					if (_SelectedObject)
					{
						if (PrimaryTouchData.Kind == SpatialPointerKind.IndirectPinch)
						{
							_SelectedObject.GetComponent<ITouchObjectFunctions>().Move();
						}
						//_SelectedObject.Move();
					}
				}

				if (TouchPhase == TouchPhase.Ended || TouchPhase == TouchPhase.Canceled)
				{
					if (_SelectedObject)
					{
						//reset
						//_SelectedObject.Select(false)
						_SelectedObject.GetComponent<ITouchObjectFunctions>().EndSelect(TouchPhase == TouchPhase.Canceled);
					}
				}
			}
		}
	}
}