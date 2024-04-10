using UnityEngine;

public class ExitGameButton : MonoBehaviour
{

    #region -- 方法參考區 --

    /// <summary>
    /// 結束遊戲
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

        #endif
    }

    #endregion

}
