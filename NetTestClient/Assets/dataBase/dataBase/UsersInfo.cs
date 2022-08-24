using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UsersInfo : MonoBehaviour
{
   public BasicUser[] users;

    public BasicUser[] Users{ get { return users; } }

    public UsersInfo(BasicUser[] clients)
    {
        this.users = clients;
    }
}
