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

    [SerializeField] private Texture2D[] cursorTextures;

    public static StateManager instance;

    private BrushState brushState = BrushState.Pencil;
    private NoteState noteState;
    private bool isPlaying = false;
    private float originalFixedDeltaTime;
    
    private void Awake() {
        if (instance == null) {
            instance = this;
        }

        // Setting Default States
        this.brushState = BrushState.Pencil;
        this.noteState = new NoteState(NoteState.Note.none);
        
        // Setting Default Play State
        this.isPlaying = false;
        this.originalFixedDeltaTime = Time.fixedDeltaTime; // Save a reference to the original fixedDeltaTime
        Time.timeScale = 0f;
        Time.fixedDeltaTime = this.originalFixedDeltaTime * Time.timeScale;
    }

    void Update() {
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }

    private void setCursor(BrushState brushState) {
        Vector2 cursorHotspot;
        switch (brushState) {
            case BrushState.Pencil:
                cursorHotspot = new Vector2(0, cursorTextures[0].height);
                Cursor.SetCursor(cursorTextures[0], cursorHotspot, CursorMode.Auto);
                break;
            case BrushState.Eraser:
                cursorHotspot = new Vector2(cursorTextures[1].width/2, cursorTextures[1].height/2);
                Cursor.SetCursor(cursorTextures[1], cursorHotspot, CursorMode.Auto);
                break;
        }
    }

    public void toggleIsPlaying() {
        this.isPlaying = !isPlaying;
        if (!this.isPlaying) { // Pause Game
            CameraSystem.instance.UseFreeCamera();
            Time.timeScale = 0f;
        } else { // Play Game
            Time.timeScale = 1f;
            CameraSystem.instance.UseBallFollowCamera();
        }
        Time.fixedDeltaTime = this.originalFixedDeltaTime * Time.timeScale;
    }

    public void StopPlaying() {
        isPlaying = false;
        CameraSystem.instance.ResetCamera();
        BallController.instance.ResetBallPosition();
        Time.timeScale = 0f;
        Time.fixedDeltaTime = this.originalFixedDeltaTime * Time.timeScale;

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

    public void setNoteState(NoteState noteState) {
        this.noteState = noteState;
    }

    public NoteState getNoteState() {
        return this.noteState;
    }
}
