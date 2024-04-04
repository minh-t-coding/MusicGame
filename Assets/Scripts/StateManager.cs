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

    [SerializeField] private Texture2D[] cursorTextures;

    public static StateManager instance;

    private BrushState brushState = BrushState.Pencil;
    private NoteState noteState = NoteState.noNote;
    private bool isPlaying = false;
    private float fixedDeltaTime;
    
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        this.brushState = BrushState.Pencil;
        this.noteState = NoteState.noNote;
        this.isPlaying = true;

        Time.timeScale = 1f;
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    private void setCursor(BrushState brushState) {
        Vector2 cursorHotspot;
        switch (brushState) {
            case BrushState.Pencil:
                cursorHotspot = new Vector2(cursorTextures[0].width / 2, cursorTextures[0].height / 2);
                Cursor.SetCursor(cursorTextures[0], cursorHotspot, CursorMode.Auto);
                break;
            case BrushState.Eraser:
                cursorHotspot = new Vector2(cursorTextures[1].width / 2, cursorTextures[1].height / 2);
                Cursor.SetCursor(cursorTextures[1], cursorHotspot, CursorMode.Auto);
                break;
        }
    }

    public void toggleIsPlaying() {
        this.isPlaying = !isPlaying;
        if (Time.timeScale.Equals(1f)) {
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }

    public bool getIsPlaying() {
        return this.isPlaying;
    }

    public void setBrushState(BrushState brushState) {
        this.brushState = brushState;
        setCursor(brushState);
    }

    public BrushState getBrushState() {
        return this.brushState;
    }
}
