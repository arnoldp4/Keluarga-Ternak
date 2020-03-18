using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransporterTextManager : MonoBehaviour
{
    //Variable buat update yang ada di Tranporter Menu
    public Text ApplySellTxt, 
        TelurTxt, TlrKeringTxt, KueTxt,
        SusuTxt, MentegaTxt, KejuTxt,
        WolTxt, BenangTxt, KainTxt,
        SirupTxt, TepungTxt, CatTxt,
        PancakeTxt, PizzaTxt, BajuTxt,
        AyamTxt, SapiTxt, DombaTxt;
    public static bool cekTransporter = false;
    public Slider TPProgressBar;
    public Button SellBtnCek;
    int datangTransporter, kembaliTransporter;

    void Start() {
        
    }
    // Update is called once per frame
    void Update()
    {
        TPProgressBar.maxValue = LevelGameplay.TPDeliveryTime;
        if (TransporterManager.jumlahjual == 0) SellBtnCek.interactable = false;
        else SellBtnCek.interactable = true;
        UpdateBahan();
        if(cekTransporter == true) LoadingDelivery();
    }

    void UpdateBahan(){
        TelurTxt.text = "Telur: " + TransporterManager.jualtelur; TlrKeringTxt.text = "Telur Kering: " + TransporterManager.jualde;
        KueTxt.text = "Kue: " + TransporterManager.jualkue; SusuTxt.text = "Susu: " + TransporterManager.jualsusu;
        MentegaTxt.text = "Mentega: " + TransporterManager.jualbutter; KejuTxt.text = "Keju: " + TransporterManager.jualkeju;
        WolTxt.text = "Wol: " + TransporterManager.jualwol; BenangTxt.text = "Benang: " + TransporterManager.jualbenang;
        KainTxt.text = "Kain: " + TransporterManager.jualkain; SirupTxt.text = "Sirup: " + TransporterManager.jualsirup;
        TepungTxt.text = "Tepung: " + TransporterManager.jualtepung; CatTxt.text = "Ember Cat: " + TransporterManager.jualcat;
        PancakeTxt.text = "Pancake: " + TransporterManager.jualpancake; PizzaTxt.text = "Pizza: " + TransporterManager.jualpizza;
        BajuTxt.text = "Baju: " + TransporterManager.jualbaju; AyamTxt.text = "Ayam: " + TransporterManager.jualayam;
        SapiTxt.text = "Sapi: " + TransporterManager.jualsapi; DombaTxt.text = "Domba: " + TransporterManager.jualdomba;
        ApplySellTxt.text = "Total Jual: " + TransporterManager.totaljual + " [Max: " + LevelGameplay.TransporterMax + "]";
    }

    void LoadingDelivery(){
        TPProgressBar.gameObject.SetActive(true);

        if(datangTransporter <= LevelGameplay.TPDeliveryTime - 1){
            TPProgressBar.value += 1f;
            datangTransporter ++;
        } else if(datangTransporter == LevelGameplay.TPDeliveryTime && kembaliTransporter <= LevelGameplay.TPDeliveryTime - 1){
            TPProgressBar.value -= 1f;
            kembaliTransporter ++;
        } else cekTransporter = false;

        if(cekTransporter == false){
        LevelGameplay.LevelMoney += TransporterManager.totaljual;
        TransporterManager.totaljual = 0; TPProgressBar.value = TPProgressBar.minValue;
        datangTransporter = 0; kembaliTransporter = 0; cekTransporter = false;
        TPProgressBar.gameObject.SetActive(false);}
    }

    
}
