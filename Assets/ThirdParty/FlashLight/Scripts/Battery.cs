using UnityEngine;

public class Battery : MonoBehaviour
{
    [Header("電池的電量")]
    [Tooltip("電池的電量")]
    [SerializeField] int batteryPower;

    [Header("收集電池的按鈕")]
    [Tooltip("收集電池的按鈕")]
    [SerializeField] KeyCode CollectKey = KeyCode.E;

    [Header("電池邊緣顯示")]
    [Tooltip("電池邊緣顯示")]
    [SerializeField] GameObject[] HoverObject;

    public void OnMouseOver()
    {
        if (Input.GetKeyDown(CollectKey))
        {
            FindObjectOfType<FlashlightManager>()?.GainBattery( batteryPower );

            Destroy( this.gameObject );
        }
    }

    public void OnMouseExit()
    {
        foreach (var obj in HoverObject)
        {
            obj.SetActive(false);
        }
    }
}
