using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] bool isOpen = false;
    [SerializeField] private float doorMoveX;
    [SerializeField] private float doorMoveY;
    [SerializeField] private float doorMoveZ;

    public void ActivateDoor()
    {
        if (!isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        transform.position = new Vector3(transform.position.x - doorMoveX, transform.position.y - doorMoveY, transform.position.z - doorMoveZ);
        isOpen = true;
    }
    private void CloseDoor()
    {
        transform.position = new Vector3(transform.position.x + doorMoveX, transform.position.y + doorMoveY, transform.position.z + doorMoveZ);
        isOpen = false;
    }
}
