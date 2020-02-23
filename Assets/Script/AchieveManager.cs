using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveManager : MonoBehaviour
{
    public Button CompleteBtn, EasterBtn, FirstCatBtn, FirstCowBtn, 
        TwelveWoolBtn, SheepsBtn, DogsBtn;
    bool cekComplete, cekEaster, cekCat, cekCow,
        cekWol, cekDomba, cekDog;
    public Text DescAchi;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("CurrentUser") == "User1"){
            if(PlayerPrefs.GetString("CompleteUser1") == "Y") cekComplete = true; else cekComplete = false;
            if(PlayerPrefs.GetString("EasterUser1") == "Y") cekEaster = true; else cekEaster = false;
            if(PlayerPrefs.GetString("CatUser1") == "Y") cekCat = true; else cekCat = false;
            if(PlayerPrefs.GetString("CowUser1") == "Y") cekCow = true; else cekCow = false;
            if(PlayerPrefs.GetString("WoolUser1") == "Y") cekWol = true; else cekWol = false;
            if(PlayerPrefs.GetString("SheepUser1") == "Y") cekDomba = true; else cekDomba = false;
            if(PlayerPrefs.GetString("DogUser1") == "Y") cekDog = true; else cekDog = false;
        } else if(PlayerPrefs.GetString("CurrentUser") == "User2"){
            if(PlayerPrefs.GetString("CompleteUser2") == "Y") cekComplete = true; else cekComplete = false;
            if(PlayerPrefs.GetString("EasterUser2") == "Y") cekEaster = true; else cekEaster = false;
            if(PlayerPrefs.GetString("CatUser2") == "Y") cekCat = true; else cekCat = false;
            if(PlayerPrefs.GetString("CowUser2") == "Y") cekCow = true; else cekCow = false;
            if(PlayerPrefs.GetString("WoolUser2") == "Y") cekWol = true; else cekWol = false;
            if(PlayerPrefs.GetString("SheepUser2") == "Y") cekDomba = true; else cekDomba = false;
            if(PlayerPrefs.GetString("DogUser2") == "Y") cekDog = true; else cekDog = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ColorBlock cbComplete = CompleteBtn.colors;
        if(cekComplete == false) {cbComplete.normalColor = Color.black;
        cbComplete.highlightedColor = Color.black;}
        else{cbComplete.normalColor = Color.white;
        cbComplete.highlightedColor = Color.white;}
        cbComplete.pressedColor = Color.black;
        CompleteBtn.colors = cbComplete;
        
        ColorBlock cbEaster = EasterBtn.colors;
        if(cekEaster == false) {cbEaster.normalColor = Color.black;
        cbEaster.highlightedColor = Color.black;}
        else {cbEaster.normalColor = Color.white;
        cbEaster.highlightedColor = Color.white;}
        cbEaster.pressedColor = Color.black;
        EasterBtn.colors = cbEaster;
        
        ColorBlock cbCat = FirstCatBtn.colors;
        if(cekCat == false) {cbCat.normalColor = Color.black;
        cbCat.highlightedColor = Color.black;}
        else {cbCat.normalColor = Color.white;
        cbCat.highlightedColor = Color.white;}
        cbCat.pressedColor = Color.black;
        FirstCatBtn.colors = cbCat;
        
        ColorBlock cbCow = FirstCowBtn.colors;
        if(cekCow == false) {cbCow.normalColor = Color.black;
        cbCow.highlightedColor = Color.black;}
        else{cbCow.normalColor = Color.white;
        cbCow.highlightedColor = Color.white;}
        cbCow.pressedColor = Color.black;
        FirstCowBtn.colors = cbCow;
        
        ColorBlock cbWool = TwelveWoolBtn.colors;
        if(cekWol == false) {cbWool.normalColor = Color.black;
        cbWool.highlightedColor = Color.black;}
        else {cbWool.normalColor = Color.white;
        cbWool.highlightedColor = Color.white;}
        cbWool.pressedColor = Color.black;
        TwelveWoolBtn.colors = cbWool;
        
        ColorBlock cbDomba = SheepsBtn.colors;
        if(cekDomba == false) {cbDomba.normalColor = Color.black;
        cbDomba.highlightedColor = Color.black;}
        else {cbDomba.normalColor = Color.white;
        cbDomba.highlightedColor = Color.white;}
        cbDomba.pressedColor = Color.black;
        SheepsBtn.colors = cbDomba;
        
        ColorBlock cbDogs = DogsBtn.colors;
        if(cekDog == false) {cbDogs.normalColor = Color.black;
        cbDogs.highlightedColor = Color.black;}
        else {cbDogs.normalColor = Color.white;
        cbDogs.highlightedColor = Color.white;}
        cbDogs.pressedColor = Color.black;
        DogsBtn.colors = cbDogs;
    }

    public void BeriDesc(string desc){
        DescAchi.text = desc;
    }
}
