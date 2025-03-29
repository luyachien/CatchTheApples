using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // 這個函數將會在按鈕被點擊時呼叫
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // 載入遊戲場景
    }
}
