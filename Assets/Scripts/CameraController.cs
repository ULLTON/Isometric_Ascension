using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform pivot;

    public float smoothSpeed = 8f;
    public Vector3 offset;
    public Vector3 pivotOffset;
    private Vector3 desiredRotation;

    // Update is called once per frame

    private void Awake()
    {
        desiredRotation = new Vector3(0, 45, 0);
    }
    void Update()
    {
        if (target == null) return;

        Vector3 desiredPosition = new Vector3(pivot.position.x + pivotOffset.x, target.position.y + offset.y, pivot.position.z + pivotOffset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.localPosition, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.localPosition = smoothedPosition;


        //Quaternion smoothRotation = Vector3.Lerp(Quaternion.Euler(0,45,0), desiredRotation, smoothSpeed * Time.deltaTime);
        pivot.transform.rotation = Quaternion.Lerp(pivot.transform.rotation, Quaternion.Euler(desiredRotation), smoothSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E))
        {
            //pivot.transform.Rotate(0, pivot.transform.rotation.y + 45f, 0);
            desiredRotation = new Vector3(desiredRotation.x, desiredRotation.y - 45f, desiredRotation.z);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //pivot.transform.Rotate(0, pivot.transform.rotation.y + 45f, 0);
            desiredRotation = new Vector3(desiredRotation.x, desiredRotation.y + 45f, desiredRotation.z);
        }
    }
}
