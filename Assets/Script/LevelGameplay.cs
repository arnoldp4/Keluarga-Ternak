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
        PasarMoneyTxt, TransporterMoneyTxt, StorageMoneyTxt, MoneyTxt, WellTxt, GoalTxt, 
        TelurTxt, TlrKeringTxt, KueTxt,
        SusuTxt, MentegaTxt, KejuTxt,
        WolTxt, BenangTxt, KainTxt, 
        SirupTxt, PancakeTxt, TepungTxt, PizzaTxt, CatTxt, BajuTxt;
    
    //Variable buat satu level
    string namagoal; int targetgoal; //Goal yang berlaku 1 goal saja
    List<string> goallist = new List<string>(); //Goal yang lebih dari 1
    List<int> tsgoal = new List<int>(); int cgoal = 0; 

    //Variable buat selesai level
    public GameObject GameCanvas, ResultCanvas,
        BuildPanel, FloatText;
    public RawImage AyamObj, SapiObj, DombaObj, AnjingObj, KucingObj;
    public Button TransporterBtn, AyamBtn, SapiBtn, DombaBtn, AnjingBtn, KucingBtn, BeruangObj, TikusObj,
        DEHLock, DEH, BakeryLock, Bakery,
        DairyLock, Dairy, CheeseLock, Cheese,
        SpinneryLock, Spinnery, FabricLock, Fabric;
    Vector3 targetPosition;
    Random randomSpawn = new Random();
    bool sudahNaikLevel = false; int LevelSapi = 0;
    float timerKucing = 7f;
    public static int LevelPicked, TutorialRumput;

    // Start is called before the first frame update
    void Start()
    {
        sudahNaikLevel = false; TransporterMax = 5; TPDeliveryTime = 500;
        Debug.Log("Cek Transporter berstatus: " + TransporterTextManager.cekTransporter);
        RevertAllIngredientsToZero();
        if(GameStatus.PickedLevel == 1){
            LevelMoney = 100; LevelWell = 5;
            LevelTlrKering = 0; LevelTelur = 0; LevelSusu = 0; TutorialRumput = 0;
            targetgoal = 10; namagoal = "Rumput";
            BuildPanel.SetActive(false); LevelPicked = 1;
        }
        else if(GameStatus.PickedLevel == 2){
            BuatLevel(300, 5, 5, "Telur");
            ApplyLevel(false, 2);
        }
        else if(GameStatus.PickedLevel == 3){
            BuatLevel(200, 5, 2, "Telur Kering");
            ApplyLevel(true, 3);
        }   
        else if(GameStatus.PickedLevel == 4){
            BuatLevel(100, 5, 1, "Sapi");
            ApplyLevel(true, 4);
        }
        else if(GameStatus.PickedLevel == 5){
            goallist.Add("Kue"); goallist.Add("Keju"); goallist.Add("Kain");
            tsgoal.Add(10); tsgoal.Add(10); tsgoal.Add(10);
            TestLevel(500, 5, 2); ApplyLevel(true, 5);
        }
        CurrentLvlTxt.text = "Level: " + GameStatus.PickedLevel.ToString();
    }
    void TestLevel(int money, int well, int totalgoal){
        LevelMoney = money; LevelWell = well; cgoal = totalgoal;
        RevertAllIngredientsToZero();
        MoneyTxt.text = "Uang: " + LevelMoney; WellTxt.text = "Sumur: " + LevelWell;
        GoalTxt.text = "Goals: \r\n";
        for(int i = 0; i < totalgoal; i++){
            GoalTxt.text = GoalTxt.text + goallist[i] + ": " + tsgoal[i] + " \r\n";
        }
    }

    void RevertAllIngredientsToZero(){
        LevelTelur = 0; LevelTlrKering = 0; LevelKue = 0;
        LevelSusu = 0; LevelButter = 0; LevelKeju = 0;
        LevelWol = 0; LevelBenang = 0; LevelKain = 0;
        LevelSirup = 0; LevelTepung = 0; LevelCat = 0;
        LevelPancake = 0; LevelPizza = 0; LevelBaju = 0;
        TransporterMax = 5; WellMax = 5;
        CostWell = 20; TPDeliveryTime = 500;
        UpgradeTransporter = 1; UpgradeWell = 1;
    }

    void BuatLevel(int money, int well, int goal, string tgoal){
        LevelMoney = money; LevelWell = well; targetgoal = goal; namagoal = tgoal;
        RevertAllIngredientsToZero();
        MoneyTxt.text = "Uang: " + LevelMoney; WellTxt.text = "Sumur: " + LevelWell;
        GoalTxt.text = "Goals: \r\n";
        GoalTxt.text = GoalTxt.text + namagoal + ": " + targetgoal;
    }
    void ApplyLevel(bool bpanel, int lvlpick){
        BuildPanel.SetActive(bpanel); LevelPicked = lvlpick;
        if(bpanel == true){
            DEHLock.interactable = true; BakeryLock.interactable = true;
            DairyLock.interactable = true; CheeseLock.interactable = true;
            SpinneryLock.interactable = true; FabricLock.interactable = true;
            DEH.gameObject.SetActive(false); DEH.interactable = false;
            Bakery.gameObject.SetActive(false); Bakery.interactable = false;
            Dairy.gameObject.SetActive(false); Dairy.interactable = false;
            Cheese.gameObject.SetActive(false); Cheese.interactable = false;
            Spinnery.gameObject.SetActive(false); Spinnery.interactable = false;
            Fabric.gameObject.SetActive(false); Fabric.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PasarMoneyTxt.text = TransporterMoneyTxt.text = StorageMoneyTxt.text = MoneyTxt.text = "Uang: " + LevelMoney; 
        WellTxt.text = "Sumur: " + LevelWell;
        cheat1000MoneyPlusAllMatsPlus10();
        UpdateBahan(); 
        if(timerKucing >= 0.0f) timerKucing -= Time.deltaTime;
        else {CheckingKucing(); timerKucing = 7f;}
        if(TransporterTextManager.cekTransporter == true) TransporterBtn.interactable = false;
        else TransporterBtn.interactable = true;
        //Cek kapan menang
        if(TutorialRumput >= targetgoal && LevelPicked == 1){
            HasilResult();
        }
        if(LevelTelur >= targetgoal && LevelPicked == 2){
            HasilResult();
        }
        if(LevelTlrKering >= targetgoal && LevelPicked == 3){
            HasilResult();
        }
        if(LevelSapi >= targetgoal && LevelPicked == 4){
            HasilResult();
        }
        //Cek Uang di bagian Binatang
        BinatangButtons();
    }

    void cheat1000MoneyPlusAllMatsPlus10(){
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            LevelMoney += 1000;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            LevelTelur = 10; LevelTlrKering = 10; LevelKue = 10;
            LevelSusu = 10; LevelButter = 10; LevelKeju = 10;
            LevelWol = 10; LevelBenang = 10; LevelKain = 10;
            Debug.Log("Telur: " + LevelTelur);
        }
    }

    void UpdateBahan(){
        TelurTxt.text = "Telur: " + LevelTelur; TlrKeringTxt.text = "Telur Kering: " + LevelTlrKering;
        KueTxt.text = "Kue: " + LevelKue; SusuTxt.text = "Susu: " + LevelSusu;
        MentegaTxt.text = "Mentega: " + LevelButter; KejuTxt.text = "Keju: " + LevelKeju;
        WolTxt.text = "Wol: " + LevelWol; BenangTxt.text = "Benang: " + LevelBenang;
        KainTxt.text = "Kain: " + LevelKain;
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
        //Listener Bangunan yang sudah dibuat
        DEH.onClick.AddListener(CreateDE);
        DEH.onClick.AddListener(NotifyDEHPressed);
        Bakery.onClick.AddListener(CreateCake);
        Dairy.onClick.AddListener(CreateButter);
        Cheese.onClick.AddListener(CreateCheese);
        Spinnery.onClick.AddListener(CreateYarn);
        Fabric.onClick.AddListener(CreateFabric);
    }
#region Handle the onClick event
    #region Part 1: Spawn animals
    void SpawnAyam()
    {
        int x = Random.Range(-150, 150);
        int y = Random.Range(-50, 50);
        targetPosition = new Vector3(x, y, 0);
        var ayam = Instantiate(AyamObj,targetPosition,Quaternion.identity);
        ayam.transform.SetParent(GameCanvas.transform, false);
        LevelMoney -= 100;
    }
    void SpawnSapi(){
        int x = Random.Range(-130, 130);
        int y = Random.Range(-50, 50);
        targetPosition = new Vector3(x, y, 0);
        var sapi = Instantiate(SapiObj,targetPosition,Quaternion.identity);
        sapi.transform.SetParent(GameCanvas.transform, false);
        LevelMoney -= 500;
        LevelSapi += 1;
    }
    void SpawnDomba(){
        int x = Random.Range(-130, 130);
        int y = Random.Range(-50, 50);
        targetPosition = new Vector3(x, y, 0);
        var sapi = Instantiate(DombaObj,targetPosition,Quaternion.identity);
        sapi.transform.SetParent(GameCanvas.transform, false);
        LevelMoney -= 1000;
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
        Vector3 targetPosition = new Vector3(DEHLock.transform.position.x, DEH.transform.position.y, 0);
        Debug.Log(DEH.transform.position.x + " & " + DEH.transform.position.y);
        var floatingtxt = Instantiate(FloatText,targetPosition,Quaternion.identity);
        floatingtxt.transform.SetParent(BuildPanel.transform, false);
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
    #endregion
    #region Part 3: Products
    void CreateDE(){
        if(LevelTelur != 0){
        LevelTlrKering += 1;
        LevelTelur -= 1;}
    }
    void CreateCake(){
        if(LevelTlrKering != 0){
        LevelKue += 1;
        LevelTlrKering -= 1;}
    }
    void CreateButter(){
        if(LevelSusu != 0){
        LevelTlrKering += 1;
        LevelTelur -= 1;}
    }
    void CreateCheese(){
        if(LevelButter != 0){
        LevelKeju += 1;
        LevelButter -= 1;}
    }
    void CreateYarn(){
        if(LevelWol != 0){
        LevelBenang += 1;
        LevelWol -= 1;}
    }
    void CreateFabric(){
        if(LevelBenang != 0){
        LevelKain += 1;
        LevelBenang -= 1;}
    }
    #endregion
#endregion
}
