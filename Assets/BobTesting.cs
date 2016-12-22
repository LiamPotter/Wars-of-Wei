using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobTesting : MonoBehaviour {

    public Vector3 bobAmount,  bobSpeed;
    private Vector3 startPos,  targetPos;

    void Start()
    {
        startPos = transform.position;
        //startRot = transform.localEulerAngles;
    }

    void Update()
    {
        targetPos = new Vector3(startPos.x + (bobAmount.x * Mathf.Sin(Time.time * bobSpeed.x)),
                                startPos.y + (bobAmount.y * Mathf.Sin(Time.time * bobSpeed.y)),
                                startPos.z + (bobAmount.z * Mathf.Sin(Time.time * bobSpeed.z)));

        //targetRot = new Vector3(startRot.x + (rotateAmount.x * Mathf.Sin(Time.time * rotateSpeed.x)),
        //                        startRot.y + (rotateAmount.y * Mathf.Sin(Time.time * rotateSpeed.y)),
        //                        startRot.z + (rotateAmount.z * Mathf.Sin(Time.time * rotateSpeed.z)));

        //transform.localEulerAngles = targetRot;
        transform.position = targetPos;
    }
}
