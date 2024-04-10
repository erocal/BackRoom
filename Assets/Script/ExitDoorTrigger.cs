using TMPro;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class ExitDoorTrigger : MonoBehaviour
{

    #region -- �귽�ѦҰ� --

    [SerializeField] GameObject winUI;

    [SerializeField] TextMeshProUGUI levelText;

    #endregion

    #region -- ��l��/�B�@ --

    private void Update()
    {
        if (levelText != null) levelText.text = SceneManager.GetActiveScene().name;
    }

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

    #endregion

}
