using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasarTextManager : MonoBehaviour
{
    //Variable buat Update Pasar dan Upgrade
    public static int CostUpgradeWell, CostUpradeTransporter;
    public Text SirupTxt, TepungTxt, CatTxt, TotalBeliTxt,
        UpgradeTransporterTxt, UpgradeWellTxt, 
        CostTransporterTxt, CostWellTxt;
    public Slider PasarProgressBar;
    public Button UPTransporterBtn, UPWellBtn;
    public Button BuyBtnCek;
    int datangTransporter;
    // Start is called before the first frame update
    void Start()
    {
        PasarProgressBar.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelGameplay.LevelMoney <= 24) BuyBtnCek.interactable = false;
        else BuyBtnCek.interactable = true;
        if(LevelGameplay.LevelMoney <= CostUpgradeWell) UPWellBtn.interactable = false;
        else UPWellBtn.interactable = true;
        if(LevelGameplay.LevelMoney <= CostUpradeTransporter) UPTransporterBtn.interactable = false;
        else UPTransporterBtn.interactable = true;
        UpdateBeliPasar(); CheckingUpgrades();
        if(PasarManager.cekPesawat == true) LoadingDelivery();
    }
    void UpdateBeliPasar(){
        SirupTxt.text = "Sirup: " + PasarManager.beliSirup; TepungTxt.text = "Tepung: " + PasarManager.beliTepung;
        CatTxt.text = "Ember Cat: " + PasarManager.beliCat; 
        TotalBeliTxt.text = "Total Beli: " + PasarManager.totalbeli;
        UpgradeTransporterTxt.text = "Transporter Level: " + LevelGameplay.UpgradeTransporter;
        UpgradeWellTxt.text = "Sumur Level: " + LevelGameplay.UpgradeWell;
    }
    void CheckingUpgrades(){
        if(LevelGameplay.UpgradeWell == 1){
            CostWellTxt.text = "500"; CostUpgradeWell = 500;
            LevelGameplay.CostWell = 20; LevelGameplay.WellMax = 5;
        } else if (LevelGameplay.UpgradeWell == 2){
            CostWellTxt.text = "2000"; CostUpgradeWell = 2000;
            LevelGameplay.CostWell = 18; LevelGameplay.WellMax = 7;
        } else if(LevelGameplay.UpgradeWell == 3){
            CostWellTxt.text = "5000"; CostUpgradeWell = 5000;
            LevelGameplay.CostWell = 14; LevelGameplay.WellMax = 10;
        } else if(LevelGameplay.UpgradeWell == 4){
            CostWellTxt.text = "10000"; CostUpgradeWell = 10000;
            LevelGameplay.CostWell = 10; LevelGameplay.WellMax = 15;
        } else if(LevelGameplay.UpgradeWell == 5){
            CostWellTxt.text = "Maxed";
            LevelGameplay.CostWell = 7; UPWellBtn.interactable = false;
        }

        if(LevelGameplay.UpgradeTransporter == 1){
            CostTransporterTxt.text = "100"; CostUpradeTransporter = 100;
            LevelGameplay.TPDeliveryTime = 500; LevelGameplay.TransporterMax = 5;
        } else if(LevelGameplay.UpgradeTransporter == 2){
            CostTransporterTxt.text = "2500"; CostUpradeTransporter = 2500;
            LevelGameplay.TPDeliveryTime = 350; LevelGameplay.TransporterMax = 10;
        } else if(LevelGameplay.UpgradeTransporter == 3){
            CostTransporterTxt.text = "5000"; CostUpradeTransporter = 5000;
            LevelGameplay.TPDeliveryTime = 300; LevelGameplay.TransporterMax = 15;
        } else if(LevelGameplay.UpgradeTransporter == 4){
            CostTransporterTxt.text = "10000"; CostUpradeTransporter = 10000;
            LevelGameplay.TPDeliveryTime = 250; LevelGameplay.TransporterMax = 20;
        } else if(LevelGameplay.UpgradeTransporter == 5){
            CostTransporterTxt.text = "Maxed";
            LevelGameplay.TPDeliveryTime = 150; LevelGameplay.TransporterMax = 25;
            UPTransporterBtn.interactable = false;
        }
    }
    void LoadingDelivery(){
        PasarProgressBar.gameObject.SetActive(true);

        if(datangTransporter <= 150 - 1){
            PasarProgressBar.value += 1f;
            datangTransporter ++;
        } else PasarManager.cekPesawat = false;

        if(PasarManager.cekPesawat == false){
            LevelGameplay.LevelSirup += PasarManager.beliSirup;
            LevelGameplay.LevelTepung += PasarManager.beliTepung;
            LevelGameplay.LevelCat += PasarManager.beliCat;
            PasarManager.beliSirup = 0; PasarManager.beliTepung = 0; PasarManager.beliCat = 0;
            PasarManager.totalbeli = 0; PasarManager.jumlahbeli = 0; PasarProgressBar.value = PasarProgressBar.minValue;
            datangTransporter = 0; PasarManager.ctrBeli = false; PasarManager.cekPesawat = false;
            PasarProgressBar.gameObject.SetActive(false);}
    }
}
