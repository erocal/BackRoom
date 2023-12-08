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
        roomCreate.DestroyPreRoom(transform.parent.gameObject);
        roomCreate.GeneratePrefabsNineSquareDivision(transform.parent.position);
        Debug.Log($"{other} is enter");
    }
}
