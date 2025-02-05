using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float speed;
    public float speedMultiplier;
    float currentSpeedMultiplier;
    public float Zoom;

    public RectTransform map;

    public Vector2 cameraSize;
    public Vector2 mapSize;

    Camera mainCamera;
    
    private float ZoomTarget;

    [SerializeField]
    private float zoommMultiplier = 2f, minZoom = 1f, maxZoom = 10f, smmothTime = .1f;
    private float velocity = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();

        currentSpeedMultiplier = speedMultiplier;
        zoommMultiplier = mainCamera.orthographicSize;            
    }

    // Update is called once per frame
    void Update()
    {
        cameraSize = new Vector2(mainCamera.orthographicSize * mainCamera.aspect, mainCamera.orthographicSize);
        mapSize = map.sizeDelta;

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
        float rightBorder = mapSize.x/2;
        if(transform.position.x < -rightBorder){
            transform.position = new Vector3(rightBorder, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightBorder){
            transform.position = new Vector3(-rightBorder, transform.position.y, transform.position.z);
        }
        
        float upBorder = mapSize.y/2 - cameraSize.y;
        if(transform.position.y > upBorder){
            transform.position = new Vector3(transform.position.x, +upBorder, transform.position.z);
        } else if(transform.position.y < -upBorder){
            transform.position = new Vector3(transform.position.x, -upBorder, transform.position.z);
        }
        #endregion

        #region Zoom

        ZoomTarget -= Input.GetAxisRaw("Mouse ScrollWheel") * zoommMultiplier;
        ZoomTarget = Mathf.Clamp(ZoomTarget, minZoom, maxZoom);
        mainCamera.orthographicSize = Mathf.SmoothDamp(mainCamera.orthographicSize, ZoomTarget,ref velocity, smmothTime);

        #endregion
    }


}
