using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // �o�Ө�ƱN�|�b���s�Q�I���ɩI�s
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // ���J�C������
    }
}
