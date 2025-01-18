using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinieMap : MonoBehaviour
{
    public GameObject camera;
    Vector3 startPosition;
    Vector3 rightPosition;
    Vector3 LeftPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = camera.transform.position;
        rightPosition = startPosition + 100 * Vector3.right;
        LeftPosition = startPosition + 100 * Vector3.left;

    }

    // Update is called once per frame
    void Update()
    {
        if(camera.transform.position.x < startPosition.x - 100){
            camera.transform.position = rightPosition;
        }
        else if (camera.transform.position.x > startPosition.x + 100){
            camera.transform.position = LeftPosition ;
        }
      
    }
}
