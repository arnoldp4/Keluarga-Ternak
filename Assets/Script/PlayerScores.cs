using System.Collections;
using System.Collections.Generic;
using FullSerializer;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour
{
    //Variable yang diperlukan untuk dalam Scene
    public Text WelcomeText;
    public InputField nameText;
    public GameObject HiddenButtons, UserPanel;
    //Variable untuk ganti User
    private static int cuser = 1;
    //Variable untuk Firebase
    UserFirebase user = new UserFirebase();
    private System.Random rng = new System.Random();
    public static int PlayerScore, PlayerLevel;
    public static string PlayerName;
    

    // Start is called before the first frame update
    void Start()
    {
        PlayerName = "Albert";
        RetrieveFromFirebase();
        Debug.Log(PlayerLevel);
        WelcomeText.text = "Welcome, " + PlayerName;
        //PlayerScore = rng.Next(0, 101);
        // scoreText.text = "Score: " + PlayerScore;
    }

    public void OnSubmit(){
        PlayerName = nameText.text;
        PostToFirebase();
        UserPanel.SetActive(false);
        // PlayerScore = rng.Next(0, 101); 
        // scoreText.text = "Score: " + PlayerScore; nameText.text = "";
    }
    //Procedure Unity
    public void HideThings(){
        if(HiddenButtons.activeInHierarchy == false) HiddenButtons.SetActive(true);
        else HiddenButtons.SetActive(false);
    }
    public void UserChanged(){
        cuser++;
        if (cuser==4){
            cuser=1; PlayerName = "Arnold";
        } else if (cuser==2){
            PlayerName = "Albert";
        } else if (cuser==3){
            PlayerName = "Noni";
        }
            Debug.Log("User telah terganti menjadi: " + PlayerName);
    }

    //Procedure Firebase
    // public void OnGetScore(){
    //     RetrieveFromFirebase();
    // }   
    // public void UpdateScore(){
    //     scoreText.text = "Score: " + user.userScore;
    // }
    private void PostToFirebase(){
        RestClient.Put("https://tugas-akhir-stts-2019.firebaseio.com/" +
           PlayerName + ".json", user);
    }
    private void RetrieveFromFirebase(){
        RestClient.Get<UserFirebase>("https://tugas-akhir-stts-2019.firebaseio.com/" +
           PlayerName + ".json").Then(response =>{
               user = response;
               PlayerLevel = user.userLvProg;
           });
    }
}
