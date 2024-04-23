using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawManager : MonoBehaviour {
    public static DrawManager instance;

    private Camera cam;
    [SerializeField] private Line linePrefab;
 
    public const float RESOLUTION = .1f;
 
    private Line currentLine;

    private Dictionary<string, Line> allLines = new Dictionary<string, Line>();
    private IDataService dataService = new JsonDataService();

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
         cam = Camera.main;   
    }
 
 
    private void Update() {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (!EventSystem.current.IsPointerOverGameObject()) { // Actions don't happen if pointer over UI
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

        if (Input.GetKeyDown(KeyCode.S)) {
            SerializeJson();
        }

        if (Input.GetKeyDown(KeyCode.L)) {
            DeserializeJson();
        }
    }

    public void SerializeJson() {
        // Convert Lines to LineData
        List<LineData> allLineData = new List<LineData>();
        foreach (Line line in allLines.Values) {
            NoteState currLineNoteState = line.getNoteState();
            List<Vector2Data> vector2Data = new List<Vector2Data>();
            foreach (Vector2 point in line.getPoints()) {
                vector2Data.Add(new Vector2Data(point.x, point.y));
            }
            allLineData.Add(new LineData(line.name, currLineNoteState.getNote(), vector2Data));
        }

        // Save as JSON
        dataService.SaveData("/lines.json", allLineData);
    }

    public void DeserializeJson() {
        // Load LineData
        List<LineData> allLineData = dataService.LoadData<List<LineData>>("/lines.json");

        // Convert LineData to Lines
        foreach (LineData lineData in allLineData) {
            Line newline = Instantiate(linePrefab, Vector2.zero, Quaternion.identity);
            newline.name = lineData.name;
            NoteState noteState = new NoteState(lineData.note);
            List<Vector2> points = new List<Vector2>();
            foreach (Vector2Data point in lineData.points) {
                points.Add(point.ToVector2());
            }
            newline.SetUp(noteState, points);
        }
    }

    private void drawLine(Vector2 mousePos) {
        if (Input.GetMouseButtonDown(0)) {
            currentLine = Instantiate(linePrefab, mousePos, Quaternion.identity);
            currentLine.name = Guid.NewGuid().ToString();
        }

        if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0)) {
            currentLine.SetPosition(mousePos);
        }

        if (Input.GetMouseButtonUp(0)) {
            allLines.Add(currentLine.name, currentLine);
        }
    }

    private void eraseStuff(Vector2 mousePos) {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) {
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null) {
                if (hit.collider.gameObject != null) { // TODO: look at refactoring this logic 
                    GameObject clickedObject = hit.collider.gameObject.transform.gameObject;

                    if (IsErasable(clickedObject)) {
                        allLines.Remove(clickedObject.name);
                        Destroy(clickedObject);
                    }
                }
                
            }
        }
    }

    private void cleanupPointLines() {
        if (Input.GetMouseButtonUp(0) && currentLine.getPointsCount() < 2 && currentLine != null) {
            allLines.Remove(currentLine.name);
            Destroy(currentLine.gameObject);
        }
    }

    private bool IsErasable(GameObject obj) {
        return obj.CompareTag("IsErasable");
    }
}