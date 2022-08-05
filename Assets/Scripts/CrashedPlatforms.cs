using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrashedPlatforms : MonoBehaviour
{
    public sector sector;

    public Text crashText;

    private void Update()
    {
        crashText.text = "Cradhes platform:" + sector.CrashedPlatform.ToString();
    }
}
