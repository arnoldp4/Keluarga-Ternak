using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProduceFood : MonoBehaviour
{
    Vector3 MP, targetPosition;
    public RawImage grassObj;
    public GameObject plain, WarningPanel, GrassCanvas;
    public Button telurBtn, LeafBtn, susuBtn, wolBtn, BeruangBtn, TikusBtn;

    //Bool buat matikan Coroutine
    public static bool OnOffLeaf;
    bool waktumati = false;
    float waktuMusuhSpawn = 15f; float waktuLeafHancur = 3f;
        int HPLeaf = 1;
    //Array buat posisi
    int[,] PosisiSpawn = new int[,] {{-230, -200, -155, -130, -115, -105, -75, -45, -15, 
        15, 45, 75, 105, 130, 170, 200, 230}, 
        {-90, -80, -75, -65, -55, -45, -35, -25, -15, -5, 
            5, 25, 45, 65, 85, 95, 105}};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waktumati == false)
        {waktuMusuhSpawn -= Time.deltaTime;
        if(waktuMusuhSpawn <= 0.0f) {
            int pilihMusuh = Random.Range(0, 10);
            if(pilihMusuh >= 5) SpawnBear(); else SpawnMole();
            waktuMusuhSpawn = 15f;
        }
        CheckingGO();
        if(GameObject.Find("BeruangBtn(Clone)")){
            BearActivity();
        }
        if (GameObject.Find("MoleBtn(Clone)")){
            MoleActivity();
        }
        if(LevelGameplay.UpgradeWell!=5){
            if(LevelGameplay.LevelWell!=0){
                WarningPanel.SetActive(false);
                SpawnGrass();
            }
            else{
                StartCoroutine(warningSumurHabis());
                StopCoroutine(warningSumurHabis());
            }
        } else{
            WarningPanel.SetActive(false); waktuLeafHancur = 1.5f;
            int RNGDoLeaf = Random.Range(0, 200);
            if(RNGDoLeaf == 104){
                if(OnOffLeaf == true) SpawnGrass();}
        }}
    }

    void SpawnGrass() {
        if(Time.timeScale != 0){
            if(LevelGameplay.UpgradeWell == 5){
                int x = Random.Range(0, 17); int y = Random.Range(0, 17);
                targetPosition = new Vector3(PosisiSpawn[0, x], PosisiSpawn[1, y], 0);
                var rumput = Instantiate(grassObj,targetPosition,Quaternion.identity);
                rumput.transform.SetParent(plain.transform, false);
                LevelGameplay.LevelMoney -= 7;
            }
        }
    }

    void CheckingGO(){
        if((GameObject.Find("Ayam(Clone)") || GameObject.Find("Sapi(Clone)") || GameObject.Find("Domba(Clone)")
            || GameObject.Find("AyamSakit(Clone)") || GameObject.Find("SapiSakit(Clone)") || GameObject.Find("DombaSakit(Clone)"))
            && GameObject.Find("Leaf(Clone)")){
            StartCoroutine ( desObj() );
            waktumati = true;
        }
    }
    void BearActivity(){
        int targetRNG = 69, RNGKill = Random.Range(0, 6), RNGDoIt = Random.Range(0, 70);
        if(GameObject.Find("Anjing(Clone)")) {
            RNGDoIt = Random.Range(0, 300);
            targetRNG = 248;
        }
        if(RNGDoIt == targetRNG){
            if(RNGKill == 0){
                Destroy(GameObject.Find("Ayam(Clone)"));
            } else if(RNGKill == 3){
                Destroy(GameObject.Find("AyamSakit(Clone)"));
            } else if (RNGKill == 1){
                Destroy(GameObject.Find("Sapi(Clone)")); 
            } else if (RNGKill == 4){
                Destroy(GameObject.Find("SapiSakit(Clone)"));
            } else if(RNGKill == 2){
                Destroy(GameObject.Find("Domba(Clone)")); 
            } else Destroy(GameObject.Find("DombaSakit(Clone)"));
        } 
    }
    void MoleActivity(){
        int RNGSteal = Random.Range(0, 3), RNGDoIt = Random.Range(0, 70);
        if(RNGDoIt == 69){
            if(RNGSteal == 0){
                Destroy(GameObject.Find("TelurBtn(Clone)"));
            } else if (RNGSteal == 1){
                Destroy(GameObject.Find("WoolBtn(Clone)"));
            } else{
                Destroy(GameObject.Find("SusuBtn(Clone)"));
            }
        } 
    }
#region Spawn Bahan Utama & Musuh
    void SpawnTelur()
    {
        int x = Random.Range(0, 17); int y = Random.Range(0, 17);
        targetPosition = new Vector3(PosisiSpawn[0, x], PosisiSpawn[1, y], 0);
        var telur = Instantiate(telurBtn,targetPosition,Quaternion.identity);
        telur.transform.SetParent(plain.transform, false);
        // Destroy(telur.gameObject, 5f);
    }
    void SpawnSusu(){
        int x = Random.Range(0, 17); int y = Random.Range(0, 17);
        targetPosition = new Vector3(PosisiSpawn[0, x], PosisiSpawn[1, y], 0);
        var susu = Instantiate(susuBtn,targetPosition,Quaternion.identity);
        susu.transform.SetParent(plain.transform, false);
        // Destroy(susu.gameObject, 5f);
    }
    void SpawnWol(){
        int x = Random.Range(0, 17); int y = Random.Range(0, 17);
        targetPosition = new Vector3(PosisiSpawn[0, x], PosisiSpawn[1, y], 0);
        var wol = Instantiate(wolBtn,targetPosition,Quaternion.identity);
        wol.transform.SetParent(plain.transform, false);
        // Destroy(wol.gameObject, 5f);
    }
    void SpawnBear(){
        int x = Random.Range(-130, 130);
        int y = Random.Range(-60, 50);
        targetPosition = new Vector3(x, y, 0);
        var beruang = Instantiate(BeruangBtn,targetPosition,Quaternion.identity);
        beruang.transform.SetParent(plain.transform, false);
        LevelGameplay.jumlahBeruang += 1;
    }
    void SpawnMole(){
        int x = Random.Range(-130, 130);
        int y = Random.Range(-60, 50);
        targetPosition = new Vector3(x, y, 0);
        var tikusTanah = Instantiate(TikusBtn,targetPosition,Quaternion.identity);
        tikusTanah.transform.SetParent(plain.transform, false);
    }
#endregion
    IEnumerator warningSumurHabis(){
        WarningPanel.SetActive(true);
        yield return new WaitForSeconds (3);
    }
    IEnumerator desObj(){
        if(Time.timeScale != 0){
            yield return new WaitForSeconds (waktuLeafHancur);
            int RNGWhoGetFirst = Random.Range(0, 50);
            if(GameObject.Find("Ayam(Clone)") && GameObject.Find("Leaf(Clone)") && (RNGWhoGetFirst >= 0 && RNGWhoGetFirst <= 14)){
                if(GameStatus.PickedEvent == "Musim Ayam"){
                    SpawnTelur(); SpawnTelur();
                } else SpawnTelur();
            } else if(GameObject.Find("Sapi(Clone)") && GameObject.Find("Leaf(Clone)") && (RNGWhoGetFirst >= 15 && RNGWhoGetFirst <= 30)){
                SpawnSusu();
            } else if(GameObject.Find("Domba(Clone)") && GameObject.Find("Leaf(Clone)") && (RNGWhoGetFirst >= 31 && RNGWhoGetFirst <= 50)){
                SpawnWol();
            } 
            if(HPLeaf == 0) {Destroy(GameObject.Find("Leaf(Clone)")); HPLeaf = 1;}
            else HPLeaf--;
            waktumati = false;
        }
    }
}
