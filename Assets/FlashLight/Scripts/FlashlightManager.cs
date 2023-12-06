using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlashlightState
{
    Off,
    On,
    Dead
}

public class FlashlightManager : MonoBehaviour
{
    [Header("電池量損失的速度")]
    [Tooltip("電池量損失的速度")]
    [Range(0.0f, 2f)][SerializeField] float batteryLossTick = 0.5f;

    [Header("最大電池量")]
    [Tooltip("最大電池量")]
    [SerializeField] int maxBattery = 100;

    [Header("目前的電池量")]
    [Tooltip("目前的電池量")]
    [SerializeField] int currentBattery;

    [Header("手電筒的狀態")]
    [Tooltip("目前的電池量")]
    [SerializeField] FlashlightState state;

    [Header("決定開啟手電筒的按鍵")]
    [Tooltip("決定開啟手電筒的按鍵")]
    [SerializeField] KeyCode ToggleKey;

    [Header("手電筒的光")]
    [Tooltip("手電筒的光")]
    [SerializeField] GameObject flashlightLight;

    #region -- 參數參考區 --

    [Tooltip("手電筒的燈是否開啟")]
    private bool flashlightIsOn = true;

    #endregion

    #region -- 初始化/運作 --

    private void Awake()
    {
        currentBattery = maxBattery;
    }

    private void Start()
    {
        // 在0秒後，每隔batteryLossTick秒呼叫LoseBattery函數(扣電量)
        InvokeRepeating(nameof(LoseBattery), 0, batteryLossTick);
    }

    void Update()
    {
        if (Input.GetKeyDown(ToggleKey)) { ToogleFlashlight(); } // 是否按了手電筒的開關

        if ( state == FlashlightState.Off || state == FlashlightState.Dead) flashlightLight.SetActive(false);
        else if (state == FlashlightState.On) flashlightLight.SetActive(true);
    
        if ( currentBattery <= 0 )
        {
            currentBattery = 0;
            state = FlashlightState.Dead;
        }
    }

    #endregion

    #region -- 方法參考區 --

    private void GainBattery( int amount )
    {
        if ( currentBattery == 0 )
        {
            state = FlashlightState.On;
            flashlightIsOn = true;
        }

        if (currentBattery + amount > maxBattery)
        {
            currentBattery = maxBattery;
        }
        else currentBattery += amount;
    }

    private void LoseBattery()
    {
        if (state == FlashlightState.On) currentBattery--;
    }

    // 開啟/關閉手電筒
    private void ToogleFlashlight()
    {
        flashlightIsOn = !flashlightIsOn;

        if ( state == FlashlightState.Dead ) flashlightIsOn = false;
    }

    #endregion
}
