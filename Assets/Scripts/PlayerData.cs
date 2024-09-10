using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    int score;
    public GameObject coinsText;
    private Text coinsTextComponent;
    public SpawnTrash spawnTrash;
    public int TrashCleaned;
    public int sceneBuildIndex;
    void Start()
    {
        coinsTextComponent = coinsText.GetComponent<Text>();
        LoadPrefs();
        coinsTextComponent.text = score.ToString();
        TrashCleaned = 0;
    }

    private void SavePrefs()
    {
        PlayerPrefs.SetInt("Coins", score);
    }

    private void LoadPrefs()
    {
        score = PlayerPrefs.GetInt("Coins");
    }

    public void AddScore(int scoreAmount)
    {
        score += scoreAmount;
        coinsTextComponent.text = score.ToString();
        SavePrefs();
    }

    public void TrashCleanedTrigger()
    {
        TrashCleaned += 1;
        if (TrashCleaned == spawnTrash.trashCount)
        {
            TrashCleaned = 0;
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    public void ResetData()
    {
        score = 0;
        SavePrefs();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        ResetData();
    //    }
    //}
}
