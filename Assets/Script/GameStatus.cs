﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    public static string PickedHubWorld, PickedEvent; //buat tahu Hub World mana yang dipilih
    public static int PickedLevel; //buat ganti level
    string NamaHubLevel;
    
    //Button buat buka tutup scene/panel
    public void LoadScene(string SceneName){
        SceneManager.LoadScene(SceneName);
    }
    public void LoadGameplay(string SceneName){
        PickedHubWorld = SceneName;
        SceneManager.LoadScene("GameplayLevel");
    }
    public void BuatEvent(string EventName){
        PickedEvent = EventName;
    }
    public void OpenPanel(GameObject PanelName){
        PanelName.SetActive(true);
    }
    public void ClosePanel(GameObject PanelName){
        PanelName.SetActive(false);
    }
    public void pause(){
        Time.timeScale = 0;
    }
    public void resume(){
        Time.timeScale = 1;
    }
    public void AmbilHubLevel(){
        NamaHubLevel = SceneManager.GetActiveScene().name;
    }
    public void RestartHubLevel(){
        SceneManager.LoadScene("GameplayLevel");
    }

    //Button buat ganti level selanjutnya
    public void LevelPicked(int LevelNumber){
        PickedLevel = LevelNumber;
    }
    public void NextLevelPicked(){
        //Event Trigger
        if(PickedHubWorld == "Level1" && PickedLevel == 3){
            PickedLevel+=1; PickedEvent = "Musim Ayam";
            SceneManager.LoadScene("EventStory");
        } else if(PickedHubWorld == "Level1" && PickedLevel == 4){
            PickedLevel+=1; PickedEvent = "Hari Paskah";
            SceneManager.LoadScene("EventStory");
        } else if(PickedHubWorld == "Level5" && PickedLevel == 3){
            PickedLevel+=1; PickedEvent = "Imlek";
            SceneManager.LoadScene("EventStory");
        } else if(PickedHubWorld == "Level6" && PickedLevel == 4){
            PickedLevel+=1; PickedEvent = "Natal";
            SceneManager.LoadScene("EventStory");
        } else if(PickedHubWorld == "Level7" && PickedLevel == 3){
            PickedLevel+=1; PickedEvent = "Tahun Baru";
            SceneManager.LoadScene("EventStory");
        } else if(PickedHubWorld == "Level2" && PickedLevel == 4){
            PickedEvent = "Story3";
            SceneManager.LoadScene("MainStory");
        }
        
        //Buat ganti Hub-World langsung dari menu dan Story pada awal-awal hub-world
        else if(PickedHubWorld == "Level1" && PickedLevel == 5){
            PickedEvent = "Story2";
            SceneManager.LoadScene("MainStory");
        } else if(PickedHubWorld == "Level2" && PickedLevel == 5){
            PickedHubWorld = "Level3"; PickedLevel = 1;
            SceneManager.LoadScene("GameplayLevel");
        } else if(PickedHubWorld == "Level3" && PickedLevel == 5){
            PickedHubWorld = "Level4"; PickedLevel = 1;
            SceneManager.LoadScene("GameplayLevel");
        } else if(PickedHubWorld == "Level4" && PickedLevel == 5){
            PickedHubWorld = "Level5"; PickedLevel = 1;
            SceneManager.LoadScene("GameplayLevel");
        } else if(PickedHubWorld == "Level5" && PickedLevel == 5){
            PickedHubWorld = "Level6"; PickedLevel = 1;
            SceneManager.LoadScene("GameplayLevel");
        } else if(PickedHubWorld == "Level6" && PickedLevel == 5){
            PickedEvent = "FinalStory";
            SceneManager.LoadScene("MainStory");
        } else {
            PickedLevel += 1;
            SceneManager.LoadScene("GameplayLevel");
        }
    }
    public void CurePress(){
        if(LevelGameplay.LevelMoney >= 125){
            LevelGameplay.CureProcess = true;
        }
    }

    public void ChangeAchievement(bool warna){
        warna = true;
    }

    //Button buat in-game
    public void MaxChargeWell(){
        if(LevelGameplay.UpgradeWell != 5){
            if(LevelGameplay.LevelWell == 0 && LevelGameplay.LevelMoney >= LevelGameplay.CostWell){
                LevelGameplay.LevelWell = LevelGameplay.WellMax;
                LevelGameplay.LevelMoney -= LevelGameplay.CostWell;
            } 
        } else {
                if(ProduceFood.OnOffLeaf == false) ProduceFood.OnOffLeaf = true;
                    else ProduceFood.OnOffLeaf = false;
            }
    }

    public void Quit ()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit ();
        #endif
    }
 
}
