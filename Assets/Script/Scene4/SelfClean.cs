using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfClean : MonoBehaviour
{
    public GameObject restroom;
    public Collider triggerCollider;
    public Collider talk;
    public List<AudioSource> Clean; // List of AudioSources
    //public Camera camera1;
    //public Camera MainCamera;
    bool inReach;
    public Animator door; // Animator controlling the door
    private bool isDoorOpen; // Track if the door is open

    // Start is called before the first frame update
    void Start()
    {
        //camera1.enabled = false;
        isDoorOpen = door.GetBool("Open"); // Initialize the door state based on Animator's "Open" parameter
    }

    // Trigger detection for when the player enters the "Reach" zone
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Reach"))
        {
            Debug.Log("In Reach");
            inReach = true; // Mark the player as within reach
        }
    }

    // Trigger detection for when the player exits the "Reach" zone
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Reach"))
        {
            inReach = false; // Mark the player as out of reach
        }
    }

    void Update()
    {
        // If the player is in reach and presses the "Click" button
        if (inReach && Input.GetButtonDown("Click"))
        {
            if (inReach && Input.GetButtonDown("Click"))
            {
                DoorOpens();
                restroom.SetActive(true);
            }
            //MainCamera.enabled = false;
            //camera1.enabled = true;

            StartCoroutine(PlaySoundsWithDelay()); // Call the coroutine to play sounds with delay
        }
    }

    // Coroutine to play sounds one after the other with a delay
    IEnumerator PlaySoundsWithDelay()
    {
        foreach (AudioSource audio in Clean)
        {
            audio.Play(); // Play the current AudioSource
            yield return new WaitForSeconds(audio.clip.length); // Wait for the audio clip's length before moving to the next one        
            //DoorCloses();
            DoorOpens();
            talk.enabled = true;


        }
    }
    void DoorOpens()
    {
        Debug.Log("It's Opens");
        door.SetBool("Open", true);
        door.SetBool("Close", false);
    }
    // Method to handle closing the door
    void DoorCloses()
    {
        Debug.Log("Door is closing");
        door.SetBool("Open", false); // Set the "Open" state to false
        door.SetBool("Close", true); // Trigger the "Close" animation
        isDoorOpen = false; // Update the door state
    }
}
