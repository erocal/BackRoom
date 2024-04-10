using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameManager : MonoBehaviour
{

    #region -- 資源參考區 --

    [SerializeField] TextMeshProUGUI loadLevelText; // 將載入的場景

    [Header("載入遊戲的按鈕")]
    [Tooltip("載入遊戲的按鈕")]
    [SerializeField] Button loadButton;

    #endregion

    #region -- 初始化/運作 --

    private void Awake()
    {
        if ( string.IsNullOrWhiteSpace(PlayerPrefs.GetString("loaded level", " ")) )
        {
            loadButton.interactable = false;
        }
        else
        {
            loadButton.interactable= true;

            loadLevelText.text = PlayerPrefs.GetString("loaded level", " ");
        }
    }

    #endregion

    #region -- 方法參考區--

    /// <summary>
    /// 載入遊戲關卡
    /// </summary>
    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("loaded level"));
    }

    #endregion

}
