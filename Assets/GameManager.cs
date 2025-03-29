using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float gameTime = 60f; // �C���ɶ� 60 ��
    private int score = 0;
    public Text timerText;
    public Text scoreText;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    private bool isGameOver = false; // ����C���O�_����

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
        if (score >= 20) // �F���ؼ�
        {
            WinGame();
        }
    }

    void UpdateUI()
    {
        timerText.text = "�ɶ�: " + gameTime.ToString("F0");
        scoreText.text = "ī�G��: " + score;
    }

    void CheckGameOver()
    {
        if (score < 20) // �ɶ����ī�G����
        {
            gameOverPanel.SetActive(true);
        }
        Spawner spawner = FindFirstObjectByType<Spawner>();
        if (spawner != null)
        {
            spawner.GameOver(); // ��������ͦ�
        }
    }

    void WinGame()
    {
        isGameOver = true; // �C������
        winPanel.SetActive(true);
        StopAllCoroutines(); // ����p��
        Spawner spawner = FindFirstObjectByType<Spawner>();
        if (spawner != null)
        {
            spawner.GameOver(); // ��������ͦ�
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
