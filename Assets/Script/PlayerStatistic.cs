using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[System.Serializable]
public class PlayerStatistic
{
    public string userName;
    public float userScore;
    public float userLvProg;
    public int userLevel;

    public PlayerStatistic(DataPlayer player){
        
    }
}