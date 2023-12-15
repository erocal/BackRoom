using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevel : MonoBehaviour
{
    [SerializeField] GameObject SaveGameUI; // "自動儲存 :) ......"

    [Range(1, 30)]
    [SerializeField] float timeBetweenSaves; // 自動儲存的時間間隔

    private void Awake()
    {
        InvokeRepeating(nameof(SaveGame), timeBetweenSaves, timeBetweenSaves); // 在自動儲存的時間間隔不斷呼叫SaveGame()
    }

    private void SaveGame()
    {
        SaveGameUI.SetActive(true);

        // 儲存目前的Level供下次載入遊戲
        PlayerPrefs.SetString("loaded level", SceneManager.GetActiveScene().name);

        PlayerPrefs.Save();

        Invoke(nameof(HideUI), 3);
    }

    private void HideUI()
    {
        SaveGameUI.SetActive(false);
    }
}
