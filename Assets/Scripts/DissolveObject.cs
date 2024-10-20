using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DissolveObject : MonoBehaviour
{
    public bool getDestroyed = false;

    public float dissolveDuration = 2;
    public float dissolveStrength;
    
    public ParticleSystem particles;


    public void StartDissolver()
    {
        StartCoroutine(dissolver());
    }

    public IEnumerator dissolver()
    {
        Destroy(particles);
        float elapsedTime = 0;
        Material dissolveMaterial = GetComponent<Renderer>().material;

        while (elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.deltaTime;

            dissolveStrength = Mathf.Lerp(0, 1, elapsedTime / dissolveDuration);
            dissolveMaterial.SetFloat("_DissolveAmount", dissolveStrength);
                if(elapsedTime >= dissolveDuration)
            {
                Debug.Log("Shadow ball destroyed");
                Destroy(this.gameObject);
            }

            yield return null;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(getDestroyed)
        {
            StartDissolver();
        }
    }
}
