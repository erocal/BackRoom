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

    [Header("開始時攜帶的電池量")]
    [Tooltip("開始時攜帶的電池量")]
    [SerializeField] int startBattery = 100;

    [Header("目前的電池量")]
    [Tooltip("目前的電池量")]
    [SerializeField] int currentBattery;

    [Header("手電筒的狀態")]
    [Tooltip("目前的電池量")]
    [SerializeField] FlashlightState state;

    [Header("決定開啟手電筒的按鍵")]
    [Tooltip("決定開啟手電筒的按鍵")]
    [SerializeField] KeyCode ToggleKey;

    private bool flashlightIsOn = true;

    private void Awake()
    {
        currentBattery = startBattery;
    }

    private void Start()
    {
        // 在0秒後，每隔batteryLossTick秒呼叫LoseBattery函數(扣電量)
        InvokeRepeating(nameof(LoseBattery), 0, batteryLossTick);
    }

    void Update()
    {
        if (Input.GetKeyDown(ToggleKey)) { ToogleFlashlight(); }
    }

    private void GainBattery( int amount )
    {

    }

    private void LoseBattery()
    {
        
    }

    private void ToogleFlashlight()
    {
        flashlightIsOn = !flashlightIsOn;

        if ( state == FlashlightState.Dead ) flashlightIsOn = false;
    }
}
