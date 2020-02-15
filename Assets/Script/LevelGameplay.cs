using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGameplay : MonoBehaviour
{
    //Variable buat cek uang dan well di ProduceFood
    public static int LevelMoney, LevelWell, 
        WellMax, TransporterMax, UpgradeWell, UpgradeTransporter,
        CostWell, TPDeliveryTime,
        LevelTelur, LevelTlrKering, LevelKue, //Bahan dari Telur
        LevelSusu, LevelButter, LevelKeju, //Bahan dari Sapi
        LevelWol, LevelBenang, LevelKain, //Bahan dari Domba
        LevelSirup, LevelPancake, LevelTepung, LevelPizza, LevelCat, LevelBaju; //Bahan khusus untuk bangunan tertentu
    //Variable buat apply yang ada di Level
    public Text FloatTxt, CurrentLvlTxt, 
        PasarMoneyTxt, TransporterMoneyTxt, StorageMoneyTxt, MoneyTxt, WellTxt, GoalTxt, BtnWellTxt,
        TelurTxt, TlrKeringTxt, KueTxt,
        SusuTxt, MentegaTxt, KejuTxt,
        WolTxt, BenangTxt, KainTxt, 
        SirupTxt, PancakeTxt, TepungTxt, PizzaTxt, CatTxt, BajuTxt;
    public static bool CureProcess;
    
    //Variable buat satu level
    string namagoal, kondisiEvent; int targetgoal; //Goal yang berlaku 1 goal saja

    //Variable buat selesai level
    public GameObject GameCanvas, ResultCanvas,
        BuildPanel, EggPanel, MilkPanel, WoolPanel,
        PancakePanel, PizzaPanel, ClothesPanel, FloatText;
    public RawImage AyamObj, SapiObj, DombaObj, AnjingObj, KucingObj,
        AyamSakitObj, SapiSakitObj, DombaSakitObj;
    public Button TransporterBtn, AyamBtn, SapiBtn, DombaBtn, AnjingBtn, KucingBtn, BeruangObj, TikusObj,
        DEHLock, DEH, BakeryLock, Bakery,
        DairyLock, Dairy, CheeseLock, Cheese,
        SpinneryLock, Spinnery, FabricLock, Fabric,
        ChangePancake, ChangePizza, ChangeClothes,
        PancakeLock, Pancake, PizzaLock, Pizza, 
        BoutiqueLock, Boutique, SembuhBtn;
    Vector3 targetPosition;
    Random randomSpawn = new Random();
    bool sudahNaikLevel = false, mauSpecial = false,
        cekPancakeKeluar = false, cekPizzaKeluar = false, cekBajuKeluar = false;
    int LevelSapi = 0;
    float timerKucing = 7f;
    public static int LevelPicked, TutorialRumput;

    // Start is called before the first frame update
    void Start()
    {
        sudahNaikLevel = false; TransporterMax = 5; TPDeliveryTime = 500;
        ResultCanvas.SetActive(false);
        RevertAllIngredientsToZero();
            SpecialIngredients(true, true, true, true);
        if(GameStatus.PickedHubWorld == "Level1" && GameStatus.PickedLevel == 1){
            LevelMoney = 100; LevelWell = 5;
            targetgoal = 10; namagoal = "Rumput";
            BuildPanel.SetActive(false); LevelPicked = 1;
            GoalTxt.text = "Goals: \r\n";
            GoalTxt.text = GoalTxt.text + namagoal + ": " + targetgoal;
        }
        else if(GameStatus.PickedHubWorld == "Level1" && GameStatus.PickedLevel == 2){
            BuatLevel(300, 5, 5, "Telur");
            ApplyLevel(false, false, false, false, false, false, false, 2);
        }
        else if(GameStatus.PickedHubWorld == "Level1" && GameStatus.PickedLevel == 3){
            BuatLevel(200, 5, 2, "Telur Kering");
            ApplyLevel(true, true, false, false, false, false, false, 3);
        }   
        else if(GameStatus.PickedHubWorld == "Level1" && GameStatus.PickedLevel == 4){
            BuatLevel(300, 5, 20, "Telur");
            ApplyLevel(true, true, false, false, false, false, false, 2);
        }   
        else if(GameStatus.PickedHubWorld == "Level1" && GameStatus.PickedLevel == 5){
            BuatLevel(500, 5, 2500, "Uang");
            ApplyLevel(true, true, false, false, false, false, false, 2);
        }
        else if(GameStatus.PickedHubWorld == "Level7" && GameStatus.PickedLevel == 5){
            BuatLevel(10000, 5, 50000, "Uang");
            ApplyLevel(true, true, true, true, true, true, true, 35);
        }
        CurrentLvlTxt.text = "Level " + GameStatus.PickedLevel.ToString();
    }

    // void TestLevel(int money, int well, int totalgoal){
    //     LevelMoney = money; LevelWell = well; cgoal = totalgoal;
    //     RevertAllIngredientsToZero();
    //     MoneyTxt.text = "Uang: " + LevelMoney; WellTxt.text = "Sumur: " + LevelWell;
    //     GoalTxt.text = "Goals: \r\n";
    //     for(int i = 0; i < totalgoal; i++){
    //         GoalTxt.text = GoalTxt.text + goallist[i] + ": " + tsgoal[i] + " \r\n";
    //     }
    // }

    void RevertAllIngredientsToZero(){
        LevelTelur = 0; LevelTlrKering = 0; LevelKue = 0;
        LevelSusu = 0; LevelButter = 0; LevelKeju = 0;
        LevelWol = 0; LevelBenang = 0; LevelKain = 0;
        LevelSirup = 0; LevelTepung = 0; LevelCat = 0;
        LevelPancake = 0; LevelPizza = 0; LevelBaju = 0;
        TransporterMax = 5; WellMax = 5;
        CostWell = 20; TPDeliveryTime = 500;
        mauSpecial = false; CureProcess = false;
        UpgradeTransporter = 1; UpgradeWell = 1;
    }

    void BuatLevel(int money, int well, int goal, string tgoal){
        LevelMoney = money; LevelWell = well; targetgoal = goal; namagoal = tgoal;
        RevertAllIngredientsToZero();
        MoneyTxt.text = "Uang: " + LevelMoney; WellTxt.text = "Sumur: " + LevelWell;
        GoalTxt.text = "Goals: \r\n";
        GoalTxt.text = GoalTxt.text + namagoal + ": " + targetgoal;
    }
    void ApplyLevel(bool bpanel, bool ePanel, bool mPanel, 
        bool wPanel, bool paPanel, bool pzPanel, bool clPanel, int lvlpick){
        BuildPanel.SetActive(bpanel); LevelPicked = lvlpick;
        if(bpanel == true){
            DEHLock.interactable = true; BakeryLock.interactable = true;
            DairyLock.interactable = true; CheeseLock.interactable = true;
            SpinneryLock.interactable = true; FabricLock.interactable = true;
            PancakeLock.interactable = true; PizzaLock.interactable = true;
            BoutiqueLock.interactable = true; EggPanel.SetActive(ePanel);
            MilkPanel.SetActive(mPanel); WoolPanel.SetActive(wPanel);
            DEH.gameObject.SetActive(false); DEH.interactable = false;
            Bakery.gameObject.SetActive(false); Bakery.interactable = false;
            Dairy.gameObject.SetActive(false); Dairy.interactable = false;
            Cheese.gameObject.SetActive(false); Cheese.interactable = false;
            Spinnery.gameObject.SetActive(false); Spinnery.interactable = false;
            Fabric.gameObject.SetActive(false); Fabric.interactable = false;
            Pancake.gameObject.SetActive(false); Pancake.interactable = false;
            Pizza.gameObject.SetActive(false); Pizza.interactable = false;
            Boutique.gameObject.SetActive(false); Boutique.interactable = false;
            PancakePanel.SetActive(paPanel); PizzaPanel.SetActive(pzPanel);
            ClothesPanel.SetActive(clPanel);
        }
    }
    void SpecialIngredients(bool keluarspecial, bool pancakeSpecial, bool pizzaSpecial, bool clothesSpecial){
        if(keluarspecial == true){
            mauSpecial = true;
            if(pancakeSpecial == true){
                cekPancakeKeluar = true;
            } if(pizzaSpecial == true){
                cekPizzaKeluar = true;
            } if(pancakeSpecial == true){
                cekBajuKeluar = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        PasarMoneyTxt.text = TransporterMoneyTxt.text = StorageMoneyTxt.text = MoneyTxt.text = "Uang: " + LevelMoney; 
        if(UpgradeWell != 5) {WellTxt.text = "Sumur: " + LevelWell; BtnWellTxt.text = "Isi Sumur";}
            else {
                if(ProduceFood.OnOffLeaf == true) {WellTxt.text = "Sumur ON"; BtnWellTxt.text = "Matikan";}
                    else {WellTxt.text = "Sumur OFF"; BtnWellTxt.text = "Nyalakan";}
                }
        cheat1000MoneyPlusAllMatsPlus10();
        UpdateBahan(); UpdateSpecial(); Cure();
        if(timerKucing >= 0.0f) timerKucing -= Time.deltaTime;
        else {CheckingKucing(); timerKucing = 7f;}
        if(TransporterTextManager.cekTransporter == true) TransporterBtn.interactable = false;
        else TransporterBtn.interactable = true;
        //Cek kapan menang
#region IF untuk kondisi Menang
        if(TutorialRumput >= targetgoal && LevelPicked == 1) HasilResult();
        else if(LevelTelur >= targetgoal && LevelPicked == 2) HasilResult();
        else if(LevelTlrKering >= targetgoal && LevelPicked == 3) HasilResult();
        else if(LevelTelur >= targetgoal && LevelPicked == 4) HasilResult();
        else if(LevelMoney >= targetgoal && LevelPicked == 5) HasilResult();
#endregion
        //Cek Uang di bagian Binatang
        BinatangButtons();
    }

    void cheat1000MoneyPlusAllMatsPlus10(){
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            LevelMoney += 10000;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            LevelTelur = 10; LevelTlrKering = 10; LevelKue = 10;
            LevelSusu = 10; LevelButter = 10; LevelKeju = 10;
            LevelWol = 10; LevelBenang = 10; LevelKain = 10;
            LevelSirup = 10; LevelTepung = 10; LevelCat = 10;
            LevelPancake = 10; LevelPizza = 10; LevelBaju = 10;
        }
    }

    void UpdateBahan(){
        TelurTxt.text = "Telur: " + LevelTelur; TlrKeringTxt.text = "Telur Kering: " + LevelTlrKering;
        KueTxt.text = "Kue: " + LevelKue; SusuTxt.text = "Susu: " + LevelSusu;
        MentegaTxt.text = "Mentega: " + LevelButter; KejuTxt.text = "Keju: " + LevelKeju;
        WolTxt.text = "Wol: " + LevelWol; BenangTxt.text = "Benang: " + LevelBenang;
        KainTxt.text = "Kain: " + LevelKain; SirupTxt.text = "Sirup: " + LevelSirup;
        TepungTxt.text = "Tepung: " + LevelTepung; CatTxt.text = "Ember Cat: " + LevelCat;
        PancakeTxt.text = "Pancake: " + LevelPancake; PizzaTxt.text = "Pizza: " + LevelPizza;
        BajuTxt.text = "Baju: " + LevelBaju;
    }
    void UpdateSpecial(){
        if(mauSpecial == true && cekPancakeKeluar == true){
            if(LevelTelur >= 5) ChangePancake.gameObject.SetActive(true);
                else ChangePancake.gameObject.SetActive(false);
        }
        if(mauSpecial == true && cekPizzaKeluar == true){            
            if(LevelButter >= 5) ChangePizza.gameObject.SetActive(true);
                else ChangePizza.gameObject.SetActive(false);
        }
        if(mauSpecial == true && cekBajuKeluar == true){
            if(LevelKain >= 5) ChangeClothes.gameObject.SetActive(true);
                else ChangeClothes.gameObject.SetActive(false);
        }
    }

    void BinatangInteract(bool ayam, bool sapi, bool domba, bool anjing, bool kucing){
        AyamBtn.interactable = ayam; SapiBtn.interactable = sapi;
        DombaBtn.interactable = domba; AnjingBtn.interactable = anjing;
        KucingBtn.interactable = kucing;
    }
    void CheckingKucing(){
        if(GameObject.Find("Kucing(Clone)")){
            if(GameObject.Find("TelurBtn(Clone)")){
                Destroy(GameObject.Find("TelurBtn(Clone)")); LevelTelur++;
            } else if(GameObject.Find("SusuBtn(Clone)")){
                Destroy(GameObject.Find("SusuBtn(Clone)")); LevelSusu++;
            } else{
                Destroy(GameObject.Find("WoolBtn(Clone)")); LevelWol++;
            }}
    }
    void BinatangButtons(){if(LevelMoney <=90){
            BinatangInteract(false, false, false, false, false);    
        } else if(LevelMoney <= 390){
            BinatangInteract(true, false, false, false, false);
        } else if(LevelMoney <= 490){
            BinatangInteract(true, false, false, true, false);
        } else if(LevelMoney <= 790){
            BinatangInteract(true, true, false, true, false);
        } else if(LevelMoney <= 990){
            BinatangInteract(true, true, false, true, true);
        } else {
            BinatangInteract(true, true, true, true, true);
        }}
    void HasilResult(){
        GameCanvas.SetActive(false);
        ResultCanvas.SetActive(true);
        if(sudahNaikLevel == false){
        PlayerScores.PlayerLevel += 1;
        sudahNaikLevel = true;}
    }
    void Cure(){
        if(GameObject.Find("AyamSakit(Clone)") || GameObject.Find("SapiSakit(Clone)") || GameObject.Find("DombaSakit(Clone)")){
            SembuhBtn.interactable = true;
            if(CureProcess == true){
                if(GameObject.Find("AyamSakit(Clone)")){
                    SpawnAyam(); Destroy(GameObject.Find("AyamSakit(Clone)"));
                } else if(GameObject.Find("SapiSakit(Clone)")){
                    SpawnSapi(); Destroy(GameObject.Find("SapiSakit(Clone)"));
                } else if(GameObject.Find("DombaSakit(Clone)")){
                    SpawnDomba(); Destroy(GameObject.Find("DombaSakit(Clone)"));
                }
                CureProcess = false; LevelMoney -= 125;
            }
        } else SembuhBtn.interactable = false;
        
    }

    void Awake()
    {
        //Listener Hewan
        AyamBtn.onClick.AddListener(SpawnAyam);
        SapiBtn.onClick.AddListener(SpawnSapi);
        DombaBtn.onClick.AddListener(SpawnDomba);
        AnjingBtn.onClick.AddListener(SpawnAnjing);
        KucingBtn.onClick.AddListener(SpawnKucing);
        //Listener Bangunan yg belum dibuka
        DEHLock.onClick.AddListener(OpenDEH);
        BakeryLock.onClick.AddListener(OpenBakery);
        DairyLock.onClick.AddListener(OpenDairy);
        CheeseLock.onClick.AddListener(OpenCheeseFactory);
        SpinneryLock.onClick.AddListener(OpenSpinnery);
        FabricLock.onClick.AddListener(OpenFabricShop);
        PancakeLock.onClick.AddListener(OpenPancakeShop);
        PizzaLock.onClick.AddListener(OpenPizzaShop);
        BoutiqueLock.onClick.AddListener(OpenBoutique);
        //Listener Bangunan yang sudah dibuat
        DEH.onClick.AddListener(CreateDE);
        DEH.onClick.AddListener(NotifyDEHPressed);
        Bakery.onClick.AddListener(CreateCake);
        Dairy.onClick.AddListener(CreateButter);
        Cheese.onClick.AddListener(CreateCheese);
        Spinnery.onClick.AddListener(CreateYarn);
        Fabric.onClick.AddListener(CreateFabric);
        Pancake.onClick.AddListener(CreatePancake);
        Pizza.onClick.AddListener(CreatePizza);
        Boutique.onClick.AddListener(CreateClothes);
    }
#region Handle the onClick event
    #region Part 1: Spawn animals
    void SpawnAyam()
    {
        int x = Random.Range(-150, 150);
        int y = Random.Range(-50, 50);
        targetPosition = new Vector3(x, y, 0);
        if(CureProcess == false){
            int RNGSakit = Random.Range(0, 50);
            if(RNGSakit >= 25){
                var ayam = Instantiate(AyamSakitObj,targetPosition,Quaternion.identity);
                ayam.transform.SetParent(GameCanvas.transform, false);
            } else {
                var ayam = Instantiate(AyamObj,targetPosition,Quaternion.identity);
                ayam.transform.SetParent(GameCanvas.transform, false);
            }
            LevelMoney -= 100;
        } else {
                var ayam = Instantiate(AyamObj,targetPosition,Quaternion.identity);
                ayam.transform.SetParent(GameCanvas.transform, false);
        }
    }
    void SpawnSapi(){
        int x = Random.Range(-130, 130);
        int y = Random.Range(-50, 50);
        targetPosition = new Vector3(x, y, 0);
        if(CureProcess == false){
            int RNGSakit = Random.Range(0, 50);
            if(RNGSakit >= 25){
                var sapi = Instantiate(SapiSakitObj,targetPosition,Quaternion.identity);
                sapi.transform.SetParent(GameCanvas.transform, false);
            } else {
                var sapi = Instantiate(SapiObj,targetPosition,Quaternion.identity);
                sapi.transform.SetParent(GameCanvas.transform, false);
            }
            LevelMoney -= 500;
            LevelSapi += 1;
        } else {
            var sapi = Instantiate(SapiObj,targetPosition,Quaternion.identity);
            sapi.transform.SetParent(GameCanvas.transform, false);
        }
    }
    void SpawnDomba(){
        int x = Random.Range(-130, 130);
        int y = Random.Range(-50, 50);
        targetPosition = new Vector3(x, y, 0);
        if(CureProcess == false){
            int RNGSakit = Random.Range(0, 50);
            if(RNGSakit >= 25){
                var domba = Instantiate(DombaSakitObj,targetPosition,Quaternion.identity);
                domba.transform.SetParent(GameCanvas.transform, false);
            } else {
                var domba = Instantiate(DombaObj,targetPosition,Quaternion.identity);
                domba.transform.SetParent(GameCanvas.transform, false);
            }
            LevelMoney -= 1000;
        } else {
            var domba = Instantiate(DombaObj,targetPosition,Quaternion.identity);
            domba.transform.SetParent(GameCanvas.transform, false);
        }
    }
    void SpawnAnjing(){
        int x = Random.Range(-130, 130);
        int y = Random.Range(-50, 50);
        targetPosition = new Vector3(x, y, 0);
        var sapi = Instantiate(AnjingObj,targetPosition,Quaternion.identity);
        sapi.transform.SetParent(GameCanvas.transform, false);
        LevelMoney -= 400;
    }
    void SpawnKucing(){
        int x = Random.Range(-130, 130);
        int y = Random.Range(-50, 50);
        targetPosition = new Vector3(x, y, 0);
        var sapi = Instantiate(KucingObj,targetPosition,Quaternion.identity);
        sapi.transform.SetParent(GameCanvas.transform, false);
        LevelMoney -= 800;
    }
    #endregion
    #region Part 2: Buildings
    void OpenDEH(){
        if(LevelMoney >= 200)
        {DEHLock.interactable = false;
        DEHLock.gameObject.SetActive(false);
        DEH.gameObject.SetActive(true);
        DEH.interactable = true;
        LevelMoney -= 200;
        }
    }
    void NotifyDEHPressed(){
        FloatTxt.text = "+1 Telur Kering";
        Vector3 targetPosition = new Vector3(DEHLock.transform.position.x-115, DEH.transform.position.y-150, 0);
        Debug.Log(DEH.transform.position.x + " & " + DEH.transform.position.y);
        var floatingtxt = Instantiate(FloatText,targetPosition,Quaternion.identity);
        floatingtxt.transform.SetParent(EggPanel.transform, false);
    }
    void OpenBakery(){
        if(LevelMoney >= 400){
            BakeryLock.interactable = false;
            BakeryLock.gameObject.SetActive(false);
            Bakery.gameObject.SetActive(true);
            Bakery.interactable = true; LevelMoney -= 400;
        }
    }
    void OpenDairy(){
        if(LevelMoney >= 600){
            DairyLock.interactable = false;
            DairyLock.gameObject.SetActive(false);
            Dairy.gameObject.SetActive(true);
            Dairy.interactable = true; LevelMoney -= 600;
        }
    }
    void OpenCheeseFactory(){
        if(LevelMoney >= 800){
            CheeseLock.interactable = false;
            CheeseLock.gameObject.SetActive(false);
            Cheese.gameObject.SetActive(true);
            Cheese.interactable = true; LevelMoney -= 800;
        }
    }
    void OpenSpinnery(){
        if(LevelMoney >= 1500){
            SpinneryLock.interactable = false;
            SpinneryLock.gameObject.SetActive(false);
            Spinnery.gameObject.SetActive(true);
            Spinnery.interactable = true; LevelMoney -= 1500;
        }
    }
    void OpenFabricShop(){
        if(LevelMoney >= 2000){
            FabricLock.interactable = false;
            FabricLock.gameObject.SetActive(false);
            Fabric.gameObject.SetActive(true);
            Fabric.interactable = true; LevelMoney -= 2000;
        }
    }
    void OpenPancakeShop(){
        if(LevelMoney >= 550){
            PancakeLock.interactable = false;
            PancakeLock.gameObject.SetActive(false);
            Pancake.gameObject.SetActive(true);
            Pancake.interactable = true; LevelMoney -= 550;
        }
    }
    void OpenPizzaShop(){
        if(LevelMoney >= 1250){
            PizzaLock.interactable = false;
            PizzaLock.gameObject.SetActive(false);
            Pizza.gameObject.SetActive(true);
            Pizza.interactable = true; LevelMoney -= 1250;
        }
    }
    void OpenBoutique(){
        if(LevelMoney >= 4250){
            BoutiqueLock.interactable = false;
            BoutiqueLock.gameObject.SetActive(false);
            Boutique.gameObject.SetActive(true);
            Boutique.interactable = true; LevelMoney -= 4250;
        }
    }
    #endregion
    #region Part 3: Products
    void CreateDE(){
        if(LevelTelur != 0){
        LevelTlrKering += 1; LevelTelur -= 1;}
    }
    void CreateCake(){
        if(LevelTlrKering != 0){
        LevelKue += 1; LevelTlrKering -= 1;}
    }
    void CreateButter(){
        if(LevelSusu != 0){
        LevelTlrKering += 1; LevelTelur -= 1;}
    }
    void CreateCheese(){
        if(LevelButter != 0){
        LevelKeju += 1; LevelButter -= 1;}
    }
    void CreateYarn(){
        if(LevelWol != 0){
        LevelBenang += 1; LevelWol -= 1;}
    }
    void CreateFabric(){
        if(LevelBenang != 0){
        LevelKain += 1; LevelBenang -= 1;}
    }
    void CreatePancake(){
        if(LevelTelur >= 2 && LevelSirup != 0){
            LevelPancake += 1; LevelTelur -= 2; LevelSirup --;
        }
    }
    void CreatePizza(){
            Debug.Log("Berhasil masuk untuk buat Pizza!");
        if(LevelButter >= 3 && LevelTepung >= 3){
            LevelPizza ++; LevelButter -= 3; LevelTepung -= 3;
        }
    }
    void CreateClothes(){
        if(LevelKain >= 4 && LevelCat >= 5){
            LevelBaju ++; LevelKain -= 4; LevelCat -=5;
        }
    }
    #endregion
#endregion
}
