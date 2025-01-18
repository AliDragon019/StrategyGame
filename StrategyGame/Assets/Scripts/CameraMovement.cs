using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float speed = 1f;    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ){
            transform.position += speed * Vector3.up * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ){
            transform.position += speed * Vector3.down * Time.deltaTime;
        }    

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ){
            transform.position += speed * Vector3.right * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ){
            transform.position += speed * Vector3.left * Time.deltaTime;
        }
            
    }
}
