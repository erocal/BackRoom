using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
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
}
