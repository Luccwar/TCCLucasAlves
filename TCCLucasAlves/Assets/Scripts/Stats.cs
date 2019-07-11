using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{

    private int health;

    public int maxHP = 3;

    public int Health
    {
        get
        {
            //Some code
            return health;
        }
        set
        {
            //Some code
            health = Mathf.Clamp(value, 0, maxHP);
        }
    }
    public void SetHealth()
    {
        Health = maxHP;
    }


}
