using UnityEngine;

public class DoorManager : MonoBehaviour // This script should be on the Door Trigger
{

    #region --  資源參考區 --

    public GameObject CursorHover; // The hover cursor that should show when the player is looking at the door

    public Animation Door;

    public AudioSource DoorOpenSound;

    #endregion

    #region -- 初始化/運作 --

    private void OnMouseOver() // Activates when the player looks away from the door
    {

        if ( PlayerCasting.DistanceFromTarget < 4 ) // If the player IS close enough to the door..
        {

            CursorHover.SetActive(true);



            if (Input.GetKeyDown(KeyCode.E)) // If the player presses E..
            {

                GetComponent<BoxCollider>().enabled = false; // Turns off the player's ability to open the door again even though it's already open

                Door.Play(); // Play the door open animation

                DoorOpenSound.Play(); // Play the door open sound

            }

        }

        else // If the player is NOT close enough to the door
        {

            CursorHover.SetActive(false);

        }
    }

    private void OnMouseExit() // Activates when the player looks away from the door
    {

        CursorHover.SetActive(false);

    }

    #endregion

}
