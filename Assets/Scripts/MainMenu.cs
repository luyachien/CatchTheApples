using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject coverPanel; // �ʭ� Panel
    public GameObject instructionsPanel; // �C������ Panel

    void Start()
    {
        coverPanel.SetActive(true); // �C���}�l����ܫʭ�
        instructionsPanel.SetActive(false); // ���ùC������
    }

    void Update()
    {
        // �p�G���a���U�������ηƹ��I���A�i�J�C������
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            ShowInstructions();
        }
    }

    public void ShowInstructions()
    {
        coverPanel.SetActive(false); // ���ëʭ�
        instructionsPanel.SetActive(true); // ��ܹC������
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // �i�J�����C��
    }
}
