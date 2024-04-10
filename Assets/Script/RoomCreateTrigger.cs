using UnityEngine;

public class RoomCreateTrigger : MonoBehaviour
{

    #region -- 變數參考區 --

    RoomCreate roomCreate;

    #endregion

    #region -- 初始化/運作 --

    private void Awake()
    {
        roomCreate = GetComponentInParent<RoomCreate>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!roomCreate.isCreateOnce)
        {
            roomCreate.DestroyPreAirWall();
            roomCreate.DestroyPreRoom(transform.parent.gameObject);
            roomCreate.GeneratePrefabsNineSquareDivision(transform.parent.position);
        }
        
    }

    #endregion

}
