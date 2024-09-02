using UnityEngine;

public class CleanTrash : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    public GameObject Trash;
    public PlayerData playerData;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Trash.SetActive(false);
            playerData.TrashCleanedTrigger();
            playerData.AddScore(10);
        }
    }

    // When the player enters the trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    // When the player exits the trigger zone
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
}
