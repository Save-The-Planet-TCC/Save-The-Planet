using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesController : MonoBehaviour
{
    public Canvas UI;
    public GameObject ComputerInteractionPopup;
    public PlayerData playerData;
    public Image speedUpgradeFill;
    public Image trashGatheringUpgradeFill;
    public PlayerController playerController;
    public Text speedPriceText;
    public Text trashGatheringPriceText;
    public int maxUpgradeLevel = 3;
    private bool isPlayerInTrigger = false;
    private Color defaultColor;
    private float price;

    void Start()
    {
        UI.enabled = false;
        ComputerInteractionPopup.SetActive(false);
        playerController.UpdateMovementSpeed();
        defaultColor = speedPriceText.color;
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            UI.enabled = true;
            UpdateUpgradeUI();
        }
    }

    public void CloseGui()
    {
        UI.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            ComputerInteractionPopup.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            ComputerInteractionPopup.SetActive(false);
            UI.enabled = false;
        }
    }

    public void UpgradeSpeed()
    {
        if (playerData.speedUpgradeLevel < maxUpgradeLevel)
        {
            if(playerData.BuySpeedUpgrade(10 + playerData.speedUpgradeLevel * 20))
            {
                UpdateUpgradeUI();
            }
            else
            {
                StartCoroutine(SpeedTurnRed());
            }
        }
    }

    public void UpgradeTrashGathering()
    {
        if (playerData.trashGatheringUpgradeLevel < maxUpgradeLevel)
        {
            if(playerData.BuyTrashGatheringUpgrade(10 + playerData.trashGatheringUpgradeLevel * 20))
            {
                UpdateUpgradeUI();
            }
            else
            {
                StartCoroutine(TrashTurnRed());
            }
        }
    }

    private IEnumerator SpeedTurnRed()
    {
        speedPriceText.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        speedPriceText.color = defaultColor;
    }

    private IEnumerator TrashTurnRed()
    {
        trashGatheringPriceText.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        trashGatheringPriceText.color = defaultColor;
    }

    private void UpdateUpgradeUI()
    {
        playerController.UpdateMovementSpeed();
        speedPriceText.text = TextForPrices(playerData.speedUpgradeLevel);
        trashGatheringPriceText.text = TextForPrices(playerData.trashGatheringUpgradeLevel);
        speedUpgradeFill.fillAmount = (float)playerData.speedUpgradeLevel / maxUpgradeLevel;
        trashGatheringUpgradeFill.fillAmount = (float)playerData.trashGatheringUpgradeLevel / maxUpgradeLevel;
    }

    private string TextForPrices(int upgradeLevel)
    {
        price = 10;
        if(upgradeLevel == 0)
            return $"{price}";
        else if(upgradeLevel < maxUpgradeLevel)
            return (10 + upgradeLevel * 20).ToString();
        return "MAX";
    }

}