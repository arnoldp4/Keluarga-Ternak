using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporterManager : MonoBehaviour
{
#region  Variable buat Transporter
    public static int totaljual = 0, jumlahjual = 0, jualtelur = 0, jualde = 0, jualkue = 0,
        jualsusu = 0, jualbutter = 0, jualkeju = 0,
        jualwol = 0, jualbenang = 0, jualkain = 0,
        jualsirup = 0, jualtepung = 0, jualcat = 0,
        jualpancake = 0, jualpizza = 0, jualbaju = 0,
        jualayam = 0, jualsapi = 0, jualdomba = 0;
    public static bool ctrJual = false;
#endregion
#region Jual Bahan Lewat Transporter
    public void RevertAllStaticToZero(){
        totaljual = 0; jumlahjual = 0; jualtelur = 0; jualde = 0; jualkue = 0;
        jualsusu = 0; jualbutter = 0; jualkeju = 0;
        jualwol = 0; jualbenang = 0; jualkain = 0;
        jualsirup = 0; jualtepung = 0; jualcat = 0;
        jualayam = 0; jualsapi = 0; jualdomba = 0;
        jualpancake = 0; jualpizza = 0; jualbaju = 0; ctrJual = false;
    }
    void cekBatasTransporter(){
        if(jumlahjual >= LevelGameplay.TransporterMax){
            Debug.Log("Jumlah Jual: " + jumlahjual + " dengan Batasan: " + LevelGameplay.TransporterMax);
            ctrJual = true;
        } else { jumlahjual++; }
    }
#region Bahan Utama Telur
    public void SellEgg(){
        cekBatasTransporter();
        if(LevelGameplay.LevelTelur != 0 && jualtelur < LevelGameplay.LevelTelur && ctrJual == false){
            if(GameStatus.PickedEvent == "Hari Paskah") totaljual += 60;
                else totaljual += 20;
            jualtelur += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
    public void SellDE(){
        cekBatasTransporter();
        if(LevelGameplay.LevelTlrKering!=0 && jualde < LevelGameplay.LevelTlrKering && ctrJual == false){
            totaljual += 100;
            jualde += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
    public void SellCake(){
        cekBatasTransporter();
        if(LevelGameplay.LevelKue!=0 && jualkue <= LevelGameplay.LevelKue && ctrJual == false){
            totaljual += 150;
            jualkue += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
#endregion
#region Bahan Utama Susu
    public void SellMilk(){
        cekBatasTransporter();
        if(LevelGameplay.LevelSusu!=0 && jualsusu < LevelGameplay.LevelSusu && ctrJual == false){
            totaljual += 200;
            jualsusu += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
    public void SellButter(){
        cekBatasTransporter();
        if(LevelGameplay.LevelButter!=0 && jualbutter < LevelGameplay.LevelButter && ctrJual == false){
            totaljual += 400;
            jualbutter += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
    public void SellCheese(){
        cekBatasTransporter();
        if(LevelGameplay.LevelKeju!=0 && jualkeju < LevelGameplay.LevelKeju && ctrJual == false){
            totaljual += 800;
            jualkeju += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
#endregion
#region Bahan Utama Wol  
    public void SellWool(){
        cekBatasTransporter();
        if(LevelGameplay.LevelWol!=0 && jualwol < LevelGameplay.LevelWol && ctrJual == false){
            totaljual += 250;
            jualwol += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
    public void SellYarn(){
        cekBatasTransporter();
        if(LevelGameplay.LevelBenang!=0 && jualbenang < LevelGameplay.LevelBenang && ctrJual == false){
            totaljual += 750;
            jualbenang += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
    public void SellFabric(){
        cekBatasTransporter();
        if(LevelGameplay.LevelKain!=0 && jualkain < LevelGameplay.LevelKain && ctrJual == false){
            totaljual += 1500;
            jualkain += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
#endregion

#region Jual Hewan Produksi
    public void SellChicken(){
        cekBatasTransporter();
        if(LevelGameplay.LevelAyam!=0 && jualayam < LevelGameplay.LevelAyam && ctrJual == false){
            totaljual += 50;
            jualayam += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
    public void SellCow(){
        cekBatasTransporter();
        if(LevelGameplay.LevelSapi!=0 && jualsapi < LevelGameplay.LevelSapi && ctrJual == false){
            totaljual += 250;
            jualsapi += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
    public void SellSheep(){
        cekBatasTransporter();
        if(LevelGameplay.LevelDomba!=0 && jualdomba < LevelGameplay.LevelDomba && ctrJual == false){
            totaljual += 500;
            jualdomba += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
#endregion

#region Bahan Khusus
    public void SellSyrup(){
        cekBatasTransporter();
        if(LevelGameplay.LevelSirup!=0 && jualsirup < LevelGameplay.LevelSirup && ctrJual == false){
            totaljual += 10;
            jualsirup += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
    public void SellFlour(){
        cekBatasTransporter();
        if(LevelGameplay.LevelTepung!=0 && jualtepung < LevelGameplay.LevelTepung && ctrJual == false){
            totaljual += 15;
            jualtepung += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
    public void SellPaintCan(){
        cekBatasTransporter();
        if(LevelGameplay.LevelCat!=0 && jualcat < LevelGameplay.LevelCat && ctrJual == false){
            totaljual += 50;
            jualcat += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
    public void SellPancake(){
        cekBatasTransporter();
        if(LevelGameplay.LevelPancake!=0 && jualpancake < LevelGameplay.LevelPancake && ctrJual == false){
            totaljual += 350;
            jualpancake += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
    public void SellPizza(){
        cekBatasTransporter();
        if(LevelGameplay.LevelPizza!=0 && jualpizza < LevelGameplay.LevelPizza && ctrJual == false){
            totaljual += 1000;
            jualpizza += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
    public void SellClothes(){
        cekBatasTransporter();
        if(LevelGameplay.LevelBaju!=0 && jualbaju < LevelGameplay.LevelBaju && ctrJual == false){
            totaljual += 3000;
            jualbaju += 1;
        } else if (jumlahjual != 0) jumlahjual--;
    }
#endregion
    public void ApplyToTransport(){
        LevelGameplay.LevelTelur -= jualtelur;
        LevelGameplay.LevelTlrKering -= jualde;
        LevelGameplay.LevelKue -= jualkue;
        LevelGameplay.LevelSusu -= jualsusu;
        LevelGameplay.LevelButter -= jualbutter;
        LevelGameplay.LevelKeju -= jualkeju;
        LevelGameplay.LevelWol -= jualwol;
        LevelGameplay.LevelBenang -= jualbenang;
        LevelGameplay.LevelKain -= jualkain;
        LevelGameplay.LevelSirup -= jualsirup;
        LevelGameplay.LevelTepung -= jualtepung;
        LevelGameplay.LevelCat -= jualcat;
        LevelGameplay.LevelPancake -= jualpancake;
        LevelGameplay.LevelPizza -= jualpizza;
        LevelGameplay.LevelBaju -= jualbaju;
        LevelGameplay.LevelAyam -= jualayam;
        LevelGameplay.LevelSapi -= jualsapi;
        LevelGameplay.LevelDomba -= jualdomba;
        hancurJual();
        ctrJual = true; TransporterTextManager.cekTransporter = true;
    }

    void hancurJual(){
        if(jualayam != 0)
        {for(int i = 0; i <= jualayam; i++){
            Debug.Log("Ayam Terjual");
            if(GameObject.Find("Ayam(Clone)")) Destroy(GameObject.Find("Ayam(Clone)"));
                else Destroy(GameObject.Find("AyamSakit(Clone)"));
        }}

        if(jualsapi != 0)
        {for(int i = 0; i <= jualsapi; i++){
            if(GameObject.Find("Sapi(Clone)")) Destroy(GameObject.Find("Sapi(Clone)"));
                else Destroy(GameObject.Find("SapiSakit(Clone)"));
        }}

        if(jualdomba != 0)
        {for(int i = 0; i <= jualdomba; i++){
            if(GameObject.Find("Domba(Clone)")) Destroy(GameObject.Find("Domba(Clone)"));
                else Destroy(GameObject.Find("DombaSakit(Clone)"));
        }}
    }

#endregion
}
