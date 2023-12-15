using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevel : MonoBehaviour
{
    [SerializeField] GameObject SaveGameUI; // "�۰��x�s :) ......"

    [Range(1, 30)]
    [SerializeField] float timeBetweenSaves; // �۰��x�s���ɶ����j

    private void Awake()
    {
        InvokeRepeating(nameof(SaveGame), timeBetweenSaves, timeBetweenSaves); // �b�۰��x�s���ɶ����j���_�I�sSaveGame()
    }

    private void SaveGame()
    {
        SaveGameUI.SetActive(true);

        // �x�s�ثe��Level�ѤU�����J�C��
        PlayerPrefs.SetString("loaded level", SceneManager.GetActiveScene().name);

        PlayerPrefs.Save();

        Invoke(nameof(HideUI), 3);
    }

    private void HideUI()
    {
        SaveGameUI.SetActive(false);
    }
}
