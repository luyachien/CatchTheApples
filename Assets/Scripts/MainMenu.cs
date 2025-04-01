using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject coverPanel; // 封面 Panel
    public GameObject instructionsPanel; // 遊戲說明 Panel

    void Start()
    {
        coverPanel.SetActive(true); // 遊戲開始時顯示封面
        instructionsPanel.SetActive(false); // 隱藏遊戲說明
    }

    void Update()
    {
        // 如果玩家按下任何按鍵或滑鼠點擊，進入遊戲說明
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            ShowInstructions();
        }
    }

    public void ShowInstructions()
    {
        coverPanel.SetActive(false); // 隱藏封面
        instructionsPanel.SetActive(true); // 顯示遊戲說明
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // 進入正式遊戲
    }
}
