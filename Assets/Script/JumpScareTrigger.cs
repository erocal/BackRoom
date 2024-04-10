using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{

    #region -- 資源參考區 --

    [Header("jumpScare的動畫")]
    [Tooltip("jumpScare的動畫")]
    [SerializeField] Animation jumpScareAnimation;

    [Header("jumpScare的音效")]
    [Tooltip("jumpScare的音效")]
    [SerializeField] AudioSource jumpScareAudio;

    #endregion

    #region -- 初始化/運作 --

    private void Awake()
    {
        jumpScareAudio = GameObject.Find("Smiler SFX")?.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Player" )
        {
            jumpScareAnimation.Play();

            if (jumpScareAudio != null ) jumpScareAudio?.Play();

            this.gameObject.SetActive(false);
        }
    }

    #endregion

}
