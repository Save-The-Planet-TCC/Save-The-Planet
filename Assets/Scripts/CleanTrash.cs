using UnityEngine;

public class CleanTrash : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    public GameObject Trash;
    public PlayerData playerData;
    public int minCash;
    public int maxCash;

    private void Start()
    {
        minCash = 5; 
        maxCash = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Trash.SetActive(false);
            playerData.TrashCleanedTrigger();   
            playerData.AddScore(Random.Range(minCash, maxCash));
        }
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
        }
    }
}
