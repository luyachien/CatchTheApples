using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    public float spawnRate = 1f;
    public Transform spawnPoint;
    private bool isGameOver = false;

    void Start()
    {
        isGameOver = false; // 遊戲開始時為 false
        InvokeRepeating("SpawnObject", 1f, spawnRate);
    }

    void Update()
    {
        // 如果遊戲結束，停止生成
        if (isGameOver)
        {
            CancelInvoke("SpawnObject");
        }
    }

    void SpawnObject()
    {
        if (!isGameOver)
        {
            GameObject obj = Random.value > 0.8f ? bombPrefab : applePrefab;
            Instantiate(obj, new Vector2(Random.Range(-8f, 8f), spawnPoint.position.y), Quaternion.identity);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
