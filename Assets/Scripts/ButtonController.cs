using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.AI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Door[] doors;
    private bool canUseButton = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Button Triggered by: " + other.gameObject.name);
        if (!canUseButton) return;

        if (other.gameObject.CompareTag("Player"))
        {
            foreach (Door door in doors)
            {
                door.ActivateDoor();
            }

            NavMeshBuilder.ClearAllNavMeshes();
            NavMeshBuilder.BuildNavMesh();
            StartCoroutine(wait());
        }
    }
    
    IEnumerator wait()
    {
        canUseButton = false;
        yield return new WaitForSeconds(2);
        canUseButton = true;
    }
}
