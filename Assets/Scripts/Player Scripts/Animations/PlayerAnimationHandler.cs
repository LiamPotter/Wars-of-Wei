using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour {

    public float sRadius, stepDistance;

    public Transform surveyorWheel;

    public bool showWheel;

    private Vector3 lastPosition;
    private float dist, turnAngle,angleCounter;

    private PlayerMovement playerMovement;
    [HideInInspector]
    public Animator animator;

    // Use this for initialization
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement.thisModel.GetComponent<Animator>())
            animator = playerMovement.thisModel.GetComponent<Animator>();
        else animator = playerMovement.thisModel.GetComponentInChildren<Animator>();
    }
	

    public void SurveyorWheel()
    {
        lastPosition = new Vector3(lastPosition.x, 0F, lastPosition.z);
        Vector3 currPosition = new Vector3(transform.position.x, 0F, transform.position.z);

        float dist = Vector3.Distance(lastPosition, currPosition);
        float turnAngle = (dist / (2 * Mathf.PI * sRadius)) * 360F;

        if (showWheel)
        {
            if (!surveyorWheel.gameObject.activeSelf)
                surveyorWheel.gameObject.SetActive(true);
            //For visualization. Attach to Transform.
            surveyorWheel.Rotate(new Vector3(0F, -turnAngle, 0F));
        }
        else
        {
            if (surveyorWheel.gameObject.activeSelf)
                surveyorWheel.gameObject.SetActive(false);
        }
        angleCounter += turnAngle;

        if (angleCounter > stepDistance)
            angleCounter = 0F;

        animator.SetFloat("Step", (angleCounter / stepDistance));

        if (animator.GetFloat("Step") > 1F)
            animator.SetFloat("Step", 0);

        lastPosition = currPosition;
    }
}
