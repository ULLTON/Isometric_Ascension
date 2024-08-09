using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.AI;

public class ButtonController : MonoBehaviour
{

    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    [SerializeField] private GameObject door3;
    [SerializeField] private bool door1Open = false;
    [SerializeField] private bool door2Open = false;
    [SerializeField] private bool door3Open = false;
    [SerializeField] private float doorMoveX;
    [SerializeField] private float doorMoveY;
    [SerializeField] private float doorMoveZ;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Button Triggered by: " + other.gameObject.name);

        if (other.gameObject.CompareTag("Player"))
        {
            if (door1Open == true && door1 != null)
            {
                CloseDoor(door1);
                door1Open = false;
            }
            if (door1Open == false && door1 != null)
            {
                OpenDoor(door1);
                door1Open = true;
            }
            if (door2Open == true && door2 != null)
            {
                CloseDoor(door2);
                door2Open = false;
            }
            if (door2Open == false && door2 != null)
            {
                OpenDoor(door2);
                door2Open = true;
            }
            if (door3Open == true && door3 != null)
            {
                CloseDoor(door3);
                door3Open = false;
            }
            if (door3Open == false && door3 != null)
            {
                OpenDoor(door3);
                door3Open = true;
            }
            NavMeshBuilder.ClearAllNavMeshes();
            NavMeshBuilder.BuildNavMesh();
            StartCoroutine(wait());
        }
    }
    private void OpenDoor(GameObject door)
    {
        door.transform.position = new Vector3(door.transform.position.x - doorMoveX, door.transform.position.y - doorMoveY, door.transform.position.z - doorMoveZ);
    }
    private void CloseDoor(GameObject door)
    {
        door.transform.position = new Vector3(door.transform.position.x + doorMoveX, door.transform.position.y + doorMoveY, door.transform.position.z + doorMoveZ);
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
    }
}
