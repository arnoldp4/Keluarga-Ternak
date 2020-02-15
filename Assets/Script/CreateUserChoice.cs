using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUserChoice : MonoBehaviour
{
    public GameObject userBtn;
    public static string cekCreateUser;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GetUserBtn(){
        if(userBtn.name == "User1Btn"){
            if(DataPlayer.CreatedUser1 == false){
                cekCreateUser = "User1";
            }
        } else if(userBtn.name == "User2Btn"){
            if(DataPlayer.CreatedUser2 == false){
                cekCreateUser = "User2";
            }
        }
        Debug.Log("User yang dipilih: " + cekCreateUser);
    }
}
