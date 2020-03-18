using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStatus : MonoBehaviour
{
    public Button Level2, Level3, Level4, Level5, NextHB1,  //Hub World 1
         Level7, Level8, Level9, Level10, NextHB2, //Hub World 2
         Level12, Level13, Level14, Level15, NextHB3, //Hub World 3
         Level17, Level18, Level19, Level20, NextHB4, //Hub World 4
         Level22, Level23, Level24, Level25, NextHB5, //Hub World 5
         Level27, Level28, Level29, Level30, NextHB6, //Hub World 6
         Level32, Level33, Level34, Level35; //Final Hub World
    public GameObject HubLv1, HubLv2, HubLv3, HubLv4, HubLv5, HubLv6, HubLv7;
    int clevel;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<DoNotDestroy>().PlayMusic();
        if(PlayerPrefs.GetString("CurrentUser") == "User1") clevel = PlayerPrefs.GetInt("LevelPlayer1");
        else if (PlayerPrefs.GetString("CurrentUser") == "User2") clevel = PlayerPrefs.GetInt("LevelPlayer2");
        if(clevel>=31) {HubLv1.SetActive(false); HubLv7.SetActive(true);}
        else if(clevel>=26) {HubLv1.SetActive(false); HubLv6.SetActive(true);}
        else if(clevel>=21) {HubLv1.SetActive(false); HubLv5.SetActive(true);}
        else if(clevel>=16) {HubLv1.SetActive(false); HubLv4.SetActive(true);}
        else if(clevel>=11) {HubLv1.SetActive(false); HubLv3.SetActive(true);}
        else if(clevel>=6) {HubLv1.SetActive(false); HubLv2.SetActive(true);}
    }

    // Update is called once per frame
    void Update()
    {
        if(clevel >= 2) Level2.interactable = true;
         if (clevel >= 3) Level3.interactable = true;
         if (clevel >= 4) Level4.interactable = true;
         if (clevel >= 5) Level5.interactable = true;
         if (clevel >= 7) Level7.interactable = true;
         if (clevel >= 8) Level8.interactable = true;
         if (clevel >= 9) Level9.interactable = true;
         if (clevel >= 10) Level10.interactable = true;
         if (clevel >= 12) Level12.interactable = true;
         if (clevel >= 13) Level13.interactable = true;
         if (clevel >= 14) Level14.interactable = true;
         if (clevel >= 15) Level15.interactable = true;
         if (clevel >= 17) Level17.interactable = true;
         if (clevel >= 18) Level18.interactable = true;
         if (clevel >= 19) Level19.interactable = true;
         if (clevel >= 20) Level20.interactable = true;
         if (clevel >= 22) Level22.interactable = true;
         if (clevel >= 23) Level23.interactable = true;
         if (clevel >= 24) Level24.interactable = true;
         if (clevel >= 25) Level25.interactable = true;
         if (clevel >= 27) Level27.interactable = true;
         if (clevel >= 28) Level28.interactable = true;
         if (clevel >= 29) Level29.interactable = true;
         if (clevel >= 30) Level30.interactable = true;
         if (clevel >= 32) Level32.interactable = true;
         if (clevel >= 33) Level33.interactable = true;
         if (clevel >= 34) Level34.interactable = true;
         if (clevel >= 35) Level35.interactable = true;

        if(clevel >= 6) NextHB1.interactable = true;
         if (clevel >= 11) NextHB2.interactable = true;
         if (clevel >= 16) NextHB3.interactable = true;
         if (clevel >= 21) NextHB4.interactable = true;
         if (clevel >= 26) NextHB5.interactable = true;
         if (clevel >= 31) NextHB6.interactable = true;
    }
}
