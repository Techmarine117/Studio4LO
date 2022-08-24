using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


[System.Serializable]
public class BasicUser
{
    public User user;
    
}

[System.Serializable]
public class User
{
    public string id;
    public string username;
    public string password;
    public int score;
    
   

    public User()
    {

    }
    public User(string name, string playerId, string password, int playerScore)
    {
        this.username = name;
        this.id = playerId;
        this.password = password;
        this.score = playerScore;
    }
}