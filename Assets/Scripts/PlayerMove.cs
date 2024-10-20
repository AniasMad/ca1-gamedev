using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5.0f;

    private float moveX;
    private float moveZ;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10.0f;
        }
        else
        {
            speed = 5.0f;
        }
        moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(moveX, 0, moveZ);

    }
}
