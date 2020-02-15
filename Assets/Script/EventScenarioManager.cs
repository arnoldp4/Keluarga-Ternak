using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventScenarioManager : MonoBehaviour
{
    string tangkapEvent; int ctrskenario;
    public GameObject MCLama, KakekLama,
        MusimAyamPanel, EasterEgg;
    public Text SkenarioTxt;
    // Start is called before the first frame update
    void Start()
    {
        RevertAllScenarioToFalse();
        tangkapEvent = GameStatus.PickedEvent;
        ctrskenario = 0;
        if(tangkapEvent == "Musim Ayam"){
            MusimAyamPanel.SetActive(true);
            if(ctrskenario == 0){
                SkenarioTxt.text = "WAAAHHHH!! KAKEK, LIAT! LIAT!! \n\r Kok ayam yang ini bertelur banyak sekali, kek?!";
                MCLama.SetActive(true); ctrskenario++;
            } 
        } else if(tangkapEvent == "Hari Paskah"){
            EasterEgg.SetActive(true);
            if(ctrskenario == 0){
                SkenarioTxt.text = "Selamat Hari Paskah, cucuku. \n\r Ini hadiahnya buat kamu setelah bantu kakek dalam Musim Ayam.";
                KakekLama.SetActive(true); ctrskenario++;
            } 
        }
    }

    void RevertAllScenarioToFalse(){
        MCLama.SetActive(false); KakekLama.SetActive(false);
        MusimAyamPanel.SetActive(false); EasterEgg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdeganEvent(){
        if(tangkapEvent == "Musim Ayam"){
            if(ctrskenario == 1){
                SkenarioTxt.text = "Iya, hari ini adalah musimnya dimana kekuatan ayam \n\r yang kita miliki jadi sangat kuat sekali untuk bertelur banyak, cucuku.";
                MCLama.SetActive(false); KakekLama.SetActive(true); ctrskenario++;
            } else if(ctrskenario == 2){
                SkenarioTxt.text = "Whoa, itu berarti ayamnya Super Chicken, kek!";
                MCLama.SetActive(true); KakekLama.SetActive(false); ctrskenario++;
            } else if(ctrskenario == 3){
                SkenarioTxt.text = "Hahahaha!! Benar sekali kamu, cucuku! \n\r Ayo bantu kakek ambilkan banyak telur ini!!";
                MCLama.SetActive(false); KakekLama.SetActive(true); ctrskenario++;
            } else if(ctrskenario == 4){
                SkenarioTxt.text = "Iya kek!!";
                MCLama.SetActive(true); KakekLama.SetActive(false); ctrskenario++;
            } else if(ctrskenario == 5){
                GameStatus.PickedHubWorld = "Level1"; GameStatus.PickedLevel = 4;
                SceneManager.LoadScene(GameStatus.PickedHubWorld);
            }
        } else if(tangkapEvent == "Hari Paskah"){
            if(ctrskenario == 1){
                SkenarioTxt.text = "Makasih, Kakek!! \n\r Tapi ini semua kok pada berwarna-warna begitu ya?";
                MCLama.SetActive(true); KakekLama.SetActive(false); ctrskenario++;
            } else if(ctrskenario == 2){
                SkenarioTxt.text = "Iya, cucuku. Hari Paskah biasanya untuk seumuranmu sukanya \n\r menggambar-gambar Telur yang sudah dibeli dari kita.";
                MCLama.SetActive(false); KakekLama.SetActive(true); ctrskenario++;
            } else if(ctrskenario == 3){
                SkenarioTxt.text = "Wah!! Ini juga tetap bisa dimakan toh, kek??";
                MCLama.SetActive(true); KakekLama.SetActive(false); ctrskenario++;
            } else if(ctrskenario == 4){
                SkenarioTxt.text = "Bisa kok, cucuku! Tenang saja, hahahaha!! \n\r Ya sudah, ayo kita semangat ambili telur lagi!";
                MCLama.SetActive(false); KakekLama.SetActive(true); ctrskenario++;
            } else if(ctrskenario == 5){
                SkenarioTxt.text = "Telur-telur sekarang ini juga dijualnya mahal lhoo~ \n\r Ayo, bantu kakek sekali lagi cucuku!!";
                ctrskenario ++;
            } else if(ctrskenario == 6){
                SkenarioTxt.text = "Baik kek, tunggu aku sebentar!!";
                MCLama.SetActive(true); KakekLama.SetActive(false); ctrskenario++;
            } else if(ctrskenario == 7){
                GameStatus.PickedHubWorld = "Level1"; GameStatus.PickedLevel = 5;
                SceneManager.LoadScene(GameStatus.PickedHubWorld);
            }
        }
    }
}
