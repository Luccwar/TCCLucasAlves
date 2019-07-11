using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int currentLevel;

    public int currentExp;

    public int[] toLevelUp;


    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }

    void Update()
    {
        if (currentExp >= toLevelUp[currentLevel])
        {
            currentLevel++;
        }
    }
}
