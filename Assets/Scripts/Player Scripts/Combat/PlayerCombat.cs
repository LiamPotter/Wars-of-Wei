using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerCombat : MonoBehaviour {

    public Transform mainWeaponHolder;
    public GameObject currentWeapon;
   // private Animator weaponAnimator;

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
	}
	
	void Update ()
    {
        if (playerControls.GetButtonDown("Attack"))
        {
            attacking = true;
        }
        else attacking = false;
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
