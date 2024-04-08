using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class DrawManager : MonoBehaviour {
    private Camera cam;
    [SerializeField] private Line linePrefab;
 
    public const float RESOLUTION = .1f;
 
    private Line currentLine;
    void Start()
    {
         cam = Camera.main;   
    }
 
 
    void Update() {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        switch (StateManager.instance.getBrushState()) {
            case StateManager.BrushState.Pencil:
                drawLine(mousePos);
                break;
            case StateManager.BrushState.Eraser:
                eraseStuff(mousePos);
                break;
        }

        cleanupPointLines();
    }

    private void drawLine(Vector2 mousePos) {
        if (Input.GetMouseButtonDown(0)) {
            currentLine = Instantiate(linePrefab, mousePos, Quaternion.identity);
        }
 
        if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0)) {
            currentLine.SetPosition(mousePos);
        }
    }

    private void eraseStuff(Vector2 mousePos) {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) {
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null) {
                if (hit.collider.gameObject != null) { // TODO: look at refactoring this logic 
                    GameObject clickedObject = hit.collider.gameObject.transform.gameObject;

                    if (IsErasable(clickedObject)) {
                        Destroy(clickedObject);
                    }
                }
                
            }
        }
    }

    private void cleanupPointLines() {
        if (Input.GetMouseButtonUp(0) && currentLine.getPointsCount() < 2 && currentLine != null) {
            Destroy(currentLine.gameObject);
        }
    }

    private bool IsErasable(GameObject obj) {
        return obj.CompareTag("IsErasable");
    }
}