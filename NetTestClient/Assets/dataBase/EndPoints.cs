using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoints : MonoBehaviour
{
   public static EndPoints instance;

 private enum ServerType {Dev, Stage, Prod}
    [SerializeField] ServerType serverType;
    [SerializeField] string serverIpAddress ="127.0.0.1"; //give it an IP address
    private enum SeverProtocol { Http, Https };
    [SerializeField]  SeverProtocol protocol;

    string Protocol
    {
        get
        {
            switch (protocol)
            {
                case SeverProtocol.Http:
                    return "http";

                case SeverProtocol.Https:
                    return "https";

                
                default:
                    return "http";
            }
        }
    }

    int GetServerPort
    {
        get
        {
            switch (serverType)
            {
                case ServerType.Dev:
                    return 1600;

                case ServerType.Stage:
                    return 3000;

                case ServerType.Prod:
                    return 5000;
                default:
                    return 1600;
            }
        }
    }

    public string GetUserEndPoint
    {
        get { return $"{Protocol}://{serverIpAddress}:{GetServerPort}{"/get-user"}"; }       
    }

    public string AddUserEndPoint
    {
        get { return $"{Protocol}://{serverIpAddress}:{GetServerPort}{"/add-user"}"; }
    }

    public string GetAllUsersEndPoint
    {
        get { return $"{Protocol}://{serverIpAddress}:{GetServerPort}{"/get-all-users"}"; }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        else
            Destroy(gameObject);
        
            
               
    }

}