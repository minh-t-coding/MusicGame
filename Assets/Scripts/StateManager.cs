using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {
    // Define an enum for Brush states
    public enum BrushState {
        Pencil,
        Line,
        Eraser,
        Paint
    }

    public enum NoteState {
        cNote,
        dNote,
        eNote,
        fNote,
        gNote,
        aNote,
        bNote,
        noNote
    }

    public static StateManager instance;

    private BrushState brushState = BrushState.Pencil;
    private NoteState noteState = NoteState.noNote;
    private bool isPlaying = false;
    
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        this.brushState = BrushState.Pencil;
        this.noteState = NoteState.noNote;
        this.isPlaying = true;

        Time.timeScale = 1f;
    }

    public void toggleIsPlaying() {
        this.isPlaying = !isPlaying;
        if (isPlaying) {
            Time.timeScale = 1f;
        }
    }

    private void FixedUpdate() {    
        if (!isPlaying) {
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
    }

    public bool getIsPlaying() {
        return this.isPlaying;
    }
}
