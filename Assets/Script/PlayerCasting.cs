using UnityEngine;

public class PlayerCasting : MonoBehaviour
{

    #region -- 變數參考區 --

    public static float DistanceFromTarget;
    public float ToTarget;

    #endregion

    #region -- 初始化/運作 --

    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            DistanceFromTarget = Hit.distance;
            ToTarget = Hit.distance;
        }
    }

    #endregion

}
