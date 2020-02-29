using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public Text achieveText;
    public GameObject ResultScreen;
    string UserSekarangIni;
    bool cekComplete, cekEaster, cekCat, cekCow,
        cekWol, cekDomba, cekDog;
        
    void Start()
    {
        if(PlayerPrefs.GetString("CurrentUser") == "User1") UserSekarangIni = "User1";
        else if (PlayerPrefs.GetString("CurrentUser") == "User2") UserSekarangIni = "User2";
    }

    void Update()
    {
        if(ResultScreen.activeInHierarchy == true){
            if(GameStatus.PickedHubWorld == "Level7" && GameStatus.PickedLevel == 5){
                if(UserSekarangIni == "User1" && PlayerPrefs.GetString("CompleteUser1") == "N"){
                    PlayerPrefs.SetString("CompleteUser1", "Y");
                } else if(UserSekarangIni == "User2" && PlayerPrefs.GetString("CompleteUser2") == "N"){
                    PlayerPrefs.SetString("CompleteUser2", "Y");
                }
                cekComplete = true;
            } else if(GameStatus.PickedEvent == "Hari Paskah"){
                if(UserSekarangIni == "User1" && PlayerPrefs.GetString("EasterUser1") == "N"){
                    PlayerPrefs.SetString("EasterUser1", "Y");
                } else if(UserSekarangIni == "User2" && PlayerPrefs.GetString("EasterUser2") == "N"){
                    PlayerPrefs.SetString("EasterUser2", "Y");
                }
                cekEaster = true;
            } else if(LevelGameplay.LevelKucing >= 1){
                if(UserSekarangIni == "User1" && PlayerPrefs.GetString("CatUser1") == "N"){
                    PlayerPrefs.SetString("CatUser1", "Y");
                } else if(UserSekarangIni == "User2" && PlayerPrefs.GetString("CatUser2") == "N"){
                    PlayerPrefs.SetString("CatUser2", "Y");
                }
                cekCat = true;
            } else if(LevelGameplay.CekAchieveDomba == true){
                if(UserSekarangIni == "User1" && PlayerPrefs.GetString("SheepUser1") == "N"){
                    PlayerPrefs.SetString("SheepUser1", "Y");
                } else if(UserSekarangIni == "User2" && PlayerPrefs.GetString("SheepUser2") == "N"){
                    PlayerPrefs.SetString("SheepUser2", "Y");
                }
                cekDomba = true;
            } else if(LevelGameplay.CekAchieveWol == true){
                if(UserSekarangIni == "User1" && PlayerPrefs.GetString("WoolUser1") == "N"){
                    PlayerPrefs.SetString("WoolUser1", "Y");
                } else if(UserSekarangIni == "User2" && PlayerPrefs.GetString("WoolUser2") == "N"){
                    PlayerPrefs.SetString("WoolUser2", "Y");
                }
                cekWol = true;
            } else if(LevelGameplay.CekAchieveSapi == true){
                if(UserSekarangIni == "User1" && PlayerPrefs.GetString("CowUser1") == "N"){
                    PlayerPrefs.SetString("CowUser1", "Y");
                } else if(UserSekarangIni == "User2" && PlayerPrefs.GetString("CowUser2") == "N"){
                    PlayerPrefs.SetString("CowUser2", "Y");
                }
                cekCow = true;
            } else if(LevelGameplay.LevelAnjing >= 5){
                if(UserSekarangIni == "User1" && PlayerPrefs.GetString("DogUser1") == "N"){
                    PlayerPrefs.SetString("DogUser1", "Y");
                } else if(UserSekarangIni == "User2" && PlayerPrefs.GetString("DogUser2") == "N"){
                    PlayerPrefs.SetString("DogUser2", "Y");
                }
                cekDog = true;
            }
        }

        TextofAchieve();
    }

    void TextofAchieve(){
        if(cekDog == true || cekDomba == true || cekEaster == true || cekWol == true
            || cekCat == true || cekCow == true || cekComplete == true){
                achieveText.gameObject.SetActive(true);
                achieveText.text = "Selamat!! Anda mendapatkan Achievement:\n\r";
                if(cekComplete == true) achieveText.text += "Completionist\n\r";
                if(cekEaster == true) achieveText.text += "Happy Easter!!\n\r";
                if(cekCow == true) achieveText.text += "MOWverlous\n\r";
                if(cekDomba == true) achieveText.text += "Anew Shepard\n\r";
                if(cekWol == true) achieveText.text += "Fluffyness\n\r";
                if(cekCat == true) achieveText.text += "CFF Ever!\n\r";
                if(cekDog == true) achieveText.text += "Too much DFF!!\n\r";
            } else achieveText.gameObject.SetActive(false);
        Debug.Log(achieveText.text);
    }
}
