using UnityEngine;

public class SpawnTrash : MonoBehaviour
{
    public GameObject trashPrefab;
    public Transform spawnArea;
    public PlayerData playerData;
    public int minTrash = 1;
    public int maxTrash = 10;
    public int trashCount;
    private float randomX;
    private float randomY;

    void Start()
    {
        trashCount = Random.Range(minTrash, maxTrash);

        BoxCollider2D boxCollider = spawnArea.GetComponent<BoxCollider2D>();
        Bounds bounds = boxCollider.bounds;
        for (int i = 0; i < trashCount; i++)
        {
            randomX = Random.Range(bounds.min.x, bounds.max.x);
            randomY = Random.Range(bounds.min.y, bounds.max.y);
            Vector2 spawnPosition = new Vector2(randomX, randomY);
            GameObject trashInstance = Instantiate(trashPrefab, spawnPosition, Quaternion.identity);
            CleanTrash cleanTrash = trashInstance.GetComponentInChildren<CleanTrash>();
            if (cleanTrash != null)
            {
                cleanTrash.playerData = playerData;
            }
        }
    }
}
