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
        WolTxt, BenangTxt, KainTxt;
    public static bool cekTransporter = false;
    public Slider TPProgressBar;
    public Button SellBtnCek;
    int datangTransporter, kembaliTransporter;
    bool ctrDatangKembali = false;

    void Start() {
        TPProgressBar.maxValue = LevelGameplay.TPDeliveryTime;
    }
    // Update is called once per frame
    void Update()
    {
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
        KainTxt.text = "Kain: " + TransporterManager.jualkain; ApplySellTxt.text = "Total Jual: " + TransporterManager.totaljual;
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
        datangTransporter = 0; kembaliTransporter = 0; ctrDatangKembali = false; cekTransporter = false;
        TPProgressBar.gameObject.SetActive(false);}
    }
}
