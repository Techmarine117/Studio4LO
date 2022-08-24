using System.Collections;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using UnityEditor.PackageManager;
using System.Text.RegularExpressions;
using System.Linq;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using TMPro;
using System;

[System.Serializable]
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
        DataBaseUsers users = JsonUtility.FromJson<DataBaseUsers>(jsonResponse);


        Debug.Log(users.users[0].username);
        Debug.Log(users.users[0].score);
        
        //scoreBoardText.text = users.user.username;

        // Debug.Log(user.Length);                                  


        print(users);
        for(int i = 0; i < users.users.Length; i++)
        {
            for (int j = 0; j < users.users.Length; j++)
            {
                if (users.users[i].score > users.users[j].score)
                {
                    DataBaseUser copy = users.users[i];
                    users.users[i] = users.users[j];
                    users.users[j] = copy;
                    
                }
            }
        }
        string scoreText = "";

        for (int i = 0; i < users.users.Length; i++)
        {
            scoreText += $"{i + 1}. {users.users[i].username} - {users.users[i].score}\n";
        }
            scoreBoardText.text = scoreText;
    }
}

[Serializable]
public class DataBaseUsers
{
    public DataBaseUser[] users;
}

[Serializable]
public class DataBaseUser
{
   
    public string username;
    public int score;
}


