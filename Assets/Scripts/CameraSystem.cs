using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSystem : MonoBehaviour {
    public static CameraSystem instance;

    [SerializeField] private Camera cam;
    [SerializeField] private List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    [SerializeField] private float minOrthographicSize;
    [SerializeField] private float maxOrthographicSize;

    private Vector3 dragOrigin;
    private float targetOrthographicSize = 6f;
    private Vector3 defaultCameraPosition;
    private CinemachineVirtualCamera ActiveCamera = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }

        this.defaultCameraPosition = this.gameObject.transform.position;
        SwitchCamera(cameras[0]);
        // Cameras[0] == FreeCam
        // Cameras[1] == BallFollowCam 
    }

    private void Update() {
        if (IsActiveCamera(cameras[0])) { // Lets you pan and zoom in freecam
            PanCamera();
            ZoomCamera();
        }

        if (IsActiveCamera(cameras[1])) { // Have CameraSystem follow ball if in BallFollow cam
            if (BallController.instance != null) {
                gameObject.transform.position = BallController.instance.GetBallPosition();
            }
        }

        // if (!isFreeCam && (Input.GetMouseButton(1) || Input.mouseScrollDelta.y != 0)) {
        //     UseFreeCamera(); 
        // }
    }

    public bool IsActiveCamera(CinemachineVirtualCamera camera) {
        return camera == ActiveCamera;
    }

    public void SwitchCamera(CinemachineVirtualCamera camera) {
        camera.Priority = 10;
        ActiveCamera = camera;

        foreach (CinemachineVirtualCamera c in cameras) {
            if (c != camera && c.Priority != 0) {
                c.Priority = 0;
            }
        }
    }

    public void UseFreeCamera() {
        SwitchCamera(cameras[0]);
    }

    public void UseBallFollowCamera() {
        SwitchCamera(cameras[1]);
    }

    public void ResetCamera() {
        gameObject.transform.position = defaultCameraPosition;
        SwitchCamera(cameras[0]);
    }

    private void PanCamera() {
        if (Input.GetMouseButtonDown(1)) {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(1)) {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            gameObject.transform.position += difference;
        }
    }

    private void ZoomCamera() {
        if (Input.mouseScrollDelta.y > 0) {
            targetOrthographicSize -= 2;
        }
        if (Input.mouseScrollDelta.y < 0) {
            targetOrthographicSize += 2;
        }

        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, minOrthographicSize, maxOrthographicSize);

        float zoomSpeed = 5f;
        ActiveCamera.m_Lens.OrthographicSize = Mathf.Lerp(ActiveCamera.m_Lens.OrthographicSize, targetOrthographicSize, Time.unscaledDeltaTime * zoomSpeed);
    }
}
