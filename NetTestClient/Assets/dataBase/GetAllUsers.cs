using System.Collections;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using UnityEditor.PackageManager;
using System.Text.RegularExpressions;
using System.Linq;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using TMPro;

public class GetAllUsers : MonoBehaviour
{
    EndPoints endPoints = new EndPoints();
    public TextMeshProUGUI scoreBoardText;
    Http http = new Http();
    private void Awake()
    {
        Http.hTTPResponseEvent += GetAllUsersResponse;
    }

    private void OnDestroy()
    {
        Http.hTTPResponseEvent -= GetAllUsersResponse;
    }
     
    public void Start()
    {
        StartCoroutine(http.Get(endPoints.GetAllUsersEndPoint, "")); //UTF8, utf8, utf-8
    }
    private void GetAllUsersResponse(string jsonResponse, bool successful)
    {
        Debug.Log(jsonResponse);
        successful = true;
         basicUser[] user = JsonUtility.FromJson<basicUser[]>(jsonResponse);
        


        for (int i = 0; i < user.Length; i++)
        {
            Debug.Log(user[0].Username);
            Debug.Log(user[i].score);
            Debug.Log(user[i]);
            scoreBoardText.text = user[i].username;
        }

        //jsonResponse.Split(':'); //this creates a string variable for every bunching of         //letters that are separated by a space

        /*foreach (var word in words)
       {
         System.Console.WriteLine($"<{word}>");
       }*/



        //print(users);
        /*for(int i = 0; i < users.users.Length; i++)
        {
            print(users.users[i].name);
        }*/
    }
}

public class DataBaseUsers
{
    public DataBaseUser[] users;
}

public class DataBaseUser
{
    public string id;
    public string name;
    public string score;
}


