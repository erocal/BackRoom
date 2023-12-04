using System.Collections.Generic;
using UnityEngine;

public class RoomCreate : MonoBehaviour
{
    [Header("�ͦ���Prefab�}�C")]
    [SerializeField] GameObject[] prefabs;
    [Header("Prefab���������j")]
    [SerializeField] float spacing = 8f;
    [Header("�ͦ�Prefab���E�c��j�p")]
    [SerializeField] int arraySize = 3;

    private Dictionary<int, GameObject>[,] roomDictionary;
    private Dictionary<int, GameObject> preRoomDictionary = new Dictionary<int, GameObject>();

    void Awake()
    {
        
    }

    /// <summary>
    /// �b�G���x�}�ͦ�Prefab( �Ȯɼo�� )
    /// </summary>
    void GeneratePrefabsWithArray()
    {

        int roomId = 1;
        roomDictionary = new Dictionary<int, GameObject>[arraySize, arraySize];

        float centerOffsetX = (arraySize - 1) * spacing * 0.5f;
        float centerOffsetZ = (arraySize - 1) * spacing * 0.5f;

        for (int i = 0; i < arraySize; i++)
        {
            for (int j = 0; j < arraySize; j++)
            {
                // �H����ܤ@��Prefab
                GameObject selectedPrefab = prefabs[Random.Range(0, prefabs.Length)];

                float OffsetX = (i * spacing) - centerOffsetX;
                float OffsetZ = (j * spacing) - centerOffsetZ;

                Vector3 spawnPosition = new Vector3(OffsetX, 0f, OffsetZ);

                // �ͦ�Prefab
                Instantiate(selectedPrefab, spawnPosition, Quaternion.identity, transform);
                roomDictionary[i, j] = new Dictionary<int, GameObject>
                {
                    { roomId, selectedPrefab }
                };

                roomId++;
            }
        }
    }

    public void GeneratePrefabsNineSquareDivision(Vector3 centerPosition = new Vector3())
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                // �H����ܤ@��Prefab
                GameObject selectedPrefab = prefabs[Random.Range(0, prefabs.Length)];

                float offsetX = (i - 1) * spacing;
                float offsetZ = (j - 1) * spacing;

                Vector3 spawnPosition = new Vector3(centerPosition.x + offsetX, 0f, centerPosition.z + offsetZ);

                // �ͦ�Prefab
                if (spawnPosition.x != centerPosition.x || spawnPosition.z != centerPosition.z)
                    Instantiate(selectedPrefab, spawnPosition, Quaternion.identity, transform);

            }
        }
        AddPreRoomDictionary();
    }

    private void AddPreRoomDictionary()
    {
        int roomId = 1;
        preRoomDictionary.Clear();

        foreach (Transform room in transform)
        {
            preRoomDictionary.Add(roomId, room.gameObject);

            roomId++;
        }
    }

    public void DestroyPreRoom(GameObject centerRoom)
    {
        foreach (KeyValuePair<int, GameObject> room in preRoomDictionary)
        {
            if (centerRoom != room.Value) Destroy(room.Value);
        }
    }
}
