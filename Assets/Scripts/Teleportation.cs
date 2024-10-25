using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject tpPoint;
    public GameObject player;
    public bool tp = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (tp)
        {
            player.transform.position = 
            new Vector3(tpPoint.transform.position.x, tpPoint.transform.position.y, tpPoint.transform.position.z);
            tp = false;
        }
    }
}
