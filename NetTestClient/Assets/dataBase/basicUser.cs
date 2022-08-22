using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class basicUser
{
    public string username;
    public string id;
    public string password;
    public int score;



    public string Username { get { return username; } }
    public string Id { get { return id; } }
    public string Password { get { return password; } }
    public int Score { get { return score; } }

    public basicUser(string name, string playerId, string password, int playerScore)
    {
        this.username = name;
        this.id = playerId;
        this.password = password;
        this.score = playerScore;
    }
}
