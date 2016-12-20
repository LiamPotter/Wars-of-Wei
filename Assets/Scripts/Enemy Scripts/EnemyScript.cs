using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour, Base_Stats
{
    public bool debug;
    public int pubLevel;
    public int Level
    {
        get
        {
            return pubLevel;
        }

        set
        {
            pubLevel = value;
        }
    }

    #region Stats
    public int pubAgility;
    public int Agility
    {
        get
        {
            return pubAgility;
        }

        set
        {
            pubAgility = value;
        }
    }

    public int pubEnd;
    public int Endurance
    {
        get
        {
            return pubEnd;
        }

        set
        {
            pubEnd = value;
        }
    }

    public int pubInt;
    public int Intelligence
    {
        get
        {
            return pubInt;
        }

        set
        {
            pubInt = value;
        }
    }

    public int pubStr;
    public int Strength
    {
        get
        {
            return pubStr;
        }

        set
        {
            pubStr = value;
        }
    }

    public int pubWis;
    public int Wisdom
    {
        get
        {
            return pubWis;
        }

        set
        {
            pubWis = value;
        }
    }
    #endregion

    private int pubBaseDmg;
    public int BaseDamage
    {
        get
        {
            return pubBaseDmg;
        }

        set
        {
            pubBaseDmg = value;
        }
    }

    private int pubAttackDmg;
    public int AttackDamage
    {
        get
        {
            return pubAttackDmg;
        }

        set
        {
            pubAttackDmg = value;
        }
    }

    [HideInInspector]
    public int CurrentWeaponDamage, CurrentWeaponProficiency;

    public void AddTo(int x, int y)
    {
        x += y;
    }

    public void SetWeaponValues(int newDamage,int newProficieny)
    {
        CurrentWeaponDamage = newDamage;
        CurrentWeaponProficiency = newProficieny;
    }

    public void CalculateBaseDamage(int str, int lvl)
    {
        BaseDamage = (int)Mathf.Clamp(Mathf.RoundToInt((str * 2) + (lvl * 2f) - 10), 1, Mathf.Infinity);
    }
    public void CalculateAttackDamage()
    {
        AttackDamage = Mathf.RoundToInt((CurrentWeaponDamage + BaseDamage) + (Level * (CurrentWeaponProficiency / 10)));
    }
    public void CalcAllDamage()
    {
        CalculateBaseDamage(Strength, Level);
        CalculateAttackDamage();
        if(debug)
        {
            Debug.Log("Base Damage: " + BaseDamage + " Attack Damage: " + AttackDamage);
        }
    }
    void Start ()
    {
        CalcAllDamage();
	}
	
	void Update ()
    {
		
	}
}
