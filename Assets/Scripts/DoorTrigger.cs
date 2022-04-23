using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject doorR;
    [SerializeField] GameObject doorL;
    [SerializeField] float openDuration = 5;
    [SerializeField] GameObject blueSign;
    [SerializeField] GameObject orangeSign;
    [SerializeField] GameObject blueLine;
    [SerializeField] GameObject orangeLine;
    //Collider colliderToDeactivate = null;
    bool isOpened = false;

    private void Start()
    {
        blueSign.SetActive(true);
        orangeSign.SetActive(false);
        blueLine.SetActive(true);
        orangeLine.SetActive(false);
    }
    void OnTriggerEnter(Collider col)
    {
        FindObjectOfType<AudioManager>().PlaySong("Buzz");

        if (isOpened == false)
        {
            isOpened = true;
            FindObjectOfType<AudioManager>().StopSong("Door Close");
            Debug.Log("Open Open!");
            doorR.transform.position += new Vector3(0, 0, .832f);
            doorL.transform.position += new Vector3(0, 0, -.832f);
            blueSign.SetActive(false);
            orangeSign.SetActive(true);
            blueLine.SetActive(false);
            orangeLine.SetActive(true);

            if (col.CompareTag("Cube"))
            {
                FindObjectOfType<AudioManager>().PlaySong("Robot Voice");
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        Debug.Log("Door Close!");
        doorR.transform.position += new Vector3(0, 0, -.832f);
        doorL.transform.position += new Vector3(0, 0, .832f);
        FindObjectOfType<AudioManager>().PlaySong("Door Close");
        isOpened = false;
        blueSign.SetActive(true);
        orangeSign.SetActive(false);
        blueLine.SetActive(true);
        orangeLine.SetActive(false);
    }
}