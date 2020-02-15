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
        jualpancake = 0, jualpizza = 0, jualbaju = 0;
    public static bool ctrJual = false;
#endregion
#region Jual Bahan Lewat Transporter
    public void RevertAllStaticToZero(){
        totaljual = 0; jumlahjual = 0; jualtelur = 0; jualde = 0; jualkue = 0;
        jualsusu = 0; jualbutter = 0; jualkeju = 0;
        jualwol = 0; jualbenang = 0; jualkain = 0;
        jualsirup = 0; jualtepung = 0; jualcat = 0;
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
        if(LevelGameplay.LevelTelur != 0 && jualtelur <= LevelGameplay.LevelTelur && ctrJual == false){
            if(GameStatus.PickedEvent == "Hari Paskah") totaljual += 60;
                else totaljual += 20;
            jualtelur += 1;
        }
    }
    public void SellDE(){
        cekBatasTransporter();
        if(LevelGameplay.LevelTlrKering!=0 && jualde <= LevelGameplay.LevelTlrKering && ctrJual == false){
            totaljual += 100;
            jualde += 1;
        }
    }
    public void SellCake(){
        cekBatasTransporter();
        if(LevelGameplay.LevelKue!=0 && jualkue <= LevelGameplay.LevelKue && ctrJual == false){
            totaljual += 150;
            jualkue += 1;
        }
    }
#endregion
#region Bahan Utama Susu
    public void SellMilk(){
        cekBatasTransporter();
        if(LevelGameplay.LevelSusu!=0 && jualsusu <= LevelGameplay.LevelSusu && ctrJual == false){
            totaljual += 200;
            jualsusu += 1;
        }
    }
    public void SellButter(){
        cekBatasTransporter();
        if(LevelGameplay.LevelButter!=0 && jualbutter <= LevelGameplay.LevelButter && ctrJual == false){
            totaljual += 400;
            jualbutter += 1;
        }
    }
    public void SellCheese(){
        cekBatasTransporter();
        if(LevelGameplay.LevelKeju!=0 && jualkeju <= LevelGameplay.LevelKeju && ctrJual == false){
            totaljual += 800;
            jualkeju += 1;
        }
    }
#endregion
#region Bahan Utama Wol  
    public void SellWool(){
        cekBatasTransporter();
        if(LevelGameplay.LevelWol!=0 && jualwol <= LevelGameplay.LevelWol && ctrJual == false){
            totaljual += 250;
            jualwol += 1;
        }
    }
    public void SellYarn(){
        cekBatasTransporter();
        if(LevelGameplay.LevelBenang!=0 && jualbenang <= LevelGameplay.LevelBenang && ctrJual == false){
            totaljual += 750;
            jualbenang += 1;
        }
    }
    public void SellFabric(){
        cekBatasTransporter();
        if(LevelGameplay.LevelKain!=0 && jualkain <= LevelGameplay.LevelKain && ctrJual == false){
            totaljual += 1500;
            jualkain += 1;
        }
    }
#endregion
#region Bahan Khusus
    public void SellSyrup(){
        cekBatasTransporter();
        if(LevelGameplay.LevelSirup!=0 && jualsirup <= LevelGameplay.LevelSirup && ctrJual == false){
            totaljual += 10;
            jualsirup += 1;
        }
    }
    public void SellFlour(){
        cekBatasTransporter();
        if(LevelGameplay.LevelTepung!=0 && jualtepung <= LevelGameplay.LevelTepung && ctrJual == false){
            totaljual += 15;
            jualtepung += 1;
        }
    }
    public void SellPaintCan(){
        cekBatasTransporter();
        if(LevelGameplay.LevelCat!=0 && jualcat <= LevelGameplay.LevelCat && ctrJual == false){
            totaljual += 50;
            jualcat += 1;
        }
    }
    public void SellPancake(){
        cekBatasTransporter();
        if(LevelGameplay.LevelPancake!=0 && jualpancake <= LevelGameplay.LevelPancake && ctrJual == false){
            totaljual += 350;
            jualpancake += 1;
        }
    }
    public void SellPizza(){
        cekBatasTransporter();
        if(LevelGameplay.LevelPizza!=0 && jualpizza <= LevelGameplay.LevelPizza && ctrJual == false){
            totaljual += 1000;
            jualpizza += 1;
        }
    }
    public void SellClothes(){
        cekBatasTransporter();
        if(LevelGameplay.LevelBaju!=0 && jualbaju <= LevelGameplay.LevelBaju && ctrJual == false){
            totaljual += 3000;
            jualbaju += 1;
        }
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
        ctrJual = true; TransporterTextManager.cekTransporter = true;
    }
#endregion
}
