using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeHasil : MonoBehaviour
{
    int ctrBeruangTangkap = 0, ctrTikusTanah;
    Image gambarSekarang; Sprite gambarAwal;
    
    void Start(){
        gambarSekarang = gameObject.GetComponent<Image>();
        gambarAwal = gambarSekarang.sprite;
    }
    public void TakeTelur(Sprite differentSprite){
        gambarSekarang.sprite = differentSprite;
        StartCoroutine("EggPressed");
    }
    public void TakeSusu(Sprite differentSprite){
        gambarSekarang.sprite = differentSprite;
        StartCoroutine("MilkPressed");
    }
    public void TakeWol(Sprite differentSprite){
        gambarSekarang.sprite = differentSprite;
        StartCoroutine("WoolPressed");
    }
    public void change(Sprite differentSprite)
    {
        gambarSekarang.sprite = differentSprite;
        StartCoroutine("mbalek");
    }
    public void LepasTikusTanah(Sprite differentSprite){
        gambarSekarang.sprite = differentSprite;
        StartCoroutine("lepasin");
    }

    IEnumerator mbalek()
    {
        yield return new WaitForSeconds(.5f);
        gambarSekarang.sprite = gambarAwal;
        if (ctrBeruangTangkap != 4) ctrBeruangTangkap++;
        else {
            Destroy(gameObject);
            // Destroy(GameObject.Find("BeruangBtn(Clone)"));
            ctrBeruangTangkap = 0; LevelGameplay.LevelMoney += 50; LevelGameplay.jumlahBeruang -= 1;} 
    }
    IEnumerator lepasin()
    {
        yield return new WaitForSeconds(.5f);
        gambarSekarang.sprite = gambarAwal;
        if (ctrTikusTanah != 2) ctrTikusTanah++;
        else {
            Destroy(gameObject);
            // Destroy(GameObject.Find("MoleBtn(Clone)"));
            ctrTikusTanah = 0;  LevelGameplay.LevelMoney += 25;}
    }
    IEnumerator EggPressed()
    {
        yield return new WaitForSeconds(.5f);
        gambarSekarang.sprite = gambarAwal;
        LevelGameplay.LevelTelur += 1;
        Destroy(gameObject);
        // Destroy(GameObject.Find("TelurBtn(Clone)"));
    }
    IEnumerator MilkPressed()
    {
        yield return new WaitForSeconds(.5f);
        gambarSekarang.sprite = gambarAwal;
        LevelGameplay.LevelSusu += 1;
        Destroy(gameObject);
        // Destroy(GameObject.Find("SusuBtn(Clone)"));
    }
    IEnumerator WoolPressed()
    {
        yield return new WaitForSeconds(.5f);
        gambarSekarang.sprite = gambarAwal;
        LevelGameplay.LevelWol += 1;
        Destroy(gameObject);
        // Destroy(GameObject.Find("WoolBtn(Clone)"));
    }
}
