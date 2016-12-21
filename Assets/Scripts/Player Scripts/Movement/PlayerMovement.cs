using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using TriTools;
public class PlayerMovement : MonoBehaviour,IBase_Movement {

    public enum PState
    {
        Idle,
        Moving,
        Jumping,
        Falling
    }
    public PState CurrentState;
    private Vector3 mVector;
    public Vector3 MovementVector
    {
        get
        {
            return mVector;
        }

        set
        {
            mVector = value;
        }
    }
    public bool inCombat;

    public GameObject cameraObject;
    public Transform thisModel;
    public Transform Model
    {
        get
        {
            return thisModel;
        }
        set
        {
            thisModel = value;
        }
    }
    public CharacterController thisCharacterController;

    public CharacterController CharacterController
    {
        get
        {
            return thisCharacterController;
        }
        set
        {
            thisCharacterController = value;
        }
    }

    public float moveSpeed;
    public float Speed
    {
        get
        {
            return moveSpeed;
        }

        set
        {
            moveSpeed = value;
        }
    }

    public int rotSpeed;
    public int RotationSpeed
    {
        get
        {
            return rotSpeed;
        }

        set
        {
            rotSpeed = value;
        }
    }

    public bool isJumping;

    private bool canJump;
    private float pJumpTime;
    public float JumpForce, JumpTime, Gravity,velocityChangeSpeed;

    private Player playerControls;

    private float horizontalAxis, verticalAxis, YVelocity;

    public void Movement()
    {
        horizontalAxis = playerControls.GetAxis("Horizontal");
        verticalAxis = playerControls.GetAxis("Vertical");

        TriToolHub.CreateVector3(horizontalAxis, verticalAxis, Speed/10, TriToolHub.AxisPlane.XZ, (inCombat) ? gameObject : cameraObject, out mVector);
        if(CurrentState == PState.Jumping)
        {
            YVelocity = Mathf.Lerp(YVelocity, JumpForce, Time.deltaTime * velocityChangeSpeed);
            mVector.y = YVelocity;
        }
        if(CurrentState == PState.Falling)
        {
            YVelocity = Mathf.Lerp(YVelocity, Gravity, Time.deltaTime * velocityChangeSpeed);
            mVector.y = YVelocity;
        }
        //TriToolHub.AddForce(gameObject, MovementVector, Space.World, ForceMode.Force);
        CharacterController.Move(mVector);
        //thisRigidbody.velocity = Vector3.ClampMagnitude(thisRigidbody.velocity, MovementCap);
    }

    public void Rotation()
    {
        TriToolHub.SmoothLookAtDirection(Model.gameObject, MovementVector, 0.01f, Model.up, true, RotationSpeed);
    }

    void Start ()
    {
        if (cameraObject == null)
            cameraObject = Camera.main.gameObject;
        if (playerControls == null)
            playerControls = ReInput.players.GetPlayer(1);
        if (thisCharacterController == null)
            thisCharacterController = GetComponent<CharacterController>();
	}
	void Update()
    {
        CurrentState = EvaluateState();
    }
	void FixedUpdate ()
    {
        if (CharacterController.isGrounded)
        {
            canJump = true;
            isJumping = false;
            pJumpTime = 0;
            YVelocity = 0;
        }
        switch (CurrentState)
        {
            case PState.Idle:
                Movement();
                break;
            case PState.Moving:
                Movement();
                break;
            case PState.Jumping:
                Movement();
                break;
            case PState.Falling:
                Movement();
                break;
            default:
                break;
        }

        Rotation();
    }
    PState EvaluateState()
    {
        if (playerControls.GetButton("Jump"))
        {
            if (canJump)
            {
                if (pJumpTime < JumpTime)
                {
                    pJumpTime += Time.deltaTime;
                    isJumping = true;
                    return PState.Jumping;
                }
                else
                {
                    isJumping = false;
                    canJump = false;
                }
            }
        }
        else isJumping = false;
        if (!CharacterController.isGrounded&&!isJumping)
            return PState.Falling;
        if (Mathf.Abs(playerControls.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(playerControls.GetAxis("Vertical")) > 0.1f)
        {
            if(CurrentState!=PState.Jumping)
                return PState.Moving;
        }

        return PState.Idle;
    }
}
