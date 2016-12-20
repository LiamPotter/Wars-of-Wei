using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormulaTesting : MonoBehaviour {

    private int BaseDamage, AttackDamage;
    public int CharacterLevel, Strength;
    public float WeaponDamage,WeaponProficiency;

	void Start ()
    {
   
	}
	
	void Update ()
    {
        BaseDamage =(int)Mathf.Clamp(Mathf.RoundToInt((Strength * 2) + (CharacterLevel * 2f) - 10),1,Mathf.Infinity);
        AttackDamage = Mathf.RoundToInt((WeaponDamage + BaseDamage)+(CharacterLevel*(WeaponProficiency/10)));
        //Debug.Log("Base Damage: " + BaseDamage + " Attack Damage: " + AttackDamage);
	}
}
