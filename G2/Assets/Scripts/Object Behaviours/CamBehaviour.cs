using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class CamBehaviour : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private float fieldOfViewMax = 100;
    [SerializeField] private float fieldOfViewMin = 10;
    private float targetFieldOfView;
    public float cameraUpperBorderZ;
    public float cameraLowerBorderZ;
    public float cameraLeftBorderX;
    public float cameraRightBorderX;
     
    private void Update()
    {
        
        HandleCameraMovement();
        HandleCameraZoom();

        /*float rotateDir = 0f;
        if (Input.GetKey(KeyCode.Q)) rotateDir = +1f;
        if (Input.GetKey(KeyCode.E)) rotateDir = -1f;
        float rotateSpeed = 100f;

        transform.eulerAngles += new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0);*/ // поворот камеры не актуален пока
    }
    private void HandleCameraMovement() 
    {
        Vector3 inputDir = new Vector3(0, 0, 0);


        if (Input.GetKey(KeyCode.W) && transform.position.z < cameraUpperBorderZ) inputDir.z = +1f;
        if (Input.GetKey(KeyCode.S) && transform.position.z > cameraLowerBorderZ) inputDir.z = -1f;
        if (Input.GetKey(KeyCode.D) && transform.position.x < cameraRightBorderX) inputDir.x = +1f;
        if (Input.GetKey(KeyCode.A) && transform.position.x > cameraLeftBorderX) inputDir.x = -1f;


        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;

        float moveSpeed = 300f;
        transform.position += inputDir * moveSpeed * Time.deltaTime;
    }

     private void HandleCameraZoom() 
     {
         if (Input.mouseScrollDelta.y > 0)
         {
             targetFieldOfView += 5;
         }
         if (Input.mouseScrollDelta.y < 0)
         {
             targetFieldOfView -= 5;
         }

         targetFieldOfView = Mathf.Clamp(targetFieldOfView, fieldOfViewMin, fieldOfViewMax);

         cinemachineVirtualCamera.m_Lens.FieldOfView = targetFieldOfView;
     }

    /*private void HandleCameraZoom_MoveForward()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0, 10, -10);
        }
        
    }*/
}

