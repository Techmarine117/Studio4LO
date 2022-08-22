using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UsersInfo : MonoBehaviour
{
   public basicUser[] users;

    public basicUser[] Users{ get { return users; } }

    public UsersInfo(basicUser[] clients)
    {
        this.users = clients;
    }
}
