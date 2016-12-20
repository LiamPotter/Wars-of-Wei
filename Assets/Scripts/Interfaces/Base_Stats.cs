using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Base_Stats {

    int Level { get; set; }
    int Strength{ get; set; }
    int Intelligence { get; set; }
    int Agility { get; set; }
    int Endurance { get; set; }
    int Wisdom { get; set; }
    int BaseDamage { get; set; }
    int AttackDamage { get; set; }

    void AddTo(int x, int y);
    void CalculateBaseDamage(int str, int lvl);
}
