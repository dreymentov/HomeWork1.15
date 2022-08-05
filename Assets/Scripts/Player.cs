using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody _rb;

    public Platform currentPlatform;

    public Game Game;

    public Material material;

    private bool IsDie = false;

    public GameObject player;

    private float NumberDie;
    private float NumberDie1;
    public float forNumberDie1;

    public void Start()
    {
        IsDie = false;
        NumberDie = 50;
        NumberDie1 = 1;
}

    public void Bounce()
    {
        _rb.velocity = Vector3.up * BounceSpeed;
    }

    public void Die()
    {
        Game.OnPlayerDied();
        IsDie = true;
        _rb.velocity = Vector3.zero;
    }

    public void Reachfinish()
    {
        Game.OnPlayerReachfinish();
        _rb.velocity = Vector3.zero;
    }

    private void Update()
    {
        if (IsDie)
        {
            //player.GetComponent<Renderer>().material.SetColor("Color_695167f5851f405f9cf8fa25754fa9b7", Color.red); Charge first color
            //player.GetComponent<Renderer>().material.SetColor("Color_387916ca158a4e92a5c80222f0700f47", Color.green); Charge second color
            
            NumberDie += 50f * Time.deltaTime;
            NumberDie1 -= forNumberDie1 * Time.deltaTime;

            player.GetComponent<Renderer>().material.SetFloat("Vector1_2b1bbd54cd2a41a8a6cff93a31b1f5ba", NumberDie);
            player.GetComponent<Renderer>().material.SetFloat("Vector1_f9c4e547d56b40bfb709572bd5f9bbf1", NumberDie1);
        }
    }

    /*
     Shader "Shader Graphs/1) New Shader Graph 2 (Dissolution)" 
    Color_695167f5851f405f9cf8fa25754fa9b7("Color", Color) = (1.000000,0.000000,0.000000,0.000000)
    Color_387916ca158a4e92a5c80222f0700f47("Color (1)", Color) = (0.000000,0.000000,0.000000,0.000000)
    Vector1_2b1bbd54cd2a41a8a6cff93a31b1f5ba("Slider Simple Noise", Range(0.000000,1000.000000)) = 50.000000  How i get the name for scripting? Reference from Shader editor! Level up!
    Vector1_f9c4e547d56b40bfb709572bd5f9bbf1("Slider Step Noise", Range(0.000000,1.000000)) = 1.000000
    Vector1_6d89da454dd6437ba3da142141083505("Edge", Range(0.000000,1.000000)) = 0.000000
    Vector1_07928ebc825e4aa7a5f6adaf90974cea("Edge (1)", Range(0.000000,1.000000)) = 0.500000
    */
}
