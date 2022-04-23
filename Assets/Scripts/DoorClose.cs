using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    [SerializeField] GameObject block;
    [SerializeField] GameObject doorR;
    [SerializeField] GameObject doorL;
    [SerializeField] GameObject shute1;
    [SerializeField] GameObject shute2;
    [SerializeField] GameObject shute3;
    [SerializeField] GameObject shute4;
    [SerializeField] float waitDuration = 3;
    [SerializeField] float holdDuration = 1;
    [SerializeField] float dropDuration = 2;
    [SerializeField] float activateDuration = 4;

    Collider colliderToDeactivate = null;

    private void Awake()
    {
        colliderToDeactivate = GetComponent<Collider>();
    }

    void Start()
    {
        Debug.Log("Door Open!");
        doorR.transform.position += new Vector3(-.832f, 0, 0);
        doorL.transform.position += new Vector3(.832f, 0, 0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Hate this");
    }

    void OnTriggerExit(Collider col)
    {
        FindObjectOfType<AudioManager>().PlaySong("Door Close");
        FindObjectOfType<AudioManager>().StopSong("Music");
        Debug.Log("Door Close!");
        doorR.transform.position += new Vector3(.832f, 0, 0);
        doorL.transform.position += new Vector3(-.832f, 0, 0);
        Invoke(nameof(ShuteOpen), waitDuration);
        Invoke(nameof(ShuteClose), holdDuration);
        Invoke(nameof(DropCube), dropDuration);
        Invoke(nameof(BlockReactivate), activateDuration);

        colliderToDeactivate.enabled = false;
    }
    public void ShuteOpen()
    {
        Debug.Log("Shute Open!");
        FindObjectOfType<AudioManager>().PlaySong("Box Drop");
        FindObjectOfType<AudioManager>().PlaySong("Tube Open");

        shute1.transform.position = new Vector3(-2.051f, 3.301952f, -3.78f);
        shute2.transform.position = new Vector3(-2.051f, 3.301952f, -3.78f);
        shute3.transform.position = new Vector3(-2.051f, 3.301952f, -3.78f);
        shute4.transform.position = new Vector3(-2.051f, 3.301952f, -3.78f);
    }
    public void ShuteClose()
    {
        Debug.Log("Shute Close!");
        FindObjectOfType<AudioManager>().PlaySong("Tube Open");
        shute1.transform.position = new Vector3(-1.41f, 3.301952f, -4.353f);
        shute2.transform.position = new Vector3(-1.398f, 3.301952f, -3.199f);
        shute3.transform.position = new Vector3(-2.557f, 3.301952f, -3.055f);
        shute4.transform.position = new Vector3(-2.546f, 3.301952f, -4.496f);
    }
    public void DropCube()
    {
        Debug.Log("Block Deactivated!");
        block.transform.position += new Vector3(0, 0, -333f);

    }
    public void BlockReactivate()
    {
        Debug.Log("Block reacivated!");
        block.transform.position += new Vector3(0, 0, 333f);
    }
}