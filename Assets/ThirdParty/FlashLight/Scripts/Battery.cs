using UnityEngine;

public class Battery : MonoBehaviour
{
    [Header("�q�����q�q")]
    [Tooltip("�q�����q�q")]
    [SerializeField] int batteryPower;

    [Header("�����q�������s")]
    [Tooltip("�����q�������s")]
    [SerializeField] KeyCode CollectKey = KeyCode.E;

    [Header("�q����t���")]
    [Tooltip("�q����t���")]
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
