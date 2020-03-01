using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScenarioManager : MonoBehaviour
{
    string tangkapStory; int ctrskenario;
    public GameObject MCLama, KakekLama, MCSekarang, MCSekarangTernak, KakekSekarang, Nenek,
        PeternakanLama, PeternakanSkg, RumahSekarang, SapiCutscene, Perjalanan, Domba, 
        Basement, Rahasia, Renovasi, FinalScenario;
    public Text SkenarioTxt;
    void Start()
    {
        RevertAllScenarioToFalse();
        tangkapStory = GameStatus.PickedEvent;
        ctrskenario = 0;
        if(tangkapStory == "Story2"){
            PeternakanLama.SetActive(true);
            SkenarioTxt.text = "Baiklah, cucuku. Setelah kamu telah memahami dasar dengan peternakan kita..\n\rBagaimana kita mencoba sedikit berbeda dari biasanya?";
            KakekLama.SetActive(true); 
        } else if(tangkapStory == "Story3"){
            PeternakanLama.SetActive(true);
            SkenarioTxt.text = "Kakek! Kakek!! Aku dapat surat dari papa!!";
            MCLama.SetActive(true); 
        } else if(tangkapStory == "Story4"){
            SkenarioTxt.text = "Keesokan harinya...";
        } else if(tangkapStory == "Story5"){
            PeternakanSkg.SetActive(true);
            SkenarioTxt.text = "HMMMMMMMM~\n\r Memang bangun pagi di kota dan peternakan kakek bedanya jauh banget..";
            MCSekarangTernak.SetActive(true);
        } else if(tangkapStory == "Story6"){
            PeternakanSkg.SetActive(true);
            SkenarioTxt.text = "BANGUN BANGUN BANGUN!!\n\rCUCUKU AYO BANGUN ! ! !";
            KakekSekarang.SetActive(true);
        } else if(tangkapStory == "Story7"){
            Renovasi.SetActive(true);
            SkenarioTxt.text = "Cucuku.. Bisakah engkau kesini sebentar?";
            Nenek.SetActive(true);
        } else if(tangkapStory == "FinalStory"){
            FinalScenario.SetActive(true);
            SkenarioTxt.text = "Akhirnya, cucuku... Selama banyak kali engkau membantuku,\n\rsudah bisa dengan sempurna hingga sekarang..";
            KakekSekarang.SetActive(true);
        }
        ctrskenario++;
    }
    void RevertAllScenarioToFalse(){
        MCLama.SetActive(false); KakekLama.SetActive(false); MCSekarangTernak.SetActive(false);
        MCSekarang.SetActive(false); KakekSekarang.SetActive(false); Nenek.SetActive(false);
        PeternakanLama.SetActive(false); PeternakanSkg.SetActive(false); Basement.SetActive(false);
        RumahSekarang.SetActive(false); Perjalanan.SetActive(false); Domba.SetActive(false);
        Rahasia.SetActive(false); SapiCutscene.SetActive(false); Renovasi.SetActive(false);
        FinalScenario.SetActive(false);
    }

    public void SkipStory(){
        GameStatus.PickedEvent = "None";
        if(tangkapStory == "Story2"){
            GameStatus.PickedHubWorld = "Level2"; GameStatus.PickedLevel = 1;
            SceneManager.LoadScene("GameplayLevel");
        } else if(tangkapStory == "Story3"){
            GameStatus.PickedHubWorld = "Level2"; GameStatus.PickedLevel = 5;
            SceneManager.LoadScene("GameplayLevel");
        } else if(tangkapStory == "Story4"){
            GameStatus.PickedHubWorld = "Level3"; GameStatus.PickedLevel = 1;
            SceneManager.LoadScene("GameplayLevel");
        } else if(tangkapStory == "Story5"){
            GameStatus.PickedHubWorld = "Level4"; GameStatus.PickedLevel = 1;
            SceneManager.LoadScene("GameplayLevel");
        } else if(tangkapStory == "Story6"){
            GameStatus.PickedHubWorld = "Level5"; GameStatus.PickedLevel = 1;
            SceneManager.LoadScene("GameplayLevel");
        } else if(tangkapStory == "Story7"){
            GameStatus.PickedHubWorld = "Level6"; GameStatus.PickedLevel = 1;
            SceneManager.LoadScene("GameplayLevel");
        } else if(tangkapStory == "FinalStory"){
            GameStatus.PickedHubWorld = "Level7"; GameStatus.PickedLevel = 1;
            SceneManager.LoadScene("GameplayLevel");
        }
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
                SceneManager.LoadScene("GameplayLevel");
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
                SceneManager.LoadScene("GameplayLevel");
            }
        } else if(tangkapStory == "Story4"){
            if(ctrskenario == 1){
                Perjalanan.SetActive(true);
                SkenarioTxt.text = "Tak sabar ketemu kakek dan nenek!!\n\rSemoga mereka masih kerja biar aku langsung turun bantu mereka!";
                MCSekarang.SetActive(true);
            } else if(ctrskenario == 2){
                SkenarioTxt.text = "20 menit kemudian...";
                MCSekarang.SetActive(false);
            } else if(ctrskenario == 3){
                PeternakanSkg.SetActive(true); Perjalanan.SetActive(false);
                SkenarioTxt.text = "Wow, peternakannya berubah jauh dari yang dulu aku ingat!!";
                MCSekarang.SetActive(true);
            } else if(ctrskenario == 4){
                SkenarioTxt.text = "Sayang! Hati-hati kerjainnya!!";
                MCSekarang.SetActive(false); Nenek.SetActive(true);
            } else if(ctrskenario == 5){
                SkenarioTxt.text = "Iya, say!! Aku pelan-pelan sudahan ini!!";
                Nenek.SetActive(false); KakekSekarang.SetActive(true);
            } else if(ctrskenario == 6){
                SkenarioTxt.text = "Wah, kakek lagi dalam kesusahan! Tak ganti dulu secepatnya!!";
                KakekSekarang.SetActive(false); MCSekarang.SetActive(true);
            } else if(ctrskenario == 7){
                SkenarioTxt.text = "SAYANG AWAS ADA DOMBA NYA LARI!!";
                MCSekarang.SetActive(false); Nenek.SetActive(true);
            } else if(ctrskenario == 8){
                SkenarioTxt.text = "HAH! Domba pintar, ayo ayo kembali sana sama teman-temanmu~";
                Nenek.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 9){
                PeternakanSkg.SetActive(false); Domba.SetActive(true);
                SkenarioTxt.text = "CUCUKU!! Kamu datang sangat mendadak sekali!\n\rUntung saja engkau datang tepat waktu lagi HAHAHA!!";
                MCSekarangTernak.SetActive(false); KakekSekarang.SetActive(true);
            } else if(ctrskenario == 10){
                SkenarioTxt.text = "Hahaha, aku sudah super cepat buat ganti ini supaya beri kakek nenek surprise..\n\rMalah terjadi satu domba mau lari~";
                KakekSekarang.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 11){
                SkenarioTxt.text = "Apa kabar, cucuku?\n\rNenek kangen banget sama kamu..";
                MCSekarangTernak.SetActive(false); Nenek.SetActive(true);
            } else if(ctrskenario == 12){
                SkenarioTxt.text = "Baik-baik saja, nenek.\n\r Makasih banyak, nek. Buat untuk jagain kakek yang selalu gegabah~";
                Nenek.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 13){
                SkenarioTxt.text = "HA! Kamu bisanya, cucuku!\n\rBaiklah, sekarang saatnya kita urus domba-domba empuk ini!";
                MCSekarangTernak.SetActive(false); KakekSekarang.SetActive(true);
            } else if(ctrskenario == 14){
                SkenarioTxt.text = "Seperti biasa, cucuku.. Kamu siap untuk pekerjaan lebih baru lagi ini??";
            } else if(ctrskenario == 15){
                SkenarioTxt.text = "SIAP KEK!!";
                KakekSekarang.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 16){
                SkenarioTxt.text = "AYO, CUCUKU!! KITA MENANGKAN BERSAMA-SAMA DARI DOMBA INI!!";
                MCSekarangTernak.SetActive(false); KakekSekarang.SetActive(true);
            } else if(ctrskenario == 17){
                SkenarioTxt.text = "Emang kedua-duanya tidak bisa lepas satu sama lain..\n\rAkhirnya aku bisa nikmati melihat mereka bersama lagi setelah lamanya cucu kita pergi.";
                KakekSekarang.SetActive(false); Nenek.SetActive(true);
            } else if(ctrskenario == 18){
                GameStatus.PickedHubWorld = "Level3"; GameStatus.PickedLevel = 1;
                GameStatus.PickedEvent = "None";
                SceneManager.LoadScene("GameplayLevel");
            }
        } else if(tangkapStory == "Story5"){
            if(ctrskenario == 1){
                SkenarioTxt.text = "Pagi, cucuku yang tercinta.";
                MCSekarangTernak.SetActive(false); Nenek.SetActive(true);
            } else if(ctrskenario == 2){
                SkenarioTxt.text = "Pagi, nek! Kakek masih tidurkah??";
                Nenek.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 3){
                SkenarioTxt.text = "Iya, cucuku. Sayangku tidur lelap banget semenjak kamunya bantu dia terus, hahaha..\n\rNgomong-ngomong gimana kabarnya di kota sana?";
                MCSekarangTernak.SetActive(false); Nenek.SetActive(true);
            } else if(ctrskenario == 4){
                SkenarioTxt.text = "Baik banget kok, nek..\n\rCuma aku lebih puas jikalau bisa bantu kakek nenek daripada aku disana sendiri..";
                Nenek.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 5){
                SkenarioTxt.text = "Semenjak aku pergi dari sini, aku kangen buanget yang namanya mengurus hewan, nek..\n\rNenek pun dulu pas aku masih kecil tidak kelihatan..";
            } else if(ctrskenario == 6){
                SkenarioTxt.text = "Kira-kira, Nenek pas waktu itu ngapain saja?\n\rBahkan kakek pun nda ada diskusi mengenai nenek..";
            } else if(ctrskenario == 7){
                SkenarioTxt.text = "Nenek sedang sibuk jualan bahan produknya yang sudah\n\rSayang dapatkan susah payan...";
                MCSekarangTernak.SetActive(false); Nenek.SetActive(true);
            } else if(ctrskenario == 8){
                SkenarioTxt.text = "Itu yang buat kenapa nenek jaraaaaanggg sekali buat sempati\n\rke kamu semenjak dirimu masih kecil, cucuku..";
            } else if(ctrskenario == 9){
                SkenarioTxt.text = "Maka dari itu, sekarang nenek akan berikan akses dimana kamu..\n\rbisa bantu nenek dengan jualan hasil produk dari kerja keras kalian.";
            } else if(ctrskenario == 10){
                SkenarioTxt.text = "Wow... Nenek ternyata kerja kerasnya di belakang juga.\n\rTerima kasih banyak nek, untuk kerjanya!";
                Nenek.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 11){
                SkenarioTxt.text = "Ahh, kamu ini bisa saja cucuku.\n\r Semua ini berkatmu yang bisa buat kakak nenek semangatnya tidak patah.";
                MCSekarangTernak.SetActive(false); Nenek.SetActive(true);
            } else if(ctrskenario == 12){
                SkenarioTxt.text = "Baiklah, kamu lanjutkan kerjaan kakek sana selagi dia tidur..\n\rNenek akan mulai memasak roti buat sayangku~";
            } else if(ctrskenario == 13){
                SkenarioTxt.text = "SIAP NEK!! Aku urus kerjaan kakek dulu nek!";
                Nenek.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 14){
                SkenarioTxt.text = "Ahhh, nikmatnya kita berdua punya cucu yang semangat sayangku..";
                MCSekarangTernak.SetActive(false); Nenek.SetActive(true);
            } else if(ctrskenario == 15){
                GameStatus.PickedHubWorld = "Level4"; GameStatus.PickedLevel = 1;
                GameStatus.PickedEvent = "None";
                SceneManager.LoadScene("GameplayLevel");
            }
        } else if(tangkapStory == "Story6"){
            if(ctrskenario == 1){
                SkenarioTxt.text = "WHOA! WHOA!! KENAPA KEK!?!?";
                KakekSekarang.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 2){
                SkenarioTxt.text = "Ayo, ikuti kakek...";
                MCSekarangTernak.SetActive(false); KakekSekarang.SetActive(true);
            } else if(ctrskenario == 3){
                SkenarioTxt.text = "Buset, ini kali pertama kakek begini mendadak banguni aku lagi!\n\rKira-kira apaan ya kakek bakal bagikan ke aku?";
                KakekSekarang.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 4){
                PeternakanSkg.SetActive(false);
                SkenarioTxt.text = "10 menit kemudian...";
                MCSekarangTernak.SetActive(false);
            } else if(ctrskenario == 5){
                Basement.SetActive(true);
                SkenarioTxt.text = "Baiklah, cucuku...\n\rIni saatnya engkau mempelajari keahlian yang hanya cuma kakek miliki...";
                KakekSekarang.SetActive(true);
            } else if(ctrskenario == 6){
                SkenarioTxt.text = "Kakek telah menggunakan keahlian ini...\n\rHanya beberapa keturunan dari generasi kita yang mampu dapat keahlian tersebut.";
            } else if(ctrskenario == 7){
                SkenarioTxt.text = "Tapi kakek percaya...bahwa kamu adalah,\n\rPenerus yang kakek percayai bahwa kamu bisa gantikan kakek.";
            } else if(ctrskenario == 8){
                SkenarioTxt.text = "Ambillah ini, cucuku...\n\rEngkau akan menggantikan kakek pada saat yang tepat dengan ini.";
            } else if(ctrskenario == 9){
                Basement.SetActive(false); Rahasia.SetActive(true);
                SkenarioTxt.text = "Ini...resep rahasia??";
                KakekSekarang.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 10){
                SkenarioTxt.text = "Benar sekali, cucuku!\n\rResep ini hanya didapat dari keturunan kakek moyang kita!!";
                MCSekarangTernak.SetActive(false); KakekSekarang.SetActive(true);
            } else if(ctrskenario == 11){
                SkenarioTxt.text = "Selama ini, kakek terus sukses jikalau bukan kerena resep rahasia itu..\n\rMakanya, mulai sekarang akan kubuat cucuku bisa menguasai resep tersebut.";
            } else if(ctrskenario == 12){
                SkenarioTxt.text = "Wow...Selama ini kakek pakai kekuatan rahasia kakek moyang kita toh...?\n\rBaiklah, akan kupelajari ini demi kakek!";
                KakekSekarang.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 13){
                SkenarioTxt.text = "BAGUS!! Ayo, kita mulai dari resep yang tergampang dulu!!\n\rUrusan susah itu nanti-nanti!";
                MCSekarangTernak.SetActive(false); KakekSekarang.SetActive(true);
            } else if(ctrskenario == 14){
                SkenarioTxt.text = "SIAP KAKEK!!";
                KakekSekarang.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 15){
                GameStatus.PickedHubWorld = "Level5"; GameStatus.PickedLevel = 1;
                GameStatus.PickedEvent = "None";
                SceneManager.LoadScene("GameplayLevel");
            }
        } else if(tangkapStory == "Story7"){
            if(ctrskenario == 1){
                SkenarioTxt.text = "Iya nek, ada yang bisa aku bantu??";
                Nenek.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 2){
                SkenarioTxt.text = "Jadi begini, semenjak kamu pergi dari sini..\n\rBeberapa harus ada yang kita perbarui, termasuk sumur kita cucuku..";
                MCSekarangTernak.SetActive(false); Nenek.SetActive(true);
            } else if(ctrskenario == 3){
                SkenarioTxt.text = "Waduh! Kita mending secepatnya perbarui semuanya yang sudah tua-tua, nenek!\n\rAda lagi yang perlu diperbarui selain sumur, nek?";
                Nenek.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 4){
                SkenarioTxt.text = "Iya, cucuku. Truk kita sudah terlalu tua buat melakukan pengiriman barang-barang..\n\rTakutnya pelanggan akan lama menunggu dengan truk tua kita..";
                MCSekarangTernak.SetActive(false); Nenek.SetActive(true);
            } else if(ctrskenario == 5){
                SkenarioTxt.text = "Baik, nenek. Tenang saja. Cucu yang tercintamu...\n\rakan siap memperbarui semua yang dibutuhkan!!";
                Nenek.SetActive(false); MCSekarangTernak.SetActive(true);
            } else if(ctrskenario == 6){
                SkenarioTxt.text = "Iya, cucuku. Terima kasih banyak~\n\rHati-hati kerjakan semuanya~~";
                MCSekarangTernak.SetActive(false); Nenek.SetActive(true);
            } else if(ctrskenario == 7){
                GameStatus.PickedHubWorld = "Level6"; GameStatus.PickedLevel = 1;
                GameStatus.PickedEvent = "None";
                SceneManager.LoadScene("GameplayLevel");
            }
        } else if(tangkapStory == "FinalStory"){
            if(ctrskenario == 1){
                SkenarioTxt.text = "Engkau telah menguasai segala hal-hal yang telah Kakek berikan padamu.. \n\r Begitu hebatnya dirimu telah menguasai dengan cepat tidak seperti kakek pada mudanya AHAHAHAHAHA!!";
            } else if(ctrskenario == 2){
                SkenarioTxt.text = "Ahhh, kek! Jangan begitu lah~ \n\r Ini semua tidak bakal aku bisa raih jikalau tanpa Kakek dan Nenek...";
                MCSekarangTernak.SetActive(true); KakekSekarang.SetActive(false);
            } else if(ctrskenario == 3){
                SkenarioTxt.text = "Hahahaha... Cucuku emang sudah membawa darah semangatnya di sayangku. \n\r Tidak sia-sia dia semangat sekali buatmu, cucuku.";
                Nenek.SetActive(true); MCSekarangTernak.SetActive(false);
            } else if(ctrskenario == 4){
                SkenarioTxt.text = "Terima kasih banyak, nek. Tapi ngomong-ngomong kek... \n\r Ini kita kumpul disini buat apa ya?";
                MCSekarangTernak.SetActive(true); Nenek.SetActive(false);
            } else if(ctrskenario == 5){
                SkenarioTxt.text = "Ehem! Ehem!! \n\r Kakek akan memberi tes terakhir untuk engkau menggantikan posisi Kakek, beneran kali ini.";
                KakekSekarang.SetActive(true); MCSekarangTernak.SetActive(false);
            } else if(ctrskenario == 6){
                SkenarioTxt.text = "Dalam lima tes ini, kau akan menghadapi salah satu tantangan yang tersusah... \n\r Bahkan hanya akulah yang bisa kerjakan itu, semua peternak tidak bisa!";
            } else if(ctrskenario == 7){
                SkenarioTxt.text = "Tenang saja, kek! Dengan semua ajaran-ajaran yang Kakek berikan padaku.. \n\r Apapun itu tesnya, aku siap hadapinya!!";
                MCSekarangTernak.SetActive(true); KakekSekarang.SetActive(false);
            } else if(ctrskenario == 8){
                SkenarioTxt.text = "A HA HA HA HA ! ! \n\r ITULAH BARU CUCUKU YANG KUBANGGAKAN!!";
                KakekSekarang.SetActive(true); MCSekarangTernak.SetActive(false);
            } else if(ctrskenario == 9){
                SkenarioTxt.text = "Ayo! Kita mulai tes nya sekarang juga!!";
            } else if(ctrskenario == 10){
                SkenarioTxt.text = "SIAP KEK!!";
                MCSekarangTernak.SetActive(true); KakekSekarang.SetActive(false);
            } else if(ctrskenario == 11){
                GameStatus.PickedHubWorld = "Level7"; GameStatus.PickedLevel = 1;
                GameStatus.PickedEvent = "None";
                SceneManager.LoadScene("GameplayLevel");
            }
        }

        ctrskenario++;
    }
}
