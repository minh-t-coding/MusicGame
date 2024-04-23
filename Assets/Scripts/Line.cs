using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private EdgeCollider2D edgeCollider;

    private NoteState noteState;
    private readonly List<Vector2> points = new List<Vector2>();

    // Start is called before the first frame update
    void Awake() {
        edgeCollider.transform.position = Vector3.zero;
        this.noteState = StateManager.instance.getNoteState();

        lineRenderer.startColor = noteState.getColor();
        lineRenderer.endColor = noteState.getColor();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            AudioManager.instance.playNote(noteState.getNote());
        }
    }

    // Used to construct/initialize a line of given properties, to be called after Instantiate
    public void SetUp(NoteState newNoteState, List<Vector2> points) {
        this.noteState = newNoteState;
   
        lineRenderer.startColor = noteState.getColor();
        lineRenderer.endColor = noteState.getColor();

        foreach (Vector2 point in points) {
            this.points.Add(point);

            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount-1, point);
        }
        edgeCollider.points = points.ToArray();
    }

    public override string ToString() {
        string pointsString = "POINTS: [";
        for (int i = 0; i < points.Count; i++) {
            pointsString += $"({points[i].x}, {points[i].y})";
            if (i < points.Count - 1) {
                pointsString += ", ";
            }
        }
        pointsString += "]";
        return $"NOTESTATE: {noteState.ToString()}\n{pointsString}\nPOSITION: {this.gameObject.transform.position}";
    }


    public void SetPosition(Vector2 pos) {
        if(!CanAppend(pos)) return;
 
        points.Add(pos);

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1,pos);

        edgeCollider.points = points.ToArray();
    }

    private bool CanAppend(Vector2 pos) {
        if (lineRenderer.positionCount == 0) return true;
 
        return Vector2.Distance(lineRenderer.GetPosition(lineRenderer.positionCount - 1), pos) > DrawManager.RESOLUTION;
    }

    public List<Vector2> getPoints() {
        return this.points;
    }

    public NoteState getNoteState() {
        return this.noteState;
    }

    public int getPointsCount() {
        return points.Count;
    }
}
