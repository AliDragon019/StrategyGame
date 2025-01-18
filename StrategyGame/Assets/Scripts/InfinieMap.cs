using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinieMap : MonoBehaviour
{
    public GameObject camera;
    Vector3 startPosition;
    float repeatWidth ;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = camera.transform.position;
        repeatWidth = gameObject.GetComponent<BoxCollider2D>().size.x /3;
     
    }

    // Update is called once per frame
    void Update()
    {
        if(camera.transform.position.x < startPosition.x - repeatWidth){
            camera.transform.position = startPosition;
        }
        else if (camera.transform.position.x > startPosition.x + repeatWidth){
            camera.transform.position = startPosition;
        }
      
    }
}
