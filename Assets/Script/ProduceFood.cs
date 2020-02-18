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
    public static bool LeafDeadManual, OnOffLeaf;
    float waktuMusuhSpawn = 30f; float waktuLeafHancur = 2f;
    //Array buat posisi
    int[,] PosisiSpawn = new int[,] {{-155, -130, -115, -105, -75, -45, -15, 15, 45, 75, 105, 115, 130, 155, 170, 190}, 
        {-75, -65, -55, -45, -35, -25, -15, -5, 5, 15, 25, 35, 45, 55, 65, 75}};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waktuMusuhSpawn -= Time.deltaTime;
        if(waktuMusuhSpawn <= 0.0f) {
            int pilihMusuh = Random.Range(0, 2);
            if(pilihMusuh == 0) SpawnBear(); else SpawnMole();
            waktuMusuhSpawn = 30f;
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
        }
    }

    void SpawnGrass() {
        if(LevelGameplay.UpgradeWell != 5){
            if(Input.GetMouseButtonDown(0) && LeafDeadManual == false)
            {
                MP=Input.mousePosition;
                //Convert the targetPosition according to Mouse Position 
                // targetPosition = new Vector3(MP.x-405, MP.y-100, 0); //Bagian SpawnGrass untuk yang di Asus
                targetPosition = new Vector3(MP.x-505, MP.y-120, 0); //Untuk Mac
                float cekx = targetPosition.x - plain.transform.position.x,
                    ceky = targetPosition.y - plain.transform.position.y;
                // if(cekx >= -580 && cekx <= -230 && ceky <= 80 && ceky >= -60) //Bagian SpawnGrass untuk yang di Asus
                Debug.Log("Cek X: " + cekx + " Cek Y: " + ceky);
                if(cekx >= -760 && cekx <= -250 && ceky >= -258 && ceky <= -30)
                {
                    LevelGameplay.LevelWell-=1; var grass = Instantiate(grassObj,targetPosition,Quaternion.identity);
                    grass.transform.SetParent(plain.transform, false);
                    if(LevelGameplay.LevelPicked == 1){
                        LevelGameplay.TutorialRumput += 1;
                    }
                }
            }
        } else {
            int x = Random.Range(0, 12); int y = Random.Range(0, 12);
            targetPosition = new Vector3(PosisiSpawn[0, x], PosisiSpawn[1, y], 0);
            var rumput = Instantiate(grassObj,targetPosition,Quaternion.identity);
            rumput.transform.SetParent(plain.transform, false);
            LevelGameplay.LevelMoney -= 7;
        }
    }

    void CheckingGO(){
        if (LeafDeadManual == false) TurnRed();
        else TurnWhite();
        if((GameObject.Find("Ayam(Clone)") || GameObject.Find("Sapi(Clone)") || GameObject.Find("Domba(Clone)")
            || GameObject.Find("AyamSakit(Clone)") || GameObject.Find("SapiSakit(Clone)") || GameObject.Find("DombaSakit(Clone)"))
            && GameObject.Find("Leaf(Clone)")){
            StartCoroutine ( desObj() );
        }
    }
    void BearActivity(){
        int targetRNG = 69, RNGKill = Random.Range(0, 3), RNGDoIt = Random.Range(0, 70);
        if(GameObject.Find("Anjing(Clone)")) {
            RNGDoIt = Random.Range(0, 300);
            targetRNG = 248;
        }
        if(RNGDoIt == targetRNG){
            if(RNGKill == 0){
                Destroy(GameObject.Find("Ayam(Clone)"));
            } else if (RNGKill == 1){
                Destroy(GameObject.Find("Sapi(Clone)"));
            } else{
                Destroy(GameObject.Find("Domba(Clone)"));
            }
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
    public void TurnRed()
    {
        ColorBlock colors = LeafBtn.colors;
        colors.normalColor = Color.red;
        colors.highlightedColor = new Color32(100, 100, 100, 100);
        LeafBtn.colors = colors;
    }
    public void TurnWhite()
    {
        ColorBlock colors = LeafBtn.colors;
        colors.normalColor = Color.white;
        colors.highlightedColor = new Color32(225, 225, 225, 255);
        LeafBtn.colors = colors;
    }
#region Spawn Bahan Utama & Musuh
    void SpawnTelur()
    {
        int x = Random.Range(0, 12);
        int y = Random.Range(0, 12);
        targetPosition = new Vector3(PosisiSpawn[0, x], PosisiSpawn[1, y], 0);
        var telur = Instantiate(telurBtn,targetPosition,Quaternion.identity);
        telur.transform.SetParent(plain.transform, false);
    }
    void SpawnSusu(){
        int x = Random.Range(-140, 140);
        int y = Random.Range(-55, 50);
        targetPosition = new Vector3(x, y, 0);
        var susu = Instantiate(susuBtn,targetPosition,Quaternion.identity);
        susu.transform.SetParent(plain.transform, false);
    }
    void SpawnWol(){
        int x = Random.Range(-130, 130);
        int y = Random.Range(-60, 60);
        targetPosition = new Vector3(x, y, 0);
        var wol = Instantiate(wolBtn,targetPosition,Quaternion.identity);
        wol.transform.SetParent(plain.transform, false);
    }
    void SpawnBear(){
        int x = Random.Range(-130, 130);
        int y = Random.Range(-60, 50);
        targetPosition = new Vector3(x, y, 0);
        var beruang = Instantiate(BeruangBtn,targetPosition,Quaternion.identity);
        beruang.transform.SetParent(plain.transform, false);
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
        yield return new WaitForSeconds (waktuLeafHancur);
        int RNGWhoGetFirst = Random.Range(0, 4);
        if(GameObject.Find("Ayam(Clone)") && GameObject.Find("Leaf(Clone)") && RNGWhoGetFirst == 0){
            if(GameStatus.PickedEvent == "Musim Ayam"){
                SpawnTelur(); SpawnTelur();
            } else SpawnTelur();
        } else if(GameObject.Find("Sapi(Clone)") && GameObject.Find("Leaf(Clone)") && RNGWhoGetFirst == 1){
            SpawnSusu();
        } else if(GameObject.Find("Domba(Clone)") && GameObject.Find("Leaf(Clone)") && RNGWhoGetFirst == 2){
            SpawnWol();
        } if((GameObject.Find("Ayam(Clone)") || GameObject.Find("SapiSakit(Clone)") ||
            GameObject.Find("DombaSakit(Clone)")) && GameObject.Find("Leaf(Clone)") && RNGWhoGetFirst == 3){
            Destroy(GameObject.Find("Leaf(Clone)"));
        }
        Destroy(GameObject.Find("Leaf(Clone)"));
    }
}
