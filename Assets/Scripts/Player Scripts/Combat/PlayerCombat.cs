using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerCombat : MonoBehaviour {

    public Transform mainWeaponHolder;
    public GameObject currentWeapon;
    // private Animator weaponAnimator;

    public float swingSpeed;
    private Vector3 weaponVector;
    public bool attacking;
    public int attackNumber;

    private Player playerControls;

	void Start () {
        playerControls = ReInput.players.GetPlayer(1);
        //if(currentWeapon!=null)
        //{
        //    if (currentWeapon.GetComponent<Animator>() == null)
        //        Debug.LogError("All weapons must have an Animator Component!");
        //    else weaponAnimator = currentWeapon.GetComponent<Animator>();
        //}
        weaponVector = currentWeapon.transform.localPosition;
	}
	
	void Update ()
    {
        if (playerControls.GetButton("Attack"))
        {
            attacking = true;
        }
        else attacking = false;

        if(attacking)
        {
            if(currentWeapon)
            {
                weaponVector.z = Mathf.Lerp(weaponVector.z, 0.25f, Time.deltaTime*swingSpeed);
                weaponVector.z = Mathf.Clamp(weaponVector.z, 0, 0.25f);
                weaponVector.x = currentWeapon.transform.localPosition.x;
                weaponVector.y = Mathf.Lerp(weaponVector.y, 0.25f, Time.deltaTime * swingSpeed);
                weaponVector.y = Mathf.Clamp(weaponVector.y, 0, 0.25f);
                currentWeapon.transform.localPosition = weaponVector;
            }
        }
        else
        {
            if(weaponVector.z>0)
            {
                weaponVector.z = Mathf.Lerp(weaponVector.z, 0f, Time.deltaTime* swingSpeed);
                weaponVector.z = Mathf.Clamp(weaponVector.z, 0, 0.25f);
                weaponVector.x = currentWeapon.transform.localPosition.x;
                weaponVector.y = Mathf.Lerp(weaponVector.y,0, Time.deltaTime * swingSpeed);
                weaponVector.y = Mathf.Clamp(weaponVector.y, 0, 0.25f);
                currentWeapon.transform.localPosition = weaponVector;
            }
        }
        //if (currentWeapon != null)
        //{
        //    if (weaponAnimator != null)
        //    {
        //        weaponAnimator.SetBool("Attacking", attacking);
        //    }
        //    else Debug.LogError("Trying to attack but no Animator has been found on CurrentWeapon!");
        //}
        //else Debug.LogError("Trying to attack but CurrentWeapon is null!");
	}
}
