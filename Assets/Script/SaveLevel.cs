using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevel : MonoBehaviour
{

    #region -- 資源參考區 --

    [SerializeField] GameObject SaveGameUI; // "自動儲存 :) ......"

    [Range(1, 30)]
    [SerializeField] float timeBetweenSaves; // 自動儲存的時間間隔

    #endregion

    #region -- 初始化/運作 --

    private void Awake()
    {
        InvokeRepeating(nameof(SaveGame), timeBetweenSaves, timeBetweenSaves); // 在自動儲存的時間間隔不斷呼叫SaveGame()
    }

    #endregion

    #region -- 方法參考區 --

    /// <summary>
    /// 自動儲存遊戲進度
    /// </summary>
    private void SaveGame()
    {
        SaveGameUI.SetActive(true);

        // 儲存目前的Level供下次載入遊戲
        PlayerPrefs.SetString("loaded level", SceneManager.GetActiveScene().name);

        PlayerPrefs.Save();

        Invoke(nameof(HideUI), 3);
    }

    /// <summary>
    /// 將保存遊戲進度的UI關閉
    /// </summary>
    private void HideUI()
    {
        SaveGameUI.SetActive(false);
    }

    #endregion

}
