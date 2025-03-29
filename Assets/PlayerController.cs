using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private bool canMove = true;
    private GameManager gameManager;
    private bool isCoolingDown = false; // 冷卻狀態

    private float minX, maxX; // 用來設定左右邊界

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        // 計算左右邊界
        Camera mainCamera = Camera.main;
        float cameraWidth = mainCamera.orthographicSize * mainCamera.aspect; // 計算畫面寬度
        minX = -cameraWidth + 0.5f;  // 左邊界 (微調)
        maxX = cameraWidth - 0.5f;   // 右邊界 (微調)
    }

    void Update()
    {
        if (canMove && !isCoolingDown)
        {
            float move = Input.GetAxis("Horizontal");

            // 計算新的位置
            float newX = transform.position.x + move * speed * Time.deltaTime;

            // 限制左右邊界
            newX = Mathf.Clamp(newX, minX, maxX);

            // 更新位置
            transform.position = new Vector2(newX, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCoolingDown) // 如果在冷卻期間，不處理任何碰撞
            return;

        if (other.CompareTag("Apple"))
        {
            gameManager.AddScore(); // 加分
            Destroy(other.gameObject); // 刪除蘋果
        }
        else if (other.CompareTag("Bomb"))
        {
            StartCoroutine(FreezeMovement()); // 開始冷卻
            Destroy(other.gameObject); // 刪除炸彈
        }
    }

    // 冷卻時間的協程
    IEnumerator FreezeMovement()
    {
        isCoolingDown = true;
        canMove = false; // 停止移動
        yield return new WaitForSeconds(3); // 3秒冷卻
        canMove = true; // 恢復移動
        isCoolingDown = false; // 結束冷卻
    }
}

