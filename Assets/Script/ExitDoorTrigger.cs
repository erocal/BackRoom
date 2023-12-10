using TMPro;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class ExitDoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject winUI;

    [SerializeField] TextMeshProUGUI levelText;

    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false;

        FindObjectOfType<FirstPersonController>().enabled = false;

        // �������{�A�Ϫ��a�i�H�I��UI
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // ��{����e��UI
        winUI.SetActive(true);
    }

    private void Update()
    {
        if (levelText != null) levelText.text = SceneManager.GetActiveScene().name;
    }
}
