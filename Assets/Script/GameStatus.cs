﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    public static int PickedLevel; //buat ganti level
    string NamaHubLevel;
    
    //Button buat buka tutup scene/panel
    public void LoadScene(string SceneName){
        SceneManager.LoadScene(SceneName);
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
        PickedLevel += 1;
    }

    //Button buat in-game
    public void MaxChargeWell(){
        if(LevelGameplay.UpgradeWell != 5){
            if(LevelGameplay.LevelWell == 0 && LevelGameplay.LevelMoney >= 7){
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
