﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using TriTools;

public class CameraBasic : MonoBehaviour,Camera_Base {
    public int PubFollowSpeed;
    public int FollowSpeed
    {
        get
        {
            return PubFollowSpeed;
        }

        set
        {
            PubFollowSpeed = value;
        }
    }
    public float PubRotationSpeed;
    public float RotationSpeed
    {
        get
        {
            return PubRotationSpeed;
        }

        set
        {
            PubRotationSpeed = value; 
        }
    }
    public float PubZoomSpeed;
    public Transform PubTarget;
    public Transform Target
    {
        get
        {
            return PubTarget;
        }

        set
        {
            PubTarget = value;
        }
    }
    private Vector3 rotationVector;
    public Vector3 Offset;
    private Vector3 zoomVector = new Vector3();
    public Player playerControls;
    public Transform cameraRotator;
    public bool invertHorizontal, invertVertical;
    public float minXAngle,maxXAngle;
    private float cHorizontal, cVertical,cWheel;
    public void FollowTarget()
    {
        float step = Time.deltaTime * PubFollowSpeed;
        cameraRotator.position = Vector3.MoveTowards(cameraRotator.position, Target.position+Offset, step);
      
    }
    public void Rotation()
    {
        cHorizontal += playerControls.GetAxis("CamHorizontal")*((invertHorizontal)?RotationSpeed:-RotationSpeed);
        cVertical += playerControls.GetAxis("CamVertical") * ((invertVertical) ? -RotationSpeed : RotationSpeed);
        cVertical = Mathf.Clamp(cVertical, minXAngle, maxXAngle);
        cameraRotator.position = Target.position;
        TriToolHub.CreateVector3(cVertical, cHorizontal, 1, TriToolHub.AxisPlane.XY, Target.gameObject, out rotationVector);
        //rotationVector.x = Mathf.Clamp(rotationVector.x, minXAngle, maxXAngle);
        //TriToolHub.Rotate(cameraRotator.gameObject, rotationVector, true, Space.World);
        rotationVector.z = 0;
        TriToolHub.SetRotation(cameraRotator.gameObject, rotationVector, Space.Self);
        
    }
    void Zoom()
    {
        cWheel += playerControls.GetAxis("Zoom") * PubZoomSpeed;
        cWheel = Mathf.Clamp(cWheel, -12, -2);
        zoomVector.z =cWheel;
        zoomVector.x = transform.localPosition.x;
        zoomVector.y = transform.localPosition.y;
        transform.localPosition = zoomVector;
    }
    void Start()
    {
        if (playerControls == null)
            playerControls = ReInput.players.GetPlayer(1);
        cWheel = -10;
    }
    void Update()
    {
        FollowTarget();
        Rotation();
        Zoom();
    }
}
