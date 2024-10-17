using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrbCount : MonoBehaviour
{
    public int orbCount = 0;
    public TextMeshProUGUI textCount;

    void FixedUpdate()
    {
        textCount.text = "Shadow Orbs: " + orbCount;
    }
}
