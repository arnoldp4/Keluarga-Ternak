using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarManager : MonoBehaviour
{
#region  Variable buat Pasar
    public static int totalbeli = 0, jumlahbeli = 0, 
        beliSirup = 0, beliTepung = 0, beliCat = 0;
    public static bool cekPesawat = false, ctrBeli = false;
#endregion
    void cekBatasPesawatUang(){
        if(LevelGameplay.LevelMoney >= totalbeli){
            if(jumlahbeli >= 5){
                Debug.Log("Jumlah Beli: " + jumlahbeli + " dengan Batasan: 5");
                ctrBeli = true;
            } else { jumlahbeli++; }
        } else { ctrBeli = true; Debug.Log("Uang tidak cukup!"); }
    }
    public void RevertAllBuyToZero(){
        totalbeli = 0; jumlahbeli = 0;
        beliSirup = 0; beliTepung = 0; beliCat = 0;
        ctrBeli = false;
    }
    public void UpgradeWell(){
        LevelGameplay.UpgradeWell++;
        LevelGameplay.LevelMoney -= PasarTextManager.CostUpgradeWell;
    }
    public void UpgradeTransporter(){
        LevelGameplay.UpgradeTransporter++;
        LevelGameplay.LevelMoney-= PasarTextManager.CostUpradeTransporter;
    }
    public void BuySyrup(){
        cekBatasPesawatUang();
        if(ctrBeli == false){
            beliSirup++; totalbeli += 25;
        }
    }
    public void BuyFlour(){
        cekBatasPesawatUang();
        if(ctrBeli == false){
            beliTepung++; totalbeli += 50;
        }
    }
    public void BuyCanofPaint(){
        cekBatasPesawatUang();
        if(ctrBeli == false){
            beliCat++; totalbeli += 100;
        }
    }
    public void ApplyToBuy(){
        cekPesawat = true; ctrBeli = true; LevelGameplay.LevelMoney -= totalbeli;
    }
}
