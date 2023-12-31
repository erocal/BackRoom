﻿using System.Collections.Generic;
using UnityEngine;

public class RoomCreate : MonoBehaviour
{
    [Header("生成的Prefab陣列")]
    [SerializeField] GameObject[] prefabs;
    [Header("Prefab之間的間隔")]
    [SerializeField] float spacing = 8f;
    [Header("生成的九宮格大小")]
    [Tooltip("生成的九宮格大小")]
    [SerializeField] int arraySize = 3;
    [Header("生成Prefab隨機選擇角度")]
    [Tooltip("生成Prefab隨機選擇角度")]
    [SerializeField] bool isRandomAngle = false;
    [Header("是否只進行一次生成")]
    [Tooltip("是否只進行一次生成")]
    public bool isCreateOnce = false;


    #region -- 參數參考區 --

    private Dictionary<int, GameObject>[,] roomDictionary;
    private Dictionary<int, GameObject> preRoomDictionary = new Dictionary<int, GameObject>();

    #endregion

    void Awake()
    {
        if (isCreateOnce) GeneratePrefabsNineSquareDivision(Vector3.zero);
    }

    /// <summary>
    /// 在二階矩陣生成Prefab( 暫時廢棄 )
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
                // 隨機選擇一個Prefab
                GameObject selectedPrefab = prefabs[Random.Range(0, prefabs.Length)];

                float OffsetX = (i * spacing) - centerOffsetX;
                float OffsetZ = (j * spacing) - centerOffsetZ;

                Vector3 spawnPosition = new Vector3(OffsetX, 0f, OffsetZ);

                // 生成Prefab
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
        // 中位數
        int medianNumber = arraySize / 2;

        for (int i = 0; i < arraySize; i++)
        {
            for (int j = 0; j < arraySize; j++)
            {
                // 隨機選擇一個Prefab
                GameObject selectedPrefab = prefabs[Random.Range(0, prefabs.Length)];

                float offsetX = (medianNumber - i) * spacing;
                float offsetZ = (medianNumber - j) * spacing;

                Vector3 spawnPosition = new Vector3(centerPosition.x + offsetX, 0f, centerPosition.z + offsetZ);

                // 生成Prefab
                if (spawnPosition.x != centerPosition.x || spawnPosition.z != centerPosition.z)
                {
                    Quaternion rotation = Quaternion.identity;

                    if (isRandomAngle)
                    {
                        int randomAngle = Random.Range(1, 5) * 90;  // 選擇 1 到 4 之間的整數，乘以 90 得到 90、180、270 或 360
                        Quaternion randomRotation = Quaternion.Euler(0, randomAngle, 0);
                        rotation = randomRotation;
                    }
                    
                    Instantiate(selectedPrefab, spawnPosition, rotation, transform);
                }
                    
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
