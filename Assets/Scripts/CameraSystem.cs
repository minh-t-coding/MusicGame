using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSystem : MonoBehaviour {
    [SerializeField] private Camera cam;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private float minOrthographicSize;
    [SerializeField] private float maxOrthographicSize;

    private Vector3 dragOrigin;
    private float targetOrthographicSize = 6f;

    private void Update() {
        PanCamera();
        ZoomCamera();
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
        cinemachineVirtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(cinemachineVirtualCamera.m_Lens.OrthographicSize, targetOrthographicSize, Time.unscaledDeltaTime * zoomSpeed);
    }
}
