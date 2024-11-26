using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public string Username = "";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetUsername(string username)
    {
        Username = username;
    }
}
