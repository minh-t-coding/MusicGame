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
 
        if (Input.GetMouseButtonDown(0)) currentLine = Instantiate(linePrefab, mousePos, Quaternion.identity);
 
        if(Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0)) currentLine.SetPosition(mousePos);
    }
}