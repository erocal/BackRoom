using UnityEngine;

public class RoomCreateTrigger : MonoBehaviour
{
    RoomCreate roomCreate;

    private void Awake()
    {
        roomCreate = GetComponentInParent<RoomCreate>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!roomCreate.isCreateOnce)
        {
            roomCreate.DestroyPreRoom(transform.parent.gameObject);
            roomCreate.GeneratePrefabsNineSquareDivision(transform.parent.position);
        }
        
    }
}
