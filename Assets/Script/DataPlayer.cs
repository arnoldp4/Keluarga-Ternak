using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPlayer : MonoBehaviour
{
    //Test SAVE LOAD JSON
    public Text namaTxt, User1NameTxt, User1LevelTxt, CurrentUserTxt,
        User2NameTxt, User2LevelTxt, WelcomeTxt;
    public static bool CreatedUser1, CreatedUser2;
    public Button User1Btn, CreatedUser1Btn, User2Btn, CreatedUser2Btn,
        DeleteUser1Btn, DeleteUser2Btn;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("NamaPlayer1") != "NULL") CreatedUser1 = true;
            else CreatedUser1 = false;
        if(PlayerPrefs.GetString("NamaPlayer2") != "NULL") CreatedUser2 = true;
            else CreatedUser2 = false;
        Debug.Log("User 1: " + CreatedUser1 + " & " + CreatedUser2);
    }

    public void SavePrefs(){
        if(CreatedUser1 == false)
        {if(CreateUserChoice.cekCreateUser == "User1"){
            if(namaTxt.text == "Arnold"){
                PlayerPrefs.SetString("NamaPlayer1", namaTxt.text);
                PlayerPrefs.SetInt("LevelPlayer1", 35);
                CreatedUser1 = true;
                PlayerPrefs.Save();
            }
            else {
                PlayerPrefs.SetString("NamaPlayer1", namaTxt.text);
                PlayerPrefs.SetInt("LevelPlayer1", 1);
                CreatedUser1 = true;
                PlayerPrefs.Save();
            }
        }}
        if(CreatedUser2 == false){
        if(CreateUserChoice.cekCreateUser == "User2"){
            PlayerPrefs.SetString("NamaPlayer2", namaTxt.text);
            PlayerPrefs.SetInt("LevelPlayer2", 1);
            CreatedUser2 = true;
            PlayerPrefs.Save();
        }}
    }
    public void LoadPrefs(string PilihUser){
        if(PilihUser == "User1"){
            PlayerPrefs.SetString("CurrentUser", "User1");
            CurrentUserTxt.text = "Current Player:" + "\r\n" + PlayerPrefs.GetString("NamaPlayer1");
        } else if (PilihUser == "User2"){
            PlayerPrefs.SetString("CurrentUser", "User2");
            CurrentUserTxt.text = "Current Player:" + "\r\n" + PlayerPrefs.GetString("NamaPlayer2");
        }
        PlayerPrefs.Save();
    }
    public void DeletePrefs(string UserDelete){
        if(UserDelete == "User1") {CreatedUser1 = false; PlayerPrefs.SetString("NamaPlayer1", "NULL");}
            else {CreatedUser2 = false; PlayerPrefs.SetString("NamaPlayer2", "NULL");}
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if(CreatedUser1 == true){
            User1Btn.gameObject.SetActive(false);
            CreatedUser1Btn.gameObject.SetActive(true);
            DeleteUser1Btn.gameObject.SetActive(true);
            User1NameTxt.text = PlayerPrefs.GetString("NamaPlayer1");
            User1LevelTxt.text = "Level " + PlayerPrefs.GetInt("LevelPlayer1").ToString();
        } else {
            User1Btn.gameObject.SetActive(true);
            CreatedUser1Btn.gameObject.SetActive(false);
            DeleteUser1Btn.gameObject.SetActive(false);
        }

        if(CreatedUser2 == true){
            User2Btn.gameObject.SetActive(false);
            CreatedUser2Btn.gameObject.SetActive(true);
            DeleteUser2Btn.gameObject.SetActive(true);
            User2NameTxt.text = PlayerPrefs.GetString("NamaPlayer2");
            User2LevelTxt.text = "Level " + PlayerPrefs.GetInt("LevelPlayer2").ToString();
        } else {
            User2Btn.gameObject.SetActive(true);
            CreatedUser2Btn.gameObject.SetActive(false);
            DeleteUser2Btn.gameObject.SetActive(false);
        }
        if(PlayerPrefs.GetString("CurrentUser") == "User1")
            {CurrentUserTxt.text = "Current Player:" + "\r\n" + PlayerPrefs.GetString("NamaPlayer1");
            WelcomeTxt.text = "Welcome, " + PlayerPrefs.GetString("NamaPlayer1");}
        else if (PlayerPrefs.GetString("CurrentUser") == "User2")
            {CurrentUserTxt.text = "Current Player:" + "\r\n" + PlayerPrefs.GetString("NamaPlayer2");
            WelcomeTxt.text = "Welcome, " + PlayerPrefs.GetString("NamaPlayer2");}
    }
}
