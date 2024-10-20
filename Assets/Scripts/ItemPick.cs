using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPick : MonoBehaviour
{
    public float maxDistance = 15;
    public LayerMask layersToHit;
    public TextMeshProUGUI textElement;

    void Update()
    {
        textElement.text = "";
        Ray ray;
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if(Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance, layersToHit))
        {
            if (hitInfo.collider.gameObject.tag == "ShadowBall" && hitInfo.distance < 7)
            {
                textElement.text = "Press E to Pick Up";
                if(Input.GetKeyDown("e"))
                {
                    this.GetComponent<OrbCount>().orbCount += 1;
                    hitInfo.collider.gameObject.GetComponent<DissolveOrb>().getDestroyed = true;
                }
                
            }
            if ((hitInfo.collider.gameObject.tag == "RemovableRock" && hitInfo.distance < 7) && this.GetComponent<OrbCount>().orbCount >= 1)
            {
                textElement.text = "Press E to Destroy";
                if(Input.GetKeyDown("e"))
                {
                    this.GetComponent<OrbCount>().orbCount -= 1;
                    hitInfo.collider.gameObject.GetComponent<DissolveRock>().getDestroyed = true;
                }
            }
            if ((hitInfo.collider.gameObject.tag == "TPPlatform" && hitInfo.distance < 15) && this.GetComponent<OrbCount>().orbCount >= 1)
            {
                textElement.text = "Press E to Teleport";
                if(Input.GetKeyDown("e"))
                {
                    this.GetComponent<OrbCount>().orbCount -= 1;
                    hitInfo.collider.gameObject.GetComponent<Teleportation>().tp = true;
                }
            }
        }
    }
}

