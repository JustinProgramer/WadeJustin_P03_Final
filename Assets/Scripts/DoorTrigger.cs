using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] float openDuration = 3;
    Collider colliderToDeactivate = null;
    bool isOpened = false;

    private void Awake()
    {
        colliderToDeactivate = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (isOpened == false)
        {
            StartCoroutine(DoorOpen());
        }
    }
    IEnumerator DoorOpen()
    {
        // set boolean for detecting lockout
        isOpened = true;

        ActivateDoor();
        // simulate this object being disabled. We don't really want to disable it
        // because we still need script behavior to continue functioning
        DisableObject();

        // wait for the required duration
        yield return new WaitForSeconds(openDuration);
        //reset
        DeactivateDoor();
        EnableObject();

        // set boolean to release lockout
        isOpened = false;
    }
    void ActivateDoor()
    {
        // open door
        Debug.Log("Open Door!");
        door.transform.position += new Vector3(0, 2.4f, 0);
    }
    void DeactivateDoor()
    {
        // close door
        Debug.Log("Door Close!");
        door.transform.position += new Vector3(0, -2.4f, 0);
    }
    void DisableObject()
    {
        // disable collider, so it can't be retriggered
        colliderToDeactivate.enabled = false;
        // disable visuals, to simulate deactivated
    }
    void EnableObject()
    {
        // enable collider, so it can be retriggered
        colliderToDeactivate.enabled = true;
        // enable visuals again, to draw player attention
    }
}
