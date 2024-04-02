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
        this.isPlaying = false;
    }

    public void toggleIsPlaying() {
        this.isPlaying = !isPlaying;
        
        if (!isPlaying) {
            BallPool.instance.PauseBalls();
        } else {
            BallPool.instance.UnpauseBalls();
        }
    }

    public bool getIsPlaying() {
        return this.isPlaying;
    }
}
