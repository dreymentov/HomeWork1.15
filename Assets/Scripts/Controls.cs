using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Transform level;
    public float sensitivity;

    private Vector3 _perviousMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _perviousMousePosition;
            level.Rotate(0, -delta.x * Time.deltaTime * sensitivity, 0);
        }

        _perviousMousePosition = Input.mousePosition;
    }
}
