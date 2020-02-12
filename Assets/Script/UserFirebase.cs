using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserFirebase
{
   public string userName;
//    public int userScore;
   public int userLvProg;

   public UserFirebase(){
       userName = PlayerScores.PlayerName;
    //    userScore = PlayerScores.PlayerScore;
       userLvProg = 1;
   }
}
