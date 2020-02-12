using System.Collections;
using System.Collections.Generic;
using FullSerializer;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;

public class LevelStatus : MonoBehaviour
{
    string pname;
    public GameObject Level2Btn, Level3Btn, 
        Level4Btn, Level5Btn, WarningTxt;
    UserFirebase user = new UserFirebase();
    // Start is called before the first frame update
    void Start()
    {
        pname = PlayerScores.PlayerName;
        RetrieveFromFirebase();
        WarningTxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RetrieveFromFirebase(){
        RestClient.Get<UserFirebase>("https://tugas-akhir-stts-2019.firebaseio.com/" +
           pname + ".json").Then(response =>{
               user = response;
               LockedLevel(user.userLvProg);
           });
    }
    void LockedLevel(int clevel){
        if(clevel >= 2){
            Level2Btn.SetActive(false);
        }
        if(clevel >= 3){
            Level3Btn.SetActive(false);
        }
        if(clevel >= 4){
            Level4Btn.SetActive(false);
        }
        if(clevel >= 5){
            Level5Btn.SetActive(false);
        }
    }
    public void LockedButton(){
        StartCoroutine (warning());
    }

    IEnumerator warning(){
        WarningTxt.SetActive(true);
        yield return new WaitForSeconds (1);
        WarningTxt.SetActive(false);
    }
}
