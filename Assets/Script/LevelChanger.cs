﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    #region -- 方法參考區 --

    /// <summary>
    /// 切換到傳入名稱的場景
    /// </summary>
    /// <param name="sceneName">場景名稱</param>
    public void ChangeScene( string sceneName )
    {
        SceneManager.LoadScene( sceneName ); // 切換到傳入名稱的場景
    }

    #endregion

}
