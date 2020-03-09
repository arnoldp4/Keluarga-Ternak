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
    public Text CurrentLvlTxt, FirstCurrentLvlTxt, EventTxt, FirstGoalTxt,
        PasarMoneyTxt, TransporterMoneyTxt, StorageMoneyTxt, MoneyTxt, WellTxt, GoalTxt, BtnWellTxt,
        TelurTxt, TlrKeringTxt, KueTxt,
        SusuTxt, MentegaTxt, KejuTxt,
        WolTxt, BenangTxt, KainTxt, 
        SirupTxt, PancakeTxt, TepungTxt, PizzaTxt, CatTxt, BajuTxt;
    public static bool CureProcess; //Untuk proses cek apakah ada hewan yang perlu disehatkan
    
    //Variable buat satu level
    string namagoal, kondisiEvent; int targetgoal; //Goal yang berlaku 1 goal saja

    //Variable buat selesai level
    public GameObject GameCanvas, ResultCanvas, FirstPageCanvas, EventPanel,
        BuildPanel, EggPanel, MilkPanel, WoolPanel,
        PancakePanel, PizzaPanel, ClothesPanel;

    //Variable buat spawn hewan produktif dan non-produktif
    public RawImage RumputObj, AyamObj, SapiObj, DombaObj, AnjingObj, KucingObj,
        AyamSakitObj, SapiSakitObj, DombaSakitObj;
    //Variable buat spawn
    Vector3 targetPosition;

    //Variable buat button-button yang ada di game
    public Button TransporterBtn, AyamBtn, SapiBtn, DombaBtn, AnjingBtn, KucingBtn, RumputBtn,
        BeruangObj, TikusObj,
        DEHLock, DEH, BakeryLock, Bakery,
        DairyLock, Dairy, CheeseLock, Cheese,
        SpinneryLock, Spinnery, FabricLock, Fabric,
        ChangePancake, ChangePizza, ChangeClothes,
        PancakeLock, Pancake, PizzaLock, Pizza, 
        BoutiqueLock, Boutique, SembuhBtn, 
        PancakeChangeBtn, PizzaChangeBtn, BoutiqueChangeBtn;
    
    bool sudahNaikLevel = false, mauSpecial = false,
        cekPancakeKeluar = false, cekPizzaKeluar = false, cekBajuKeluar = false;
    int LevelAyam = 0, LevelSapi = 0, LevelDomba = 0;
    float timerKucing = 3f; 
    public static int LevelPicked, TutorialRumput;
    
    int[,] PosisiSpawn = new int[,] {{-230, -200, -155, -130, -115, -105, -75, -45, -15, 
        15, 45, 75, 105, 130, 170, 200, 230}, 
        {-90, -80, -75, -65, -55, -45, -35, -25, -15, -5, 
            5, 25, 45, 65, 85, 95, 105}};

    //Variable buat cek Achievements
    public static int LevelKucing, LevelAnjing;
    public static bool CekAchieveDomba = false, CekAchieveWol = false, CekAchieveSapi = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<DoNotDestroy>().StopMusic();
        FirstPageCanvas.SetActive(true); Time.timeScale = 0;
        sudahNaikLevel = false; TransporterMax = 5; TPDeliveryTime = 500;
        ResultCanvas.SetActive(false);
        RevertAllIngredientsToZero();
        if(GameStatus.PickedHubWorld == "Level1"){
            if(GameStatus.PickedLevel == 1){
                LevelMoney = 100; LevelWell = 5;
                targetgoal = 10; namagoal = "Rumput";
                BuildPanel.SetActive(false); LevelPicked = 1;
                GoalTxt.text = "Goal: \r\n";
                FirstGoalTxt.text = GoalTxt.text = GoalTxt.text + namagoal + ": " + targetgoal;
                FirstCurrentLvlTxt.text = "Level " + LevelPicked;
            } else if(GameStatus.PickedLevel == 2){
                BuatLevel(300, 2, "Ayam");
                ApplyLevel(false, false, false, false, false, false, false, 2);
            } else if(GameStatus.PickedLevel == 3){
                BuatLevel(500, 5, "Telur");
                ApplyLevel(false, false, false, false, false, false, false, 3);
            } else if(GameStatus.PickedLevel == 4){
                BuatLevel(750, 10, "Telur Kering");
                ApplyLevel(true, true, false, false, false, false, false, 4);
            } else if(GameStatus.PickedLevel == 5){ 
                BuatLevel(800, 2500, "Uang");
                ApplyLevel(true, true, false, false, false, false, false, 5);
            }
        } else if(GameStatus.PickedHubWorld == "Level2"){
            if(GameStatus.PickedLevel == 1){
                BuatLevel(300, 1, "Sapi");
                ApplyLevel(true, true ,false, false, false, false, false, 6);
            } else if(GameStatus.PickedLevel == 2){
                BuatLevel(750, 2, "Susu");
                ApplyLevel(true, true, false, false, false, false, false, 7);
            } else if(GameStatus.PickedLevel == 3){
                BuatLevel(1000, 3, "Butter");
                ApplyLevel(true, true, true, false, false, false, false, 8);
            } else if(GameStatus.PickedLevel == 4){
                BuatLevel(500, 5, "Sapi");
                ApplyLevel(true, true, true, false, false, false, false, 9);
            } else if(GameStatus.PickedLevel == 5){
                BuatLevel(1500, 5, "Keju");
                ApplyLevel(true, true, true, false, false, false, false, 10);
            }
        } else if(GameStatus.PickedHubWorld == "Level3"){
            if(GameStatus.PickedLevel == 1){
                BuatLevel(2500, 2, "Domba");
                ApplyLevel(true, true, true, false, false, false, false, 11);
            } else if(GameStatus.PickedLevel == 2){
                BuatLevel(3000, 5, "Wol");
                ApplyLevel(true, true, true, false, false, false, false, 12);
            } else if(GameStatus.PickedLevel == 3){
                BuatLevel(3250, 4, "Benang");
                ApplyLevel(true, true, true, true, false, false, false, 13);
            } else if(GameStatus.PickedLevel == 4){
                BuatLevel(4500, 6, "Kain");
                ApplyLevel(true, true, true, true, false, false, false, 14);
            } else if(GameStatus.PickedLevel == 5){
                BuatLevel(5555, 55, "Wol");
                ApplyLevel(true, true, true, true, false, false, false, 15);
            }
        } else if(GameStatus.PickedHubWorld == "Level4"){
            if(GameStatus.PickedLevel == 1){
                BuatLevel(1000, 10, "Sapi");
                ApplyLevel(true, true, true, true, false, false, false, 16);
            } else if(GameStatus.PickedLevel == 2){
                BuatLevel(2500, 7500, "Uang");
                ApplyLevel(true, true, true, true, false, false, false, 17);
            } else if(GameStatus.PickedLevel == 3){
                BuatLevel(1550, 6275, "Uang");
                ApplyLevel(true, true, true, true, false, false, false, 18);
            } else if(GameStatus.PickedLevel == 4){
                BuatLevel(555, 10, "Telur");
                ApplyLevel(true, true, true, true, false, false, false, 19);
            } else if(GameStatus.PickedLevel == 5){
                BuatLevel(5550, 10, "Butter");
                ApplyLevel(true, true, true, true, false, false, false, 20);
            }
        } else if(GameStatus.PickedHubWorld == "Level5"){
        SpecialIngredients(true, true, true, false);
            if(GameStatus.PickedLevel == 1){
                BuatLevel(1500, 5, "Domba");
                ApplyLevel(true, true, true, true, false, false, false, 21);
            } else if(GameStatus.PickedLevel == 2){
                BuatLevel(2500, 3, "Keju");
                ApplyLevel(true, true, true, true, false, false, false, 22);
            } else if(GameStatus.PickedLevel == 3){
                BuatLevel(3330, 3, "Pancake");
                ApplyLevel(true, true, true, true, true, false, false, 23);
            } else if(GameStatus.PickedLevel == 4){
                BuatLevel(4440, 4, "Pizza");
                ApplyLevel(true, true, true, true, true, true, false, 24);
            } else if(GameStatus.PickedLevel == 5){
                BuatLevel(5000, 10, "Pizza");
                ApplyLevel(true, true, true, true, true, true, false, 25);
            }
        } else if(GameStatus.PickedHubWorld == "Level6"){
            if(GameStatus.PickedLevel == 1){
                BuatLevel(10000, 3, "Level Sumur");
                ApplyLevel(true, true, true, true, true, true, false, 26);
            } else if(GameStatus.PickedLevel == 2){
                BuatLevel(10000, 3, "Level Transporter");
                ApplyLevel(true, true, true, true, true, true, false, 27);
            } else if(GameStatus.PickedLevel == 3){
                BuatLevel(5000, 12, "Domba");
                ApplyLevel(true, true, true, true, true, true, false, 28);
            } else if(GameStatus.PickedLevel == 4){
                BuatLevel(7500, 7, "Pizza");
                ApplyLevel(true, true, true, true, true, true, false, 29);
            } else if(GameStatus.PickedLevel == 5){
                SpecialIngredients(true, true, true, true);
                BuatLevel(8880, 8, "Baju");
                ApplyLevel(true, true, true, true, true, true, true, 30);
            }
        } else if(GameStatus.PickedHubWorld == "Level7"){
            if(GameStatus.PickedLevel == 1){
                BuatLevel(7500, 15000, "Uang");
                ApplyLevel(true, true, true, true, true, true, true, 31);
            } else if(GameStatus.PickedLevel == 2){
                BuatLevel(15000, 15, "Baju");
                ApplyLevel(true, true, true, true, true, true, true, 32);
            } else if(GameStatus.PickedLevel == 3){
                BuatLevel(5000, 10, "Pancake");
                ApplyLevel(true, true, true, true, true, true, true, 33);
            } else if(GameStatus.PickedLevel == 4){
                BuatLevel(10000, 13, "Pizza");
                ApplyLevel(true, true, true, true, true, true, true, 34);
            } else if(GameStatus.PickedLevel == 5){
                BuatLevel(10000, 50000, "Uang");
                ApplyLevel(true, true, true, true, true, true, true, 35);
            }
        }
        
        CurrentLvlTxt.text = "Level " + LevelPicked.ToString();
        kondisiEvent = GameStatus.PickedEvent;
        if(kondisiEvent != "None"){
            EventTxt.gameObject.SetActive(true);
            GoalTxt.text = GoalTxt.text + "\n\r Event: " + kondisiEvent;
            if(kondisiEvent == "Musim Ayam") EventTxt.text = "Event = Musim Ayam\n\r\n\rTelur jadi dua kali keluar!!";
            else if(kondisiEvent == "Hari Paskah") EventTxt.text = "Event = Hari Paskah\n\r\n\rHarga jual telur naik!!";
            else if(kondisiEvent == "Imlek") EventTxt.text = "Event = Imlek\n\r\n\rHarga beli di pasar naik!!";
            else if(kondisiEvent == "Natal") EventTxt.text = "Event = Natal\n\r\n\rDomba Buy 1 Get 2!!";
            else if(kondisiEvent == "Tahun Baru") EventTxt.text = "Event = Tahun Baru\n\r\n\rHewan selalu serba sehat!!";
        } else if(kondisiEvent == "None") {EventTxt.gameObject.SetActive(false); EventPanel.SetActive(false);}

        if(PancakePanel.activeInHierarchy == false) PancakeChangeBtn.gameObject.SetActive(false);
            else PancakeChangeBtn.gameObject.SetActive(true);
        if(PizzaPanel.activeInHierarchy == false) PizzaChangeBtn.gameObject.SetActive(false);
            else PizzaChangeBtn.gameObject.SetActive(true);
        if(ClothesPanel.activeInHierarchy == false) BoutiqueChangeBtn.gameObject.SetActive(false);
            else BoutiqueChangeBtn.gameObject.SetActive(true);
    }

    void RevertAllIngredientsToZero(){
        LevelTelur = 0; LevelTlrKering = 0; LevelKue = 0;
        LevelSusu = 0; LevelButter = 0; LevelKeju = 0;
        LevelWol = 0; LevelBenang = 0; LevelKain = 0;
        LevelSirup = 0; LevelTepung = 0; LevelCat = 0;
        LevelPancake = 0; LevelPizza = 0; LevelBaju = 0;
        TransporterMax = 5; WellMax = 5; LevelWell = WellMax;
        CostWell = 20; TPDeliveryTime = 500;
        mauSpecial = false; CureProcess = false;
        UpgradeTransporter = 1; UpgradeWell = 1;
    }

    void BuatLevel(int money, int goal, string tgoal){
        LevelMoney = money; targetgoal = goal; namagoal = tgoal;
        RevertAllIngredientsToZero(); WellTxt.text = "Sumur: " + LevelWell;
        GoalTxt.text = "Goal: \r\n";
        FirstGoalTxt.text = GoalTxt.text = GoalTxt.text + namagoal + ": " + targetgoal;
    }
    void ApplyLevel(bool bpanel, bool ePanel, bool mPanel, 
        bool wPanel, bool paPanel, bool pzPanel, bool clPanel, int lvlpick){
        BuildPanel.SetActive(bpanel); LevelPicked = lvlpick;
        FirstCurrentLvlTxt.text = "Level " + lvlpick;
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
            PancakePanel.SetActive(false); PizzaPanel.SetActive(false);
            ClothesPanel.SetActive(false);
            PancakeChangeBtn.gameObject.SetActive(paPanel); PizzaChangeBtn.gameObject.SetActive(pzPanel);
            BoutiqueChangeBtn.gameObject.SetActive(clPanel);
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
        PasarMoneyTxt.text = TransporterMoneyTxt.text = StorageMoneyTxt.text = MoneyTxt.text = LevelMoney.ToString();
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
        else if(LevelAyam >= targetgoal && LevelPicked == 2) HasilResult();
        else if(LevelTelur >= targetgoal && LevelPicked == 3) HasilResult();
        else if(LevelTlrKering >= targetgoal && LevelPicked == 4) HasilResult();
        else if(LevelMoney >= targetgoal && LevelPicked == 5) HasilResult();
        else if(LevelSapi >= targetgoal && LevelPicked == 6) HasilResult();
        else if(LevelSusu >= targetgoal && LevelPicked == 7) HasilResult();
        else if(LevelButter >= targetgoal && LevelPicked == 8) HasilResult();
        else if(LevelSapi >= targetgoal && LevelPicked == 9) HasilResult();
        else if(LevelKeju >= targetgoal && LevelPicked == 10) HasilResult();
        else if(LevelDomba >= targetgoal && LevelPicked == 11) HasilResult();
        else if(LevelWol >= targetgoal && LevelPicked == 12) HasilResult();
        else if(LevelBenang >= targetgoal && LevelPicked == 13) HasilResult();
        else if(LevelKain >= targetgoal && LevelPicked == 14) HasilResult();
        else if(LevelWol >= targetgoal && LevelPicked == 15) HasilResult();
        else if(LevelSapi >= targetgoal && LevelPicked == 16) HasilResult();
        else if(LevelMoney >= targetgoal && LevelPicked == 17) HasilResult();
        else if(LevelMoney >= targetgoal && LevelPicked == 18) HasilResult();
        else if(LevelTelur >= targetgoal && LevelPicked == 19) HasilResult();
        else if(LevelButter >= targetgoal && LevelPicked == 20) HasilResult();
        else if(LevelDomba >= targetgoal && LevelPicked == 21) HasilResult();
        else if(LevelKeju >= targetgoal && LevelPicked == 22) HasilResult();
        else if(LevelPancake >= targetgoal && LevelPicked == 23) HasilResult();
        else if(LevelPizza >= targetgoal && LevelPicked == 24) HasilResult();
        else if(LevelPizza >= targetgoal && LevelPicked == 25) HasilResult();
        else if(UpgradeWell >= targetgoal && LevelPicked == 26) HasilResult();
        else if(UpgradeTransporter >= targetgoal && LevelPicked == 27) HasilResult();
        else if(LevelDomba >= targetgoal && LevelPicked == 28) HasilResult();
        else if(LevelPizza >= targetgoal && LevelPicked == 29) HasilResult();
        else if(LevelBaju >= targetgoal && LevelPicked == 30) HasilResult();
        else if(LevelMoney >= targetgoal && LevelPicked == 31) HasilResult();
        else if(LevelBaju >= targetgoal && LevelPicked == 32) HasilResult();
        else if(LevelPancake >= targetgoal && LevelPicked == 33) HasilResult();
        else if(LevelPizza >= targetgoal && LevelPicked == 34) HasilResult();
        else if(LevelMoney >= targetgoal && LevelPicked == 35) HasilResult();
#endregion
        //Cek Uang di bagian Binatang
        BinatangButtons();
        //Cek untuk Achievements
        cekAchievements();
    }

    void HasilResult(){
        GameCanvas.SetActive(false);
        ResultCanvas.SetActive(true);
        if(sudahNaikLevel == false){
            if(PlayerPrefs.GetString("CurrentUser") == "User1"){
                int kondisilevel = PlayerPrefs.GetInt("LevelPlayer1");
                if(kondisilevel == LevelPicked){
                    PlayerPrefs.SetInt("LevelPlayer1", kondisilevel+1);
                }
            }
            else if(PlayerPrefs.GetString("CurrentUser") == "User2"){
                int kondisilevel = PlayerPrefs.GetInt("LevelPlayer2");
                if(kondisilevel == LevelPicked){
                    PlayerPrefs.SetInt("LevelPlayer2", kondisilevel+1);
                }
            }
        sudahNaikLevel = true;}
    }

    void cekAchievements(){
        if(LevelDomba >= 20) CekAchieveDomba = true;
        if(LevelSapi >= 1) CekAchieveSapi = true;
        if(LevelWol >= 12) CekAchieveWol = true;
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
        RumputBtn.onClick.AddListener(SpawnRumput);
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
    void SpawnRumput(){
        if(LevelWell != 0){
            int x = Random.Range(0, 17); int y = Random.Range(0, 17);
            targetPosition = new Vector3(PosisiSpawn[0, x], PosisiSpawn[1, y], 0);
            var rumput = Instantiate(RumputObj,targetPosition,Quaternion.identity);
            rumput.transform.SetParent(GameCanvas.transform, false);
            TutorialRumput+=1; LevelWell-=1;
        }
    }
    #region Part 1: Spawn animals
    void SpawnAyam()
    {
        int x = Random.Range(0, 17); int y = Random.Range(0, 17);
        targetPosition = new Vector3(PosisiSpawn[0, x], PosisiSpawn[1, y], 0);
        if(CureProcess == false){
            int RNGSakit = Random.Range(1, 100);
            int RNGSakitTarget = 90;
            if(kondisiEvent == "Tahun Baru") RNGSakitTarget = 0;
            if(RNGSakit >= RNGSakitTarget && RNGSakitTarget != 0){
                var ayam = Instantiate(AyamSakitObj,targetPosition,Quaternion.identity);
                ayam.transform.SetParent(GameCanvas.transform, false);
            } else {
                var ayam = Instantiate(AyamObj,targetPosition,Quaternion.identity);
                ayam.transform.SetParent(GameCanvas.transform, false);
            }
            LevelMoney -= 100; LevelAyam +=1;
        } else {
                var ayam = Instantiate(AyamObj,targetPosition,Quaternion.identity);
                ayam.transform.SetParent(GameCanvas.transform, false);
        }
    }
    void SpawnSapi(){
        int x = Random.Range(0, 17); int y = Random.Range(0, 17);
        targetPosition = new Vector3(PosisiSpawn[0, x], PosisiSpawn[1, y], 0);
        if(CureProcess == false){
            int RNGSakit = Random.Range(1, 200);
            int RNGSakitTarget = 170;
            if(kondisiEvent == "Tahun Baru") RNGSakitTarget = 0;
            if(RNGSakit >= RNGSakitTarget && RNGSakitTarget != 0){
                var sapi = Instantiate(SapiSakitObj,targetPosition,Quaternion.identity);
                sapi.transform.SetParent(GameCanvas.transform, false);
            } else {
                var sapi = Instantiate(SapiObj,targetPosition,Quaternion.identity);
                sapi.transform.SetParent(GameCanvas.transform, false);
            }
            LevelMoney -= 500; LevelSapi += 1;
        } else {
            var sapi = Instantiate(SapiObj,targetPosition,Quaternion.identity);
            sapi.transform.SetParent(GameCanvas.transform, false);
        }
    }
    void SpawnDomba(){
        int x = Random.Range(0, 17); int y = Random.Range(0, 17);   
        targetPosition = new Vector3(PosisiSpawn[0, x], PosisiSpawn[1, y], 0);
        if(CureProcess == false){
            int RNGSakit = Random.Range(1, 200);
            int RNGSakitTarget = 180;
            if(kondisiEvent == "Tahun Baru") RNGSakitTarget = 0;
            if(RNGSakit >= RNGSakitTarget && RNGSakitTarget != 0){
                var domba = Instantiate(DombaSakitObj,targetPosition,Quaternion.identity);
                domba.transform.SetParent(GameCanvas.transform, false);
            } else {
                var domba = Instantiate(DombaObj,targetPosition,Quaternion.identity);
                domba.transform.SetParent(GameCanvas.transform, false);
                if(kondisiEvent == "Natal"){
                    var domba2 = Instantiate(DombaObj,targetPosition,Quaternion.identity);
                    domba2.transform.SetParent(GameCanvas.transform, false);
                }
            }
            LevelMoney -= 1000; if(kondisiEvent == "Natal" && RNGSakit >= RNGSakitTarget) LevelDomba+=2; else LevelDomba+=1;
        } else {
            var domba = Instantiate(DombaObj,targetPosition,Quaternion.identity);
            domba.transform.SetParent(GameCanvas.transform, false);
        }
    }
    void SpawnAnjing(){
        int x = Random.Range(0, 17); int y = Random.Range(0, 17);
        targetPosition = new Vector3(PosisiSpawn[0, x], PosisiSpawn[1, y], 0);
        var sapi = Instantiate(AnjingObj,targetPosition,Quaternion.identity);
        sapi.transform.SetParent(GameCanvas.transform, false);
        LevelMoney -= 400; LevelAnjing+=1;
    }
    void SpawnKucing(){
        int x = Random.Range(0, 17); int y = Random.Range(0, 17);
        targetPosition = new Vector3(PosisiSpawn[0, x], PosisiSpawn[1, y], 0);
        var sapi = Instantiate(KucingObj,targetPosition,Quaternion.identity);
        sapi.transform.SetParent(GameCanvas.transform, false);
        LevelMoney -= 800; LevelKucing+=1;
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
