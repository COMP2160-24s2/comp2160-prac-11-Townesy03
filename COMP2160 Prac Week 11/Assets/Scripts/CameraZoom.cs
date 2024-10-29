using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float zoomMax;
    [SerializeField] private float zoomMin;
    private float zoomDirection = 0;
    private float zoom = 0;
    private Actions actions;
    private InputAction zoomAction;

    // Start is called before the first frame update
    void Awake()
    {
        actions = new Actions();
        zoomAction = actions.camera.zoom;
    }

    void OnEnable()
    {
        zoomAction.Enable();
    }
    void OnDisable()
    {
        zoomAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(zoomAction.ReadValue<float>());
        zoomDirection = -zoomAction.ReadValue<float>();

        
        zoom += zoomSpeed * zoomDirection * Time.deltaTime;
        if (zoom > zoomMax) 
        {
            zoom = zoomMax;
        }
        if (zoom < zoomMin)
        {
            zoom = zoomMin;
        }
        if (Camera.main.orthographic)
        {
            Camera.main.orthographicSize = zoom/10;
        }
        else 
        {
            Camera.main.fieldOfView = zoom;
        }


    }
}
