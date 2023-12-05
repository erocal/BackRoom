
using UnityEngine;

public class KeyDoor : MonoBehaviour // This script should be on the Locked Door Trigger
{
    [Header("Attributes")]
   
    [Tooltip("The name of the key that is required.")] public string keyName = "";

    [Header("References")]

    [SerializeField] GameObject CursorHover; // The hover cursor that should show when the player is looking at the door

    [SerializeField] Animation Door;

    [Header("門開啟的聲音")]
    [SerializeField] AudioSource DoorOpenSound;

    [Header("門是鎖住的聲音")]
    [SerializeField] AudioSource LockedDoorSound;

    #region -- 參數參考區 --

    private KeyManager km;

    bool isUnlocked = false;

    #endregion

    private void Start()
    {
        km = FindObjectOfType<KeyManager>(); // Assign
    }

    private void OnMouseOver() // Activates when the player looks at the door
    {

        if ( PlayerCasting.DistanceFromTarget <= 4 ) // If the player IS close enough to the door..
        {

            CursorHover.SetActive(true);



            if (Input.GetKeyDown(KeyCode.E)) // If the player presses E..
            {

                for (int i = 0; i <  km.keysInInventory.Count; i++) // Check to see if the player has key
                {
                    var key = km.keysInInventory[i];
                    if (key.Trim().ToLower() == keyName.Trim().ToLower())
                    { 
                        GetComponent<BoxCollider>().enabled = false; // Turns off the player's ability to open the door again even though it's already open

                        Door.Play(); // Play the door open animation

                        DoorOpenSound.Play(); // Play the door open sound

                        km.keysInInventory.Remove(key); // Removes the key from the inventory

                        isUnlocked = true;
                    }
                }

                if ( !isUnlocked ) LockedDoorSound.Play();
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
}
