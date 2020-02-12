using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporterManager : MonoBehaviour
{
#region  Variable buat Transporter
    public static int totaljual = 0, jumlahjual = 0, jualtelur = 0, jualde = 0, jualkue = 0,
        jualsusu = 0, jualbutter = 0, jualkeju = 0,
        jualwol = 0, jualbenang = 0, jualkain = 0;
    public static bool ctrJual = false;
#endregion
#region Jual Bahan Lewat Transporter
    public void RevertAllStaticToZero(){
        totaljual = 0; jumlahjual = 0; jualtelur = 0; jualde = 0; jualkue = 0;
        jualsusu = 0; jualbutter = 0; jualkeju = 0;
        jualwol = 0; jualbenang = 0; jualkain = 0; ctrJual = false;
    }
    void cekBatasTransporter(){
        if(jumlahjual >= LevelGameplay.TransporterMax){
            Debug.Log("Jumlah Jual: " + jumlahjual + " dengan Batasan: " + LevelGameplay.TransporterMax);
            ctrJual = true;
        } else { jumlahjual++; }
    }
    public void SellEgg(){
        cekBatasTransporter();
        if(LevelGameplay.LevelTelur != 0 && jualtelur <= LevelGameplay.LevelTelur && ctrJual == false){
            totaljual += 20;
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
        ctrJual = true; TransporterTextManager.cekTransporter = true;
    }
#endregion
}
