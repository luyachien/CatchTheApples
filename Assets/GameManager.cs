using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float gameTime = 60f; // 遊戲時間 60 秒
    private int score = 0;
    public Text timerText;
    public Text scoreText;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    private bool isGameOver = false; // 控制遊戲是否結束

    void Start()
    {
        UpdateUI();
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        while (gameTime > 0 && !isGameOver)
        {
            yield return new WaitForSeconds(1f);
            gameTime--;
            UpdateUI();
        }
        CheckGameOver();
    }

    public void AddScore()
    {
        score++;
        UpdateUI();
        if (score >= 20) // 達成目標
        {
            WinGame();
        }
    }

    void UpdateUI()
    {
        timerText.text = "時間: " + gameTime.ToString("F0");
        scoreText.text = "蘋果數: " + score;
    }

    void CheckGameOver()
    {
        if (score < 20) // 時間到但蘋果不足
        {
            gameOverPanel.SetActive(true);
        }
        Spawner spawner = FindFirstObjectByType<Spawner>();
        if (spawner != null)
        {
            spawner.GameOver(); // 停止掉落物生成
        }
    }

    void WinGame()
    {
        isGameOver = true; // 遊戲結束
        winPanel.SetActive(true);
        StopAllCoroutines(); // 停止計時
        Spawner spawner = FindFirstObjectByType<Spawner>();
        if (spawner != null)
        {
            spawner.GameOver(); // 停止掉落物生成
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
