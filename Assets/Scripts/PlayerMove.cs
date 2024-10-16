using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 2.0f;

    private float moveX;
    private float moveZ;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(moveX, 0, moveZ);

    }
}
