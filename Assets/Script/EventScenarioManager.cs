using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventScenarioManager : MonoBehaviour
{
    string tangkapEvent; int ctrskenario;
    public GameObject MCLama, KakekLama, MCSekarangTernak, KakekSekarang, Nenek, 
        MusimAyamPanel, EasterEgg, Imlek, Natal, TahunBaru;
    public Text SkenarioTxt;
    // Start is called before the first frame update
    void Start()
    {
        RevertAllScenarioToFalse();
        tangkapEvent = GameStatus.PickedEvent;
        ctrskenario = 0;
        if(tangkapEvent == "Musim Ayam"){
            MusimAyamPanel.SetActive(true);
            SkenarioTxt.text = "WAAAHHHH!! KAKEK, LIAT! LIAT!! \n\r Kok ayam yang ini bertelur banyak sekali, kek?!";
            MCLama.SetActive(true); 
        } else if(tangkapEvent == "Hari Paskah"){
            EasterEgg.SetActive(true);
            SkenarioTxt.text = "Selamat Hari Paskah, cucuku. \n\r Ini hadiahnya buat kamu setelah bantu kakek dalam Musim Ayam.";
            KakekLama.SetActive(true); 
        } else if(tangkapEvent == "Imlek"){
            Imlek.SetActive(true);
            SkenarioTxt.text = "WAW! Cucuku!! Lihat, lihat!! Ada naga di sebelah itu!!!";
            KakekLama.SetActive(true); 
        } else if(tangkapEvent == "Natal"){
            Natal.SetActive(true);
            SkenarioTxt.text = "HO! HO!! HO!!! HOOOOO~ \n\r SELAMAT NATAL, CUCUKU YANG TERCINTA!!";
            KakekSekarang.SetActive(true);
        } else if(tangkapEvent == "Tahun Baru"){
            TahunBaru.SetActive(true);
            SkenarioTxt.text = "SE~LA~MAT~ TAHUN BARUUUUUU~~";
            KakekSekarang.SetActive(true);
        }
        ctrskenario++;
    }

    void RevertAllScenarioToFalse(){
        MCLama.SetActive(false); KakekLama.SetActive(false); MCSekarangTernak.SetActive(false);
        KakekSekarang.SetActive(false); Nenek.SetActive(false);
        MusimAyamPanel.SetActive(false); EasterEgg.SetActive(false); Imlek.SetActive(false);
        Natal.SetActive(false); TahunBaru.SetActive(false);
    }

    public void SkipEvent(){
        if(tangkapEvent == "Musim Ayam"){
            GameStatus.PickedHubWorld = "Level1"; GameStatus.PickedLevel = 4;
            SceneManager.LoadScene("GameplayLevel");
        } else if(tangkapEvent == "Hari Paskah"){
            GameStatus.PickedHubWorld = "Level1"; GameStatus.PickedLevel = 5;
            SceneManager.LoadScene("GameplayLevel");
        } else if(tangkapEvent == "Imlek"){
            GameStatus.PickedHubWorld = "Level5"; GameStatus.PickedLevel = 4;
            SceneManager.LoadScene("GameplayLevel");
        } else if(tangkapEvent == "Natal"){
            GameStatus.PickedHubWorld = "Level6"; GameStatus.PickedLevel = 3;
            SceneManager.LoadScene("GameplayLevel");
        } else if(tangkapEvent == "Tahun Baru"){
            GameStatus.PickedHubWorld = "Level7"; GameStatus.PickedLevel = 4;
            SceneManager.LoadScene("GameplayLevel");
        }
    }

    public void AdeganEvent(){
        if(tangkapEvent == "Musim Ayam"){
            if(ctrskenario == 1){
                SkenarioTxt.text = "Iya, hari ini adalah musimnya dimana kekuatan ayam \n\r yang kita miliki jadi sangat kuat sekali untuk bertelur banyak, cucuku.";
                MCLama.SetActive(false); KakekLama.SetActive(true); 
            } else if(ctrskenario == 2){
                SkenarioTxt.text = "Whoa, itu berarti ayamnya Super Chicken, kek!";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 3){
                SkenarioTxt.text = "Hahahaha!! Benar sekali kamu, cucuku! \n\r Ayo bantu kakek ambilkan banyak telur ini!!";
                MCLama.SetActive(false); KakekLama.SetActive(true); 
            } else if(ctrskenario == 4){
                SkenarioTxt.text = "Iya kek!!";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 5){
                GameStatus.PickedHubWorld = "Level1"; GameStatus.PickedLevel = 4;
                SceneManager.LoadScene("GameplayLevel");
            }
        } else if(tangkapEvent == "Hari Paskah"){
            if(ctrskenario == 1){
                SkenarioTxt.text = "Makasih, Kakek!! \n\r Tapi ini semua kok pada berwarna-warna begitu ya?";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 2){
                SkenarioTxt.text = "Iya, cucuku. Hari Paskah biasanya untuk seumuranmu sukanya \n\r menggambar-gambar Telur yang sudah dibeli dari kita.";
                MCLama.SetActive(false); KakekLama.SetActive(true); 
            } else if(ctrskenario == 3){
                SkenarioTxt.text = "Wah!! Ini juga tetap bisa dimakan toh, kek??";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 4){
                SkenarioTxt.text = "Bisa kok, cucuku! Tenang saja, hahahaha!! \n\r Ya sudah, ayo kita semangat ambili telur lagi!";
                MCLama.SetActive(false); KakekLama.SetActive(true); 
            } else if(ctrskenario == 5){
                SkenarioTxt.text = "Telur-telur sekarang ini juga dijualnya mahal lhoo~ \n\r Ayo, bantu kakek sekali lagi cucuku!!";
            } else if(ctrskenario == 6){
                SkenarioTxt.text = "Baik kek, tunggu aku sebentar!!";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 7){
                GameStatus.PickedHubWorld = "Level1"; GameStatus.PickedLevel = 5;
                SceneManager.LoadScene("GameplayLevel");
            }
        } else if(tangkapEvent == "Imlek"){
            if(ctrskenario == 1){
                SkenarioTxt.text = "Kakek tenang, kek! Itu cuma teman-temanku mainan naga!!";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 2){
                SkenarioTxt.text = "HAHAHAHAHA!! Anak-anak sekarang kok pintar sekali main begituan ya?! \n\r Emang hari ini ada apa??";
                MCLama.SetActive(false); KakekLama.SetActive(true); 
            } else if(ctrskenario == 3){
                SkenarioTxt.text = "Hari ini adalah harinya orang-orang merayakan Hari Raya Imlek, kek. \n\r Atau biasanya juga dibilang sebagai Tahun Baru China.";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 4){
                SkenarioTxt.text = "HAH!? Tahun Baru kedua!?!? \n\r Wah, harga beli di pasar-pasar bakalan naik kalo gini...";
                MCLama.SetActive(false); KakekLama.SetActive(true); 
            } else if(ctrskenario == 5){
                SkenarioTxt.text = "Tenang saja kek, asal ada aku... \n\r Harga-harga mahal itu tidak ada apa-apanya dengan kerja keras kita, kek!!";
                MCLama.SetActive(true); KakekLama.SetActive(false); 
            } else if(ctrskenario == 6){
                SkenarioTxt.text = "A HA HA HA HA!! \n\r Emang cucuku ini selalu bisa kupercayakan!!";
                MCLama.SetActive(false); KakekLama.SetActive(true); 
            } else if(ctrskenario == 7){
                SkenarioTxt.text = "Baiklah kalau gitu! Harga mahal, tak masalah!! \n\r Ayo, cucuku! Kita selesaikan hari baru dengan semangat baru ini!!";
            } else if(ctrskenario == 8){
                GameStatus.PickedHubWorld = "Level5"; GameStatus.PickedLevel = 4;
                SceneManager.LoadScene("GameplayLevel");
            }
        } else if(tangkapEvent == "Natal"){
            if(ctrskenario == 1){
                SkenarioTxt.text = "Hahaha!! Kakek bisa aja deh~ \n\r Ngomong-ngomong di luar kenapa ini kek??";
                MCSekarangTernak.SetActive(true); KakekSekarang.SetActive(false);
            } else if(ctrskenario == 2){
                SkenarioTxt.text = "Ohh? Di luar banyak sekali pohon-pohon yang siap dibuat \n\r untuk ditebang dan dijual yang membutuhkan Pohon Natal.";
                MCSekarangTernak.SetActive(false); KakekSekarang.SetActive(true);
            } else if(ctrskenario == 3){
                SkenarioTxt.text = "Wow, segini banyak pula pohon yang kita siapkan?! \n\r Emang Kakek ini selalu dua langkah lebih maju dari lainnya..";
                MCSekarangTernak.SetActive(true); KakekSekarang.SetActive(false);
            } else if(ctrskenario == 4){
                SkenarioTxt.text = "Hahahaha!! Kamu emang sukanya bikin Kakek terpesona aja~ \n\r Untuk hari ini, aku minta bantuanmu mengurus peternakan Kakek.";
                MCSekarangTernak.SetActive(false); KakekSekarang.SetActive(true);
            } else if(ctrskenario == 5){
                SkenarioTxt.text = "Sekali lagi, apakah calon penerima hadiah siap \n\r untuk melakukan tugas dari Kakek? HAHAHAHA!!";
            } else if(ctrskenario == 6){
                SkenarioTxt.text = "Bisa dong, kek~ Semuanya akan aku selesaikan hari ini!! \n\r Jadi Kakek bisa tenang saat jadi Santa~";
                MCSekarangTernak.SetActive(true); KakekSekarang.SetActive(false);
            } else if(ctrskenario == 7){
                SkenarioTxt.text = "HAHAHAHAHAHA!! Baiklah, Kakek 'Santa' ini akan siap \n\r memberikan banyak hadiah~";
                MCSekarangTernak.SetActive(false); KakekSekarang.SetActive(true);
            } else if(ctrskenario == 8){
                GameStatus.PickedHubWorld = "Level6"; GameStatus.PickedLevel = 3;
                SceneManager.LoadScene("GameplayLevel");
            }
        } else if(tangkapEvent == "Tahun Baru"){
            if(ctrskenario == 1){
                SkenarioTxt.text = "Selamat Tahun Baru juga, Kakek!! \n\r Demikian juga untuk Nenek, selamat tahun baru!!";
                MCSekarangTernak.SetActive(true); KakekSekarang.SetActive(false);
            } else if(ctrskenario == 2){
                SkenarioTxt.text = "Sama-sama, cucuku~ \n\r Mari kita rayakan tahun baru dengan semangat baru..";
                MCSekarangTernak.SetActive(false); Nenek.SetActive(true);
            } else if(ctrskenario == 3){
                SkenarioTxt.text = "Demikian untuk Kakek jangan dipaksa kerjanya, ingat umur sayang~ \n\r Biarkan cucu kitalah yang mengurus hal-hal berat...";
            } else if(ctrskenario == 4){
                SkenarioTxt.text = "Ahahahaha... Iya, sayang. Engkau tenang saja.. Kakek akan \n\r memperkerjakan cucu kita buat menggantikanku yang lebih baik!!";
                Nenek.SetActive(false); KakekSekarang.SetActive(true);
            } else if(ctrskenario == 5){
                SkenarioTxt.text = "Yang penting Kakek duduk-duduk santai saja tiap kali kita mulai kerja...";
                MCSekarangTernak.SetActive(true); KakekSekarang.SetActive(false);
            } else if(ctrskenario == 6){
                SkenarioTxt.text = "AHAHAHAHAHA!! Cucuku emang tetap aja masih isa bercanda walau tahun baru!! \n\r Tenang saja, Kakek akan membantu hal-hal yang mudah biar kamu kerjakan yang susahnya~";
                MCSekarangTernak.SetActive(false); KakekSekarang.SetActive(true);
            } else if(ctrskenario == 7){
                 SkenarioTxt.text = "Baiklah, kek. Mari kita kerjakan peternakan kita dengan \n\r semangat baru di tahun baru!!";
                 MCSekarangTernak.SetActive(true); KakekSekarang.SetActive(false);
            } else if(ctrskenario == 8){
                SkenarioTxt.text = "ITU BARU CUCUKU YANG KUKENAL AHAHAHAHAHA!!! \n\r AYO KITA SIKAT!!";
                MCSekarangTernak.SetActive(false); KakekSekarang.SetActive(true);
            } else if(ctrskenario == 9){
                SkenarioTxt.text = "Hati-hati kalian berdua, kerjanya jangan dipaksa-paksa.";
                KakekSekarang.SetActive(false); Nenek.SetActive(true);
            } else if(ctrskenario == 10){
                GameStatus.PickedHubWorld = "Level7"; GameStatus.PickedLevel = 4;
                SceneManager.LoadScene("GameplayLevel");
            }
        }

        ctrskenario++;
    }
}
