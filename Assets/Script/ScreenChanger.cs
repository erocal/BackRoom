using UnityEngine;

public class ScreenChanger : MonoBehaviour
{
    /// <summary>
    /// 更改螢幕方向為直式或橫式
    /// </summary>
    private void SwitchOrientation()
    {
        // 切換自動旋轉
        Screen.autorotateToLandscapeLeft = !Screen.autorotateToLandscapeLeft;
        Screen.autorotateToLandscapeRight = !Screen.autorotateToLandscapeRight;
        Screen.autorotateToPortrait = !Screen.autorotateToPortrait;
        Screen.autorotateToPortraitUpsideDown = !Screen.autorotateToPortraitUpsideDown;

        // 獲取目前螢幕方向
        var targetOrientation = Screen.orientation;
        // 切換螢幕方向為另一種方向
        targetOrientation = (targetOrientation == ScreenOrientation.LandscapeLeft) ? ScreenOrientation.Portrait : ScreenOrientation.LandscapeLeft;
        // 應用新方向
        Screen.orientation = targetOrientation;
    }
}
