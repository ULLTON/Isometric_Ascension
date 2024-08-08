using System.Collections;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    [SerializeField] private GameObject door3;
    [SerializeField] private float doorMoveTime;
    [SerializeField] private bool doorOpen = false;
    [SerializeField] private float doorMoveDistance;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Button Triggered by: " + other.gameObject.name);

        if (other.gameObject.CompareTag("Player"))
        {
            if (doorOpen == true)
            {
                if (door2 != null)
                {
                    CloseDoor(door1);
                    CloseDoor(door2);
                }
                else
                {
                    if (door3 != null)
                    {
                        CloseDoor(door1);
                        CloseDoor(door2);
                        CloseDoor(door3);
                    }
                    else
                    {
                        CloseDoor(door1);
                    }
                }
                doorOpen = false;

                StartCoroutine(wait());
            }
            else
            {
                if (door2 != null)
                {
                    OpenDoor(door1);
                    OpenDoor(door2);
                }
                else
                {
                    if (door3 != null)
                    {
                        OpenDoor(door1);
                        OpenDoor(door2);
                        OpenDoor(door3);
                    }
                    else
                    {
                        OpenDoor(door1);
                    }
                }
                doorOpen = true;

                StartCoroutine(wait());
            }
        }
    }
    private void CloseDoor(GameObject door)
    {
        door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y + doorMoveDistance, door.transform.position.z);
    }

    private void OpenDoor(GameObject door)
    {
        door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y - doorMoveDistance, door.transform.position.z);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
    }
}
