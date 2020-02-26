using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DioramaManager : MonoBehaviour
{
    public GameObject Ayam, Sapi, Domba, Anjing, Kucing, Beruang, Mole;
    public Text TitleEncycloTxt, EncycloTxt;
    Image tumpangsprite;
    Sprite gambarSekarang;
    public Image gambarnow;
    

    public void CekEncyclo(string namahewan){
        if(namahewan == "Anjing"){
            tumpangsprite = Anjing.GetComponent<Image>();
            gambarSekarang = tumpangsprite.sprite;
            TitleEncycloTxt.text = "Anjing";
            EncycloTxt.text = "Anjing adalah hewan mamalia yang memiliki indra penciuman yang sangat tajam. Banyak dari kita memelihara anjing. Selain mudah dijumpai, adanya anjing akan menjaga hewan produktif dari serangan beruang yang ganas!";
        } else if(namahewan == "Ayam"){
            tumpangsprite = Ayam.GetComponent<Image>();
            gambarSekarang = tumpangsprite.sprite;
            TitleEncycloTxt.text = "Ayam";
            EncycloTxt.text = "Ayam merupakan hewan produktif yang sangat murah dan gampang didapat. Ayam selalu berkokok setiap pagi hari mendatang. Hari baru, Ayam kokok! Ayam menghasilkan telur.";
        }
    }
    public void UbahGambar(){
        gambarnow.sprite = gambarSekarang;
    }
}
