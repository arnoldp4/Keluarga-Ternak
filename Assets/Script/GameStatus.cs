using System.Collections;
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
        PickedHubWorld = SceneName;
        SceneManager.LoadScene(SceneName);
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
        SceneManager.LoadScene(NamaHubLevel);
    }

    //Button buat ganti level selanjutnya
    public void LevelPicked(int LevelNumber){
        PickedLevel = LevelNumber;
    }
    public void NextLevelPicked(){
        if(PickedHubWorld == "Level1" && PickedLevel == 5){
            PickedHubWorld = "Level2"; PickedLevel = 1;
        } else if(PickedHubWorld == "Level2" && PickedLevel == 5){
            PickedHubWorld = "Level3"; PickedLevel = 1;
        } else if(PickedHubWorld == "Level3" && PickedLevel == 5){
            PickedHubWorld = "Level4"; PickedLevel = 1;
        } else if(PickedHubWorld == "Level4" && PickedLevel == 5){
            PickedHubWorld = "Level5"; PickedLevel = 1;
        } else if(PickedHubWorld == "Level5" && PickedLevel == 5){
            PickedHubWorld = "Level6"; PickedLevel = 1;
        } else if(PickedHubWorld == "Level6" && PickedLevel == 5){
            PickedHubWorld = "Level7"; PickedLevel = 1;
        } else {
            PickedLevel += 1;
        }
    }
    public void CurePress(){
        if(LevelGameplay.LevelMoney >= 125){
            LevelGameplay.CureProcess = true;
        }
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

    public void ChangeLeaf(){
        if(ProduceFood.LeafDeadManual == false){
            ProduceFood.LeafDeadManual = true;
        } else {
            ProduceFood.LeafDeadManual = false;
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
