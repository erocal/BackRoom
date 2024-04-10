using System.Collections.Generic;
using UnityEngine;

public class RoomCreate : MonoBehaviour
{

    #region -- 資源參考區 --

    [Header("生成的房間Prefab陣列")]
    [SerializeField] GameObject[] prefabs;
    [Header("空氣牆")]
    [Tooltip("生成橫的空氣牆Prefab")]
    [SerializeField] GameObject airWallHorizontalPrefab;
    [Tooltip("生成直的空氣牆Prefab")]
    [SerializeField] GameObject airWallVerticalPrefab;
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

    #endregion

    #region -- 參數參考區 --

    private List<GameObject> airWallList = new List<GameObject>();

    private Dictionary<int, GameObject>[,] roomDictionary;
    private Dictionary<int, GameObject> preRoomDictionary = new Dictionary<int, GameObject>();

    #endregion

    #region -- 初始化/運作 --

    void Awake()
    {
        if (isCreateOnce) GeneratePrefabsNineSquareDivision(Vector3.zero);
    }

    #endregion

    #region -- 方法參考區 --

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

    /// <summary>
    /// 以九宮格式的方法創建Prefab
    /// </summary>
    /// <param name="centerPosition"></param>
    public void GeneratePrefabsNineSquareDivision(Vector3 centerPosition)
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

                Vector3 spawnPosition = new Vector3(centerPosition.x + offsetX, centerPosition.y, centerPosition.z + offsetZ);

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

                    GameObject airWallPrefab = CreateAirWall(spawnPosition, i, j);
                    if (airWallPrefab != null) airWallList.Add(airWallPrefab);

                }

            }
        }

        AddPreRoomDictionary();
    }

    /// <summary>
    /// 創建空氣牆
    /// </summary>
    private GameObject CreateAirWall(Vector3 spawnPosition, int rows, int colums)
    {
        if (rows == 0 && colums == arraySize / 2)
        {
            return Instantiate(airWallVerticalPrefab, new Vector3(spawnPosition.x + 3 * spacing / 4, spawnPosition.y, spawnPosition.z), Quaternion.identity, transform);
        }
        else if (colums == 0 && rows == arraySize / 2)
        {
            return Instantiate(airWallHorizontalPrefab, new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z + 3 * spacing / 4), Quaternion.identity, transform);
        }
        else if (colums == arraySize - 1 && rows == arraySize / 2)
        {
            return Instantiate(airWallHorizontalPrefab, new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z - spacing / 4), Quaternion.identity, transform);
        }
        else if (colums == arraySize / 2 && rows == arraySize - 1)
        {
            return Instantiate(airWallVerticalPrefab, new Vector3(spawnPosition.x - spacing / 4, spawnPosition.y, spawnPosition.z), Quaternion.identity, transform);
        }

        return null;
    }

    /// <summary>
    /// 將當前創建的房間置入preRoomDictionary
    /// </summary>
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

    /// <summary>
    /// 消滅之前創造的空氣牆
    /// </summary>
    public void DestroyPreAirWall()
    {
        foreach (GameObject airWallPrefab in airWallList)
        {
            Destroy(airWallPrefab);
        }
    }

    /// <summary>
    /// 消滅之前創造的房間
    /// </summary>
    public void DestroyPreRoom(GameObject centerRoom)
    {
        foreach (KeyValuePair<int, GameObject> room in preRoomDictionary)
        {
            if (centerRoom != room.Value) Destroy(room.Value);
        }
    }

    #endregion

}
