using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private EdgeCollider2D edgeCollider;

    private NoteState noteState;

    [SerializeField] private String noteType; // TODO: REMOVE LATER
    [SerializeField] private Color color;  // TODO: REMOVE LATER

    private readonly List<Vector2> points = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        edgeCollider.transform.position = Vector3.zero;
        this.noteState = StateManager.instance.getNoteState();
        

        if (noteType != "" && color != null) {  // TODO: REMOVE LATER
            NoteState.Note note = NoteState.Note.none;
            switch (noteType) {
                case "Snare":
                    note = NoteState.Note.snare;
                    break;
                case "Hat":
                    note = NoteState.Note.hat;
                    break;
                case "Kick":
                    note = NoteState.Note.kick;
                    break;
                case "Clap":
                    note = NoteState.Note.clap;
                    break;
            }
            this.noteState = new NoteState(note);
        }

        lineRenderer.startColor = noteState.getColor();
        lineRenderer.endColor = noteState.getColor();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            AudioManager.instance.playNote(noteState.getNote());
        }
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

    public int getPointsCount() {
        return points.Count;
    }
}
