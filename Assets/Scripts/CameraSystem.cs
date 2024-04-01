using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {
    [SerializeField] private Camera cam;

    private Vector3 dragOrigin;

    private void Update() {
        PanCamera();
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
}
