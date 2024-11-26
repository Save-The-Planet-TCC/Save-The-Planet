using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    private int tempScore;
    private int score;
    private bool debounce;
    private int timesTempMoneyWasGiven = 0;
    private int timesMoneyWasGiven = 0;
    private Text coinsTextComponent;
    public SpawnTrash spawnTrash;
    public GameObject coinsText;
    public TimerScript timerScript;
    public int speedUpgradeLevel;
    public int trashGatheringUpgradeLevel;
    public string Username;
    public int TrashCleaned = 0;
    public int sceneBuildIndex;

    void Start()
    {
        Username = GameData.Instance.Username;
        LoadPrefs();
        coinsTextComponent = coinsText.GetComponent<Text>();
        TrashCleaned = 0;
        tempScore = 0;
        debounce = false;
        timesTempMoneyWasGiven = 0;
        timesMoneyWasGiven = 0;
        UpdateCoinsText();
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetInt($"{Username}_Coins", score);
        PlayerPrefs.SetInt($"{Username}_SpeedUpgradeLevel", speedUpgradeLevel);
        PlayerPrefs.SetInt($"{Username}_TrashGatheringUpgradeLevel", trashGatheringUpgradeLevel);
    }

    public void LoadPrefs()
    {
        score = PlayerPrefs.GetInt($"{Username}_Coins", 0);
        speedUpgradeLevel = PlayerPrefs.GetInt($"{Username}_SpeedUpgradeLevel", 0);
        trashGatheringUpgradeLevel = PlayerPrefs.GetInt($"{Username}_TrashGatheringUpgradeLevel", 0);
    }

    public void AddScore(int tempScore)
    {
        timesMoneyWasGiven += 1;
        if (timesMoneyWasGiven == 1)
        {
            score += tempScore;
        }
        SavePrefs();
    }
    
    public void AddStageScore(int scoreAmount)
    {
        timesTempMoneyWasGiven += 1;
        if(timesTempMoneyWasGiven <= spawnTrash.trashCount)
        {
            tempScore += scoreAmount;
        }
        UpdateCoinsText();
    }

    public void UpdateCoinsText()
    {
        if(TrashCleaned == 0 || TrashCleaned < spawnTrash.trashCount)
        {
            coinsTextComponent.text = (score + tempScore).ToString();
        }
    }

    public void TrashCleanedTrigger()
    {
        TrashCleaned += 1;
        if (TrashCleaned == spawnTrash.trashCount && !debounce)
        {
            debounce = true;
            AddScore(tempScore);
            TrashCleaned = 0;
            timerScript.gameFinished = true;
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    public bool BuySpeedUpgrade(int price)
    {
        if (score >= price)
        {
            score -= price;
            UpdateCoinsText();
            speedUpgradeLevel++;
            SavePrefs();
            return true;
        }
        return false;
    }

    public bool BuyTrashGatheringUpgrade(int price)
    {
        if(score >= price)
        {
            score -= price;
            UpdateCoinsText();
            trashGatheringUpgradeLevel++;
            SavePrefs();
            return true;
        }
        return false;
    }
    public void ResetData()
    {
        score = 0;
        SavePrefs();
    }
}
