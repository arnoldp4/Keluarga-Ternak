using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DioramaManager : MonoBehaviour
{
    public GameObject Ayam, Sapi, Domba, Anjing, Kucing, Beruang, Mole, 
        Telur, Susu, Wol;
    public Text TitleEncycloTxt, EncycloTxt;
    Image tumpangsprite;
    Sprite gambarSekarang;
    public Image gambarnow;
    

    public void CekEncyclo(string namahewan){
        if(namahewan == "Anjing"){
            tumpangsprite = Anjing.GetComponent<Image>();
            TitleEncycloTxt.text = "Anjing";
            EncycloTxt.text = "Anjing adalah hewan mamalia yang memiliki indra penciuman yang sangat tajam. Banyak dari kita memelihara anjing. Selain mudah dijumpai, adanya anjing akan menjaga hewan produktif dari serangan beruang yang ganas!";
        } else if (namahewan == "Kucing"){
            tumpangsprite = Kucing.GetComponent<Image>();
            TitleEncycloTxt.text = "Kucing";
            EncycloTxt.text = "Kucing merupakan salah satu teman peternak yang setia menemani untuk meminta makanan. Maka dari itu, kebiasaan kucing selalu mengambil produk utama dari hewan produktif.";
        } else if(namahewan == "Ayam"){
            tumpangsprite = Ayam.GetComponent<Image>();
            TitleEncycloTxt.text = "Ayam";
            EncycloTxt.text = "Ayam merupakan hewan produktif yang sangat murah dan gampang didapat. Ayam selalu berkokok setiap pagi hari mendatang. Hari baru, Ayam kokok! Ayam menghasilkan telur.";
        } else if(namahewan == "Sapi"){
            tumpangsprite = Sapi.GetComponent<Image>();
            TitleEncycloTxt.text = "Sapi";
            EncycloTxt.text = "Sapi adalah hewan diam namun bersuara keras setelah ketemu dengan teman-temannya. Setiap hari disaat mood dia girang banget, mereka menghasilkan banyak susu! Lebih hebatnya lagi, susu sapi merupakan hasil utama sapi!!";
        } else if(namahewan == "Domba"){
            tumpangsprite = Domba.GetComponent<Image>();
            TitleEncycloTxt.text = "Domba";
            EncycloTxt.text = "Domba merupakan hewan terempuk dengan bulu-bulunya yang super duper lembut!! Ketenangan dari domba selalu dikenal untuk membuat tidur pada anak-anak. Dengan begitu, bulu domba yang super halus merupakan hasil utama dari domba~";
        } else if(namahewan == "Beruang"){
            tumpangsprite = Beruang.GetComponent<Image>();
            TitleEncycloTxt.text = "Beruang";
            EncycloTxt.text = "ADA BERUANG!! Itu reaksi semua hewan-hewan produktif apabila munculnya seekor beruang. Dia suka melempar hewan produktif keluar dari tempatnya sehingga dia merasa bahwa dia paling berkuasa. Jangan lupa ditekan untuk melempar dia kembali!!";
        } else if(namahewan == "Tikus Tanah"){
            tumpangsprite = Mole.GetComponent<Image>();
            TitleEncycloTxt.text = "Tikus Tanah";
            EncycloTxt.text = "Tikus Tanah ini terdapat keahlian yang sangat hebat seperti Kucing! Namun, keahlian tersebut disalahgunakan olehnya sehingga dia tidak memberikan hasil utama ke kitanya. Makanya setelah temui dia, tekan terus agar dia kembali ke tanah!";
        } else if(namahewan == "Telur"){
            tumpangsprite = Telur.GetComponent<Image>();
            TitleEncycloTxt.text = "Telur";
            EncycloTxt.text = "Telur merupakan hasil utama dari Ayam. Telur mengandung protein yang sangat banyak!! Telur dapat dikembangkan menjadi:\n\rTelur Kering,\n\rKue, dan\n\rPancake dengan bahan khusus yaitu Sirup.";
        } else if(namahewan == "Susu"){
            tumpangsprite = Susu.GetComponent<Image>();
            TitleEncycloTxt.text = "Susu";
            EncycloTxt.text = "Susu itu adalah salah satu hasil utama yang didapat dari Sapi, yang super moowwenak!! Susu sapi tersebut dapat dibuat menjadi:\n\rButter,\n\rKeju, dan\n\rPizza yang membutuhkan bahan khusus yaitu Tepung.";
        } else if(namahewan == "Wol"){
            tumpangsprite = Wol.GetComponent<Image>();
            TitleEncycloTxt.text = "Wol";
            EncycloTxt.text = "Wol adalah hasil utama yang terdapat pada domba dengan memotongnya, pemotongan domba bukan dengan sembarangan gunting lho! Kumpulan domba wol dapat jadi beberapa produk seperti:\n\rBenang,\n\rKain, dan\n\rBaju dengan tambahan bahan khusus merupakan Cat!";
        }
        
        gambarSekarang = tumpangsprite.sprite;
    }
    public void UbahGambar(){
        gambarnow.sprite = gambarSekarang;
    }
}
