using UnityEngine;
public class NoteState {
    public enum Note {
        hat,
        kick,
        snare,
        clap,
        none
    }

    private Note note;
    private Color32 color;


    public NoteState(Note note) {
        this.note = note;
        this.color = NoteColorLookupTable.GetValue(note);
    }

    public Color32 getColor() {
        return this.color;
    }

    public Note getNote() {
        return this.note;
    }

    public override string ToString() {
        return $"Note: {note}, Color: {color}";
    }

}