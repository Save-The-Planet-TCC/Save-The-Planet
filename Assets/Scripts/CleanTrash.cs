using UnityEngine;
using UnityEngine.UI;

public class CleanTrash : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    private float holdTime = 0f;
    private float requiredHoldTime = 1f;
    public GameObject Trash;
    public Canvas progressCanvas;
    public Image progressBarFill;
    public PlayerData playerData;
    public int minCash;
    public int maxCash;

    private void Awake()
    {
        holdTime = 0f;
    }

    void Update()
    {
        requiredHoldTime = Mathf.Max(0.5f, 2 / (playerData.trashGatheringUpgradeLevel + 1));

        if (holdTime == 0f)
            progressCanvas.gameObject.SetActive(false);
        else
            progressCanvas.gameObject.SetActive(true);

        if (isPlayerInTrigger)
        {
            if (Input.GetKey(KeyCode.E))
            {
                holdTime += Time.deltaTime;
                progressBarFill.fillAmount = holdTime / requiredHoldTime;
                
                if (holdTime >= requiredHoldTime)
                {
                    Clean();
                    holdTime = 0f;
                }
            }
            else
            {
                if (holdTime > 0f)
                {
                    holdTime -= Time.deltaTime;
                    progressBarFill.fillAmount = holdTime / requiredHoldTime;
                }
                else
                    holdTime = 0f;
            }
        }
        else
        {
            if (holdTime > 0f)
            {
                holdTime -= Time.deltaTime;
                progressBarFill.fillAmount = holdTime / requiredHoldTime;
            }
            else
                holdTime = 0f;
        }
    }

    private void Clean()
    {
        playerData.AddStageScore(Random.Range(minCash, maxCash));
        Trash.SetActive(false);
        isPlayerInTrigger = false;
        playerData.TrashCleanedTrigger();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            if (holdTime > 0f)
            {
                holdTime -= Time.deltaTime;
                progressBarFill.fillAmount = holdTime / requiredHoldTime;
            }
            else
                holdTime = 0f;
        }
    }
}
