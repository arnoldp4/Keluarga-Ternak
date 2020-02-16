using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScenarioManager : MonoBehaviour
{
    string tangkapStory; int ctrskenario;
    public GameObject MCLama, KakekLama, MCSekarang, KakekSekarang,
        PeternakanLama, RumahSekarang, SapiCutscene;
    public Text SkenarioTxt;
    void Start()
    {
        RevertAllScenarioToFalse();
        tangkapStory = GameStatus.PickedEvent;
        ctrskenario = 0;
        if(tangkapStory == "Story2"){
            PeternakanLama.SetActive(true);
            if(ctrskenario == 0){
                SkenarioTxt.text = "Baiklah, cucuku. Setelah kamu telah memahami dasar dengan peternakan kita.. \n\r Bagaimana kita mencoba sedikit berbeda dari biasanya?";
                KakekLama.SetActive(true); 
            } 
        } else if(tangkapStory == "Story3"){
            PeternakanLama.SetActive(true);
            if(ctrskenario == 0){
                SkenarioTxt.text = "Kakek! Kakek!! Aku dapat surat dari papa!!";
                MCLama.SetActive(true); 
            } 
        }
        ctrskenario++;
    }
    void RevertAllScenarioToFalse(){
        MCLama.SetActive(false); KakekLama.SetActive(false);
        MCSekarang.SetActive(false); KakekSekarang.SetActive(false);
        PeternakanLama.SetActive(false); RumahSekarang.SetActive(false);
        SapiCutscene.SetActive(false);
    }

    public void AdeganStory(){
        if(tangkapStory == "Story2"){
            if(ctrskenario == 1){
                SkenarioTxt.text = "Waw! Waw!! Apa yang akan kakek kasih ke aku sekarang?";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 2){
                SkenarioTxt.text = "Sekarang kita akan merawat sapi-sapi yang telah kakek rawat dengan baik ini!";
                MCLama.SetActive(false); KakekLama.SetActive(true); 
            } else if(ctrskenario == 3){
                PeternakanLama.SetActive(false); SapiCutscene.SetActive(true);
                SkenarioTxt.text = "Whooooooaaaa!! \n\r Besar-besar semua sapinya, kek! Mereka makannya apa saja ini?!";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 4){
                SkenarioTxt.text = "HAHAHA!! Mereka makannya padahal sama kaya ayam-ayam kita tapi \n\r kok bisa saja besarnya begini ya, cucuku??";
                MCLama.SetActive(false); KakekLama.SetActive(true); 
            } else if(ctrskenario == 5){
                SkenarioTxt.text = "Oke, jangan lama-lama lagi cucuku!! Ayo kita urus secepatnya sebelum \n\r mereka teriak-teriak mau makan!";
            } else if(ctrskenario == 6){
                SkenarioTxt.text = "BAIK KEK!!";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 7){
                GameStatus.PickedHubWorld = "Level2"; GameStatus.PickedLevel = 1;
                GameStatus.PickedEvent = "None";
                SceneManager.LoadScene(GameStatus.PickedHubWorld);
            }
        } else if(tangkapStory == "Story3"){
            if(ctrskenario == 1){
                SkenarioTxt.text = "Waw!! Sodaraku lagi kangen sama cucuku yang tercinta nih.. \n\r Isinya tentang apaan, nak?";
                MCLama.SetActive(false); KakekLama.SetActive(true); 
            } else if(ctrskenario == 2){
                SkenarioTxt.text = "Papa katanya ingin aku kembali kesana buat sekolah disana, kek! \n\r Tapi aku masih betah disini, kek!!";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 3){
                SkenarioTxt.text = "Cucuku, inget. Papamu memberi masa depanmu lebih baik ini... \n\r Bukan berarti kamunya nda bisa kesini lagi, cucuku.";
                MCLama.SetActive(false); KakekLama.SetActive(true); 
            } else if(ctrskenario == 4){
                SkenarioTxt.text = "Gini gini deh~ Kakek akan kirimin kamu surat lagi.. \n\r Disaat kamu sudah terima surat itu, berarti tahu apa itu kan??";                
            } else if(ctrskenario == 5){
                SkenarioTxt.text = "Apaan, kek??";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 6){
                SkenarioTxt.text = "HAHAHAHAHA!! Kamu emang bisa aja bercanda, cucuku!! \n\r Ya jelas, aku membutuhkan bantuanmu disini!!";
                MCLama.SetActive(false); KakekLama.SetActive(true); 
            } else if(ctrskenario == 7){
                SkenarioTxt.text = "Ingat, cucuku.. Di hari ke depan, saat kamu sudah dewasa dan kamu datang kesini... \n\r untuk kedua kalinya, Kakek akan benar-benar butuh bantuanmu.";                
            } else if(ctrskenario == 8){
                SkenarioTxt.text = "Apakah Kakek, bisa percayakan tugas ini ke kamu, cucuku??";                
            } else if(ctrskenario == 9){
                SkenarioTxt.text = "BISA KEK!! Kakek percayakan padaku saja!!";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 10){
                SkenarioTxt.text = "HA HA HA HA HA HA ! ! \n\r Baiklah, cucuku! Ayo packing sana buat persiapan ke kota papamu!";
                MCLama.SetActive(false); KakekLama.SetActive(true); 
            } else if(ctrskenario == 11){
                SkenarioTxt.text = "IYA KEK!! Aku akan kangen sama kakek!";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 12){
                SkenarioTxt.text = "HAHAHA! Kakek masih disini kamu sudah kangen-kangen!! \n\r Emang cucuku bisa saja~";
                MCLama.SetActive(false); KakekLama.SetActive(true); 
            } else if(ctrskenario == 13){
                PeternakanLama.SetActive(false); RumahSekarang.SetActive(true);
                SkenarioTxt.text = "Ahhh, tak terasa ini sudah hampir...20 tahun \n\r sudah tidak ketemu sama Kakek...";
                MCSekarang.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 14){
                SkenarioTxt.text = "Ayo! Ayo!! \n\r Akan ku packing barang-barang ini buat kesana langsung!";               
            } else if(ctrskenario == 15){
                GameStatus.PickedHubWorld = "Level2"; GameStatus.PickedLevel = 5;
                GameStatus.PickedEvent = "None";
                SceneManager.LoadScene(GameStatus.PickedHubWorld);
            }
        }

        ctrskenario++;
    }
}
