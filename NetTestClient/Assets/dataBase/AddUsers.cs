using System.Collections;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;

public class AddUsers : MonoBehaviour
{
    public string userName = "Techland145";
    public int score = 1200;
    public string password = "45rg";
    public string id = "131";

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
        basicUser basicUser = new basicUser("User01", "79", "bfg64", 1800);

       string json = JsonUtility.ToJson(basicUser);
        Http.hTTPResponseEvent += AddUserResponse;
      StartCoroutine( Http.Post(EndPoints.instance.AddUserEndPoint, json));
    }

    private void AddUserResponse(string jsonResponse, bool successful)
    {
        
        print(jsonResponse);
    }


}
