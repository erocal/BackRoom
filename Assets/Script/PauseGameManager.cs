using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseGameManager : MonoBehaviour
{
    [Header("要顯示Level的Text")]
    [Tooltip("要顯示Level的Text")]
    [SerializeField] TextMeshProUGUI levelText;

    [Header("要顯示暫停的UI")]
    [Tooltip("要顯示暫停的UI")]
    [SerializeField] GameObject pauseCanvas;

    [Header("結算畫面的UI")]
    [Tooltip("結算畫面的UI")]
    [SerializeField] GameObject winUI;

    [Header("暫停的按鍵")]
    [Tooltip("暫停的按鍵")]
    [SerializeField] KeyCode pauseKey = KeyCode.Escape;

    #region -- 參數參考區 --

    // 是否暫停
    bool isPaused = false;

    #endregion
    void Update()
    {
        if (levelText.text != SceneManager.GetActiveScene().name)
            levelText.text = SceneManager.GetActiveScene().name;

        if (Input.GetKeyUp(pauseKey) && !winUI.activeInHierarchy) isPaused = !isPaused;

        if (isPaused)
        {
            pauseCanvas.SetActive(true);

            Time.timeScale = 0f;
            AudioListener.pause = true;

            // 讓鼠標能夠自由移動
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // 取消角色移動
            FindObjectOfType<FirstPersonController>().enabled = false;
        }
        else
        {
            pauseCanvas.SetActive(false);

            ResumeGame();
        }
    }

    /// <summary>
    /// 繼續遊戲
    /// </summary>
    public void ResumeGame()
    {
        isPaused = false;

        Time.timeScale = 1f;
        AudioListener.pause = false;


        if (!winUI.activeInHierarchy)
        {
            // 讓鼠標能夠自由移動
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // 取消角色移動
            FindObjectOfType<FirstPersonController>().enabled = true;
        }
        
    }

    /// <summary>
    /// 重玩這一關
    /// </summary>
    public void RestartLevel()
    {
        ResumeGame();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// 回到主畫面
    /// </summary>
    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
