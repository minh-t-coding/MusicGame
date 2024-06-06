using UnityEngine;
using UnityEngine.UI;

public class ColorSelectButtons : MonoBehaviour {
    [SerializeField] private Button[] buttons;
    [SerializeField] private Image currentColor;

    void Start() {
        // Attach onClick event listeners to each button
        foreach (Button button in buttons) {
            button.onClick.AddListener(() => ButtonClicked(button));
        }
    }

    void ButtonClicked(Button clickedButton) {
        NoteState.Note note = NoteState.Note.none;

        switch (clickedButton.gameObject.name) {
            case "None":
                note = NoteState.Note.none;
                break;
            case "C":
                note = NoteState.Note.C;
                break;
            case "D":
                note = NoteState.Note.D;
                break;
            case "E":
                note = NoteState.Note.E;
                break;
            case "F":
                note = NoteState.Note.F;
                break;
            case "G":
                note = NoteState.Note.G;
                break;
            case "A":
                note = NoteState.Note.A;
                break;
            case "B":
                note = NoteState.Note.B;
                break;
        }
        currentColor.color = NoteColorLookupTable.GetValue(note);  
        StateManager.instance.setNoteState(new NoteState(note));
    }
}
