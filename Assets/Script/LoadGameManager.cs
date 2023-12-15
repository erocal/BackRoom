using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI loadLevelText; // 將載入的場景

    [Header("載入遊戲的按鈕")]
    [Tooltip("載入遊戲的按鈕")]
    [SerializeField] Button loadButton;

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

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("loaded level"));
    }
}
