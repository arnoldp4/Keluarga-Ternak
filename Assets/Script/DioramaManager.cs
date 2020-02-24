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
            tumpangsprite = gameObject.GetComponent<Image>();
            gambarSekarang = tumpangsprite.sprite;
            TitleEncycloTxt.text = "Anjing";
            EncycloTxt.text = "Anjing adalah hewan mamalia yang memiliki indra penciuman yang sangat tajam. Banyak dari kita memelihara anjing. Selain mudah dijumpai, anjing juga dapat menjadi hewan penjaga rumah serta menjadi kawan untuk bermain.";
        }
    }
    public void UbahGambar(){
        gambarnow.sprite = gambarSekarang;
    }
}
