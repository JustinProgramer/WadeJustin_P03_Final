using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCube : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public float pickupRange = 3;
    public Transform guide;
    public static bool slotFull;
    public bool carrying;
    private void Start()
    {
        if (!carrying)
        {
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Collider>().isTrigger = false;
        }
        if (carrying)
        {
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Collider>().isTrigger = true;
            slotFull = true;
        }
    }
    private void Update()
    {
        Vector3 distanceToPlayer = guide.position - transform.position;

        if (!carrying && distanceToPlayer.magnitude <= pickupRange && Input.GetKey(KeyCode.E) && !slotFull)
        {
            PickBox();
        }
        if (carrying && Input.GetKey(KeyCode.R))
        {
            DropBox();
        }
        else
            return;
    }

    private void PickBox()
    {
        carrying = true;
        slotFull = true;
        item.transform.parent = tempParent.transform;
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.Euler(Vector3.zero);
        item.transform.localScale = Vector3.one;
        FindObjectOfType<AudioManager>().PlaySong("PickUpCube");

        item.GetComponent<Rigidbody>().isKinematic = true;
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Collider>().isTrigger = true;
    }
    private void DropBox()
    {
        carrying = false;
        slotFull = false;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Collider>().isTrigger = false;

        item.transform.SetParent(null);
        item.GetComponent<Rigidbody>().velocity = guide.GetComponent<Rigidbody>().velocity;
        FindObjectOfType<AudioManager>().PlaySong("Box Drop");
    }
}