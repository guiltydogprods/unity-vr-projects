﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class HandleScript : MonoBehaviour
{
    public Transform handle;

    private XRSimpleInteractable interactable;
    private Rigidbody rigidbody;
    private bool isGrabbing;
    private Vector3 handPosition;

    // Start is called before the first frame update
    private void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        rigidbody = GetComponent<Rigidbody>();
        isGrabbing = false;
    }

    public void Grab()
    {
        isGrabbing = true;
        handPosition = InteractorPosition();
    }

    private Vector3 InteractorPosition()
    {
        List<XRBaseInteractor> interactors = interactable.hoveringInteractors;
        if (interactors.Count > 0)
        {
            return interactors[0].transform.position;
        }
        else
        {
            return handPosition;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (isGrabbing)
        {
            handPosition = InteractorPosition();
            transform.position = handPosition;
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
    }

    public void Release()
    {
        isGrabbing = false;
        transform.position = handle.transform.position;
        transform.rotation = handle.transform.rotation;
//        rigidbody.isKinematic = false;
    }
}
