using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Update is called once per frame
    public float speed = 1f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A)){
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.D)){
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.W)){
            transform.position += Vector3.up * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.S)){
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
    }
}
