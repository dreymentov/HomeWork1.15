using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent(out Player player)) return;
        player.Reachfinish();
    }
}
