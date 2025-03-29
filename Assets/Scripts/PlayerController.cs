using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private bool canMove = true;
    private GameManager gameManager;
    private bool isCoolingDown = false; // �N�o���A

    private float minX, maxX; // �Ψӳ]�w���k���

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        // �p�⥪�k���
        Camera mainCamera = Camera.main;
        float cameraWidth = mainCamera.orthographicSize * mainCamera.aspect; // �p��e���e��
        minX = -cameraWidth + 0.5f;  // ����� (�L��)
        maxX = cameraWidth - 0.5f;   // �k��� (�L��)
    }

    void Update()
    {
        if (canMove && !isCoolingDown)
        {
            float move = Input.GetAxis("Horizontal");

            // �p��s����m
            float newX = transform.position.x + move * speed * Time.deltaTime;

            // ����k���
            newX = Mathf.Clamp(newX, minX, maxX);

            // ��s��m
            transform.position = new Vector2(newX, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCoolingDown) // �p�G�b�N�o�����A���B�z����I��
            return;

        if (other.CompareTag("Apple"))
        {
            gameManager.AddScore(); // �[��
            Destroy(other.gameObject); // �R��ī�G
        }
        else if (other.CompareTag("Bomb"))
        {
            StartCoroutine(FreezeMovement()); // �}�l�N�o
            Destroy(other.gameObject); // �R�����u
        }
    }

    // �N�o�ɶ�����{
    IEnumerator FreezeMovement()
    {
        isCoolingDown = true;
        canMove = false; // �����
        yield return new WaitForSeconds(3); // 3��N�o
        canMove = true; // ��_����
        isCoolingDown = false; // �����N�o
    }
}

