using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float speed;
    public float speedMultiplier;
    float currentSpeedMultiplier; 

    Vector3 startPosition;
    Vector3 rightPosition;
    Vector3 leftPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rightPosition = startPosition + 100 * Vector3.right;
        leftPosition = startPosition + 100 * Vector3.left;

        currentSpeedMultiplier = speedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            currentSpeedMultiplier = speedMultiplier;
        else 
            currentSpeedMultiplier = 1;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ){
            transform.position += speed * Vector3.up * Time.deltaTime * currentSpeedMultiplier;
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ){
            transform.position += speed * Vector3.down * Time.deltaTime * currentSpeedMultiplier;
        }    

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ){
            transform.position += speed * Vector3.right * Time.deltaTime * currentSpeedMultiplier;
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ){
            transform.position += speed * Vector3.left * Time.deltaTime * currentSpeedMultiplier;
        }

        #endregion
        
        #region InfiniteLoop
        if(transform.position.x < startPosition.x - 100){
            transform.position = rightPosition;
        }
        else if (transform.position.x > startPosition.x + 100){
            transform.position = leftPosition ;
        }
        #endregion
    }
}
