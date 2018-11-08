// %BANNER_BEGIN%
// ---------------------------------------------------------------------
// %COPYRIGHT_BEGIN%
//
// Copyright (c) 2018 Magic Leap, Inc. All Rights Reserved.
// Use of this file is governed by the Creator Agreement, located
// here: https://id.magicleap.com/creator-terms
//
// %COPYRIGHT_END%
// ---------------------------------------------------------------------
// %BANNER_END%

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using MagicLeap;

namespace MagicLeap
{
    /// <summary>
    /// This class represents the controller and its interactions.
    /// This works hand-in-hand with WorldButton.
    /// </summary>
    public class VirtualPointer : MonoBehaviour
    {
        #region Private Variables
        [SerializeField, Tooltip("ControllerConnectionHandler reference.")]
        private ControllerConnectionHandler _controllerConnectionHandler;

        [SerializeField, Space, Tooltip("Pointer Ray")]
        private Transform _pointerRay;

        [SerializeField, Tooltip("Pointer Light")]
        private Light _pointerLight;

        [SerializeField, Tooltip("Color of the pointer light when no hit is detected")]
        private Color _pointerLightColorNoHit = Color.black;
        [SerializeField, Tooltip("Color of the pointer light when a hit is detected")]
        private Color _pointerLightColorHit = Color.yellow;
        [SerializeField, Tooltip("Color of the pointer light when a button is pressed while a hit is detected")]
        private Color _pointerLightColorHitPress = Color.green;

        private MediaPlayerButton _lastButtonHit;
        private bool _isGrabbing = false;
<<<<<<< HEAD
=======

        private GameObject[] islands;
>>>>>>> 7fdb22636fd677fb9926b2a7e724ddf5757a1382
        #endregion // Private Properties

        #region Unity Methods
        private void Awake()
        {
            if (_controllerConnectionHandler == null)
            {
                Debug.LogError("Error: VirtualPointer._controllerConnectionHandler is not set, disabling script.");
                enabled = false;
                return;
            }

<<<<<<< HEAD
=======
            islands = new GameObject[5];
            for (int i = 1; i <= 5; i++)
            {
                islands[i] = GameObject.Find("GameObject" + i);
            }

>>>>>>> 7fdb22636fd677fb9926b2a7e724ddf5757a1382
            MLInput.OnControllerButtonDown += HandleControllerButtonDown;
            MLInput.OnControllerButtonUp += HandleControllerButtonUp;
            MLInput.OnTriggerDown += HandleTriggerDown;
            MLInput.OnTriggerUp += HandleTriggerUp;
        }

        private void OnDestroy()
        {
            MLInput.OnControllerButtonDown -= HandleControllerButtonDown;
            MLInput.OnControllerButtonUp -= HandleControllerButtonUp;
            MLInput.OnTriggerDown -= HandleTriggerDown;
            MLInput.OnTriggerUp -= HandleTriggerUp;
        }

        private void Update()
        {
            if (!_isGrabbing)
            {
                RaycastHit[] hit = new RaycastHit[1];
<<<<<<< HEAD
                if (Physics.RaycastNonAlloc(_pointerRay.position, _pointerRay.forward, hit) > 0)
                {
                    MediaPlayerButton wb = hit[0].transform.GetComponent<MediaPlayerButton>();
                    if (wb != null)
                    {
                        if (_lastButtonHit == null)
                        {
                            if (wb.OnRaycastEnter != null)
                            {
                                wb.OnRaycastEnter(hit[0].point);
                            }
                            _lastButtonHit = wb;
                            _pointerLight.color = _pointerLightColorHit;
                        }
                        else if (_lastButtonHit == wb)
                        {
                            if (_lastButtonHit.OnRaycastContinue != null)
                            {
                                _lastButtonHit.OnRaycastContinue(hit[0].point);
                            }
                        }
                        else
                        {
                            if (_lastButtonHit.OnRaycastExit != null)
                            {
                                _lastButtonHit.OnRaycastExit(hit[0].point);
                            }
                            _lastButtonHit = null;
                        }
                    }
                    else
                    {
                        if (_lastButtonHit != null)
                        {
                            if (_lastButtonHit.OnRaycastExit != null)
                            {
                                _lastButtonHit.OnRaycastExit(hit[0].point);
                            }
                            _lastButtonHit = null;
                        }
                        _pointerLight.color = _pointerLightColorNoHit;
                    }
=======
                // RayCast
                // RayCastAll
                if (Physics.RaycastNonAlloc(_pointerRay.position, _pointerRay.forward, hit) > 0)
                {
                    //MediaPlayerButton wb = hit[0].transform.GetComponent<MediaPlayerButton>();

                    GameObject g = hit[0].transform.gameObject; //  "GrameObject1-5"
                    GameObject g_parent = g.transform.parent.gameObject; // "Scene"

                    while (g_parent.transform.parent.gameObject.name != "Scene")
                    {
                        g = g_parent;
                        g_parent = g.transform.parent.gameObject;
                    }

                    // g should have the full island
                    // Outline of the full island
                    Outline o = g.GetComponent<Outline>();

                    // Check for null
                    if (o != null) {
                        Debug.Log("Hit " + hit[0].collider.gameObject.name);
                        if (!o.isActiveAndEnabled)
                            o.enabled = true;
                    }



                    //if (wb != null)
                    //{
                    //    if (_lastButtonHit == null)
                    //    {
                    //        if (wb.OnRaycastEnter != null)
                    //        {
                    //            wb.OnRaycastEnter(hit[0].point);
                    //        }
                    //        _lastButtonHit = wb;
                    //        _pointerLight.color = _pointerLightColorHit;
                    //    }
                    //    else if (_lastButtonHit == wb)
                    //    {
                    //        if (_lastButtonHit.OnRaycastContinue != null)
                    //        {
                    //            _lastButtonHit.OnRaycastContinue(hit[0].point);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (_lastButtonHit.OnRaycastExit != null)
                    //        {
                    //            _lastButtonHit.OnRaycastExit(hit[0].point);
                    //        }
                    //        _lastButtonHit = null;
                    //    }
                    //}
                    //else
                    //{
                    //    if (_lastButtonHit != null)
                    //    {
                    //        if (_lastButtonHit.OnRaycastExit != null)
                    //        {
                    //            _lastButtonHit.OnRaycastExit(hit[0].point);
                    //        }
                    //        _lastButtonHit = null;
                    //    }
                    //    _pointerLight.color = _pointerLightColorNoHit;
                    //}
>>>>>>> 7fdb22636fd677fb9926b2a7e724ddf5757a1382
                    UpdatePointer(hit[0].point);
                }
                else
                {
<<<<<<< HEAD
                    _lastButtonHit = null;
                    ClearPointer();
=======
                    Debug.Log("Did not hit");
                    //_lastButtonHit = null;
                    ClearPointer();

                    //clear all outlines
                    foreach (GameObject island in islands) 
                    {
                        Outline outline = island.GetComponent<Outline>();
                        if (outline.isActiveAndEnabled) 
                        {
                            Debug.Log("Clear outline of " + island.name);
                            outline.enabled = false;
                        }
                    }
                    
>>>>>>> 7fdb22636fd677fb9926b2a7e724ddf5757a1382
                }
            }
            else if (_isGrabbing)
            {
                // _isGrabbing already guarantees that _lastButtonHit is not null
                // but just in case the actual button gets destroyed in
                // the middle of the grab, let's still check

                if (_lastButtonHit != null && _lastButtonHit.OnControllerDrag != null)
                {
                    _lastButtonHit.OnControllerDrag(_controllerConnectionHandler.ConnectedController);
                }
            }
        }
        #endregion // Unity Methods

        #region Private Methods
        private void UpdatePointer(Vector3 hitPosition)
        {
            Vector3 pointerScale = _pointerRay.localScale;
            pointerScale.z = Vector3.Distance(_pointerRay.position, hitPosition);
            _pointerRay.localScale = pointerScale;

            _pointerLight.transform.position = hitPosition;
        }

        private void ClearPointer()
        {
            Vector3 pointerScale = _pointerRay.localScale;
            pointerScale.z = 1.0f;
            _pointerRay.localScale = pointerScale;
<<<<<<< HEAD

=======
            
>>>>>>> 7fdb22636fd677fb9926b2a7e724ddf5757a1382
            _pointerLight.transform.position = transform.position;
            _pointerLight.color = _pointerLightColorNoHit;
        }
        #endregion // Private Methods

        #region Event Handlers
        private void HandleControllerButtonDown(byte controllerId, MLInputControllerButton button)
        {
            if (_controllerConnectionHandler.IsControllerValid(controllerId) && _lastButtonHit != null && !_isGrabbing)
            {
                if (_lastButtonHit.OnControllerButtonDown != null)
                {
                    _lastButtonHit.OnControllerButtonDown(button);
                }
                _pointerLight.color = _pointerLightColorHitPress;
                _isGrabbing = true;
            }
        }

        private void HandleControllerButtonUp(byte controllerId, MLInputControllerButton button)
        {
            if (_controllerConnectionHandler.IsControllerValid(controllerId))
            {
                if (_lastButtonHit != null)
                {
                    if (_lastButtonHit.OnControllerButtonUp != null)
                    {
                        _lastButtonHit.OnControllerButtonUp(button);
                    }
                    _pointerLight.color = _pointerLightColorHit;
                    _isGrabbing = false;
                }
                else
                {
                    _pointerLight.color = _pointerLightColorNoHit;
                }
            }
        }

        private void HandleTriggerDown(byte controllerId, float triggerValue)
        {
            if (_controllerConnectionHandler.IsControllerValid(controllerId) && _lastButtonHit != null && !_isGrabbing)
            {
                if (_lastButtonHit.OnControllerTriggerDown != null)
                {
                    _lastButtonHit.OnControllerTriggerDown(triggerValue);
                }
                _pointerLight.color = _pointerLightColorHitPress;
                _isGrabbing = true;
            }
        }

        private void HandleTriggerUp(byte controllerId, float triggerValue)
        {
            if (_controllerConnectionHandler.IsControllerValid(controllerId))
            {
                if (_lastButtonHit != null)
                {
                    if (_lastButtonHit.OnControllerTriggerUp != null)
                    {
                        _lastButtonHit.OnControllerTriggerUp(triggerValue);
                    }
                    _pointerLight.color = _pointerLightColorHit;
                    _isGrabbing = false;
                }
                else
                {
                    _pointerLight.color = _pointerLightColorNoHit;
                }
            }
        }
        #endregion // Event Handlers
    }
}
