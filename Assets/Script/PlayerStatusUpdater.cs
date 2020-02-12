using System.Collections;
using System.Collections.Generic;
using FullSerializer;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUpdater : MonoBehaviour
{
    string pname;
    public Text StatusPNama, StatusPLevel;
    UserFirebase user = new UserFirebase();
    // Update is called once per frame
    void Start()
    {
        pname = PlayerScores.PlayerName;
        RetrieveFromFirebase();
    }
    public void UpdateStatus(){
        StatusPNama.text = "Player's Name: " + user.userName;
        StatusPLevel.text = "Level Completed: " + user.userLvProg;
    }
    private void RetrieveFromFirebase(){
        RestClient.Get<UserFirebase>("https://tugas-akhir-stts-2019.firebaseio.com/" +
           pname + ".json").Then(response =>{
               user = response;
               UpdateStatus();
           });
    }
}
