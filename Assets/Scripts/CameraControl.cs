using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    public float sensitivity = 5.0f;
    [SerializeField]
    public float smoothing = 2.0f;
    
    public GameObject playerCharacter;

    private Vector2 mouseLook;
    private Vector2 smoothM; // mouse smoothing

    void Start()
    {
        playerCharacter = this.transform.parent.gameObject;

        // lock cursor
        Cursor.lockState = CursorLockMode.Locked;	
    }

    // Update is called once per frame
    void Update()
    {
        var moveCamera = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        moveCamera = Vector2.Scale(moveCamera, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothM.x = Mathf.Lerp(smoothM.x, moveCamera.x, 1f / smoothing);
        smoothM.y = Mathf.Lerp(smoothM.y, moveCamera.y, 1f / smoothing);
        mouseLook += smoothM;

        // rotate camera object
        if(mouseLook.y >= -70 && mouseLook.y <= 45) // lock the camera view to avoid rotating too much
        {
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        }
        
        playerCharacter.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, playerCharacter.transform.up);
    }
}
