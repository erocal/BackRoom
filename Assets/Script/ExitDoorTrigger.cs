using TMPro;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class ExitDoorTrigger : MonoBehaviour
{

    #region -- 資源參考區 --

    [SerializeField] GameObject winUI;

    [SerializeField] TextMeshProUGUI levelText;

    #endregion

    #region -- 初始化/運作 --

    private void Update()
    {
        if (levelText != null) levelText.text = SceneManager.GetActiveScene().name;
    }

    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false;

        FindObjectOfType<FirstPersonController>().enabled = false;

        // 讓游標顯現，使玩家可以點擊UI
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // 顯現結算畫面UI
        winUI.SetActive(true);
    }

    #endregion

}
