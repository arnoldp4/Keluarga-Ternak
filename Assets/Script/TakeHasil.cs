using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeHasil : MonoBehaviour
{
    int ctrBeruangTangkap = 0, ctrTikusTanah;
    Image beruangSekarang; Sprite beruangAwal;

    void Start(){
        beruangSekarang = gameObject.GetComponent<Image>();
        beruangAwal = beruangSekarang.sprite;
    }
    public void TakeTelur(){
        LevelGameplay.LevelTelur += 1;
        Destroy(GameObject.Find("TelurBtn(Clone)"));
    }
    public void TakeSusu(){
        LevelGameplay.LevelSusu += 1;
        Destroy(GameObject.Find("SusuBtn(Clone)"));
    }
    public void TakeWol(){
        LevelGameplay.LevelWol += 1;
        Destroy(GameObject.Find("WoolBtn(Clone)"));
    }
    public void change(Sprite differentSprite)
    {
        beruangSekarang.sprite = differentSprite;
        Debug.Log("Ganti ke gambar Baru " + differentSprite); 
        StartCoroutine("mbalek");
    }

    IEnumerator mbalek()
    {
        yield return new WaitForSeconds(.5f);
        beruangSekarang.sprite = beruangAwal;
        if (ctrBeruangTangkap != 4) ctrBeruangTangkap++;
        else {Destroy(GameObject.Find("BeruangBtn(Clone)"));
            ctrBeruangTangkap = 0;} 
    }
    public void LepasTikusTanah(){
        if (ctrTikusTanah != 2) ctrTikusTanah++;
        else {Destroy(GameObject.Find("MoleBtn(Clone)"));
            ctrTikusTanah = 0;}
    }
}
