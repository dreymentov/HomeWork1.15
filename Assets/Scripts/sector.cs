using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sector : MonoBehaviour
{

    public bool IsGood = true;

    public Material GoodMaterial;
    public Material BadMaterial;
    public Material GoodMaterialLastHit;
    public Material GoodMaterialLastHit1;

    public int HowManyForCrashPlatform = 2;

    public Text CrashedText;

    private void Awake()
    {
        GetComponent<Renderer>().sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }

    private void Update()
    {
        if(HowManyForCrashPlatform == 1)
        {
            GetComponent<Renderer>().sharedMaterial = GoodMaterialLastHit;
        }

        if(HowManyForCrashPlatform == 0)
        {
            GetComponent<Renderer>().sharedMaterial = GoodMaterialLastHit1;
        }

        if (HowManyForCrashPlatform < 0)
        {
            CrashedPlatform++;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Player player))
        {
            Vector3 normal = -collision.contacts[0].normal.normalized;
            float dot = Vector3.Dot(normal, Vector3.up);

            if(dot >= 0.5)
            {
                if (IsGood == true)
                {
                    player.Bounce();
                }
                    
                else
                    player.Die();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            if (IsGood == true)
            {
                HowManyForCrashPlatform--;
            }
        }
    }

    private const string CrashedPlatformKey = "CrashedPlatform";

    public int CrashedPlatform
    {
        get => PlayerPrefs.GetInt(CrashedPlatformKey, 0);
        private set
        {
            PlayerPrefs.SetInt(CrashedPlatformKey, value);
            PlayerPrefs.Save();
        }
    }


}
