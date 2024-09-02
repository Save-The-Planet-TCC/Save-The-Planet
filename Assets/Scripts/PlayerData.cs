using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    int score;
    public GameObject coinsText;
    private Text coinsTextComponent;
    public int TrashCleaned;
    public int sceneBuildIndex;
    void Start()
    {
        coinsTextComponent = coinsText.GetComponent<Text>();
        LoadPrefs();
        coinsTextComponent.text = score.ToString();
    }

    private void SavePrefs()
    {
        PlayerPrefs.SetInt("Coins", score);
    }

    private void LoadPrefs()
    {
        score = PlayerPrefs.GetInt("Coins");
    }

    void Update()
    {
        if (TrashCleaned == 4)
        {
            TrashCleaned = 0;
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
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
    }
}
