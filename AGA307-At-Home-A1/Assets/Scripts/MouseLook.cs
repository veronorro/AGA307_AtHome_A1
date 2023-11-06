using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //allows control of mouse speed
    public float mouseSensitivity = 100f;

    //ref for player body. Allows for rotation of whole object (following cam).
    public Transform playerBody;

    float xRotation = 0f;


    void Start()
    {
        //Hide and Lock cursor to centre screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //* by Time.deltaTime allows for rotation to be independent to current frame rate.
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Clamps rotation so player can't over rotate camera.

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        //The specified axis we want player body to rotate on. Allows the rotation.
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
