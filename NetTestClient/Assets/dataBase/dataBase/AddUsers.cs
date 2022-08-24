using System.Collections;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;

public class AddUsers : MonoBehaviour
{
    public string userName;
    public string score;
    public string password;
    public string id;

    private void Awake()
    {
        Http.hTTPResponseEvent += AddUserResponse;
    }
    private void OnDestroy()
    {
        Http.hTTPResponseEvent -= AddUserResponse;
    }

    // Start is called before the first frame update
   

    [ContextMenu("AddUsers")]
    public void AddUser()
    {
        User basicUser = new User("User04", "72", "gsdg", 1600);

       string json = JsonUtility.ToJson(basicUser);
        Http.hTTPResponseEvent += AddUserResponse;
      StartCoroutine( Http.Post(EndPoints.instance.AddUserEndPoint, json));
    }

    private void AddUserResponse(string jsonResponse, bool successful)
    {
        
        print(jsonResponse);
    }


}
