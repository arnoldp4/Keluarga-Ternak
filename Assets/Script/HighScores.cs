using System.Collections;
using System.Collections.Generic;
using FullSerializer;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    public Text HighScoreText;
    //Dropdown Variable
    public Dropdown changeuserDD;
    Dropdown.OptionData newDataDD; //to add new Option on dropdown from Firebase
    //List for applying all of the new Options
    List<Dropdown.OptionData> m_Messages = new List<Dropdown.OptionData>();
    int m_Index;
    public static fsSerializer serializer = new fsSerializer();
    public delegate void GetUsersCallback(Dictionary<string, UserFirebase> users);
    /// <summary>
    /// Gets all users from the Firebase Database
    /// </summary>
    /// <param name="callback"> What to do after all users are downloaded successfully </param>

    void Start()
    {
        //HighScoreText.text = "Available Users: \r\n \r\n";
        GetUsers(users =>
        {
            foreach (var user in users)
            {
                // HighScoreText.text = HighScoreText.text +
                //     user.Value.userName + " - " +
                //     user.Value.userLvProg;
                // HighScoreText.text += "\r\n";
                //Debug.Log($"{user.Value.userName} {user.Value.userScore}");
                newDataDD = new Dropdown.OptionData();
                newDataDD.text = user.Value.userName;
                changeuserDD.options.Add(newDataDD);
            }
        });
        int menuIndex = changeuserDD.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> menuOptions = changeuserDD.GetComponent<Dropdown>().options;
        string value = menuOptions [menuIndex].text;
    }
    public static void GetUsers(GetUsersCallback callback)
    {
        RestClient.Get($"https://tugas-akhir-stts-2019.firebaseio.com/.json").Then(response =>
        {
            var responseJson = response.Text;

            // Using the FullSerializer library: https://github.com/jacobdufault/fullserializer
            // to serialize more complex types (a Dictionary, in this case)
            var data = fsJsonParser.Parse(responseJson);
            object deserialized = null;
            serializer.TryDeserialize(data, typeof(Dictionary<string, UserFirebase>), ref deserialized);

            var users = deserialized as Dictionary<string, UserFirebase>;
            callback(users);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
