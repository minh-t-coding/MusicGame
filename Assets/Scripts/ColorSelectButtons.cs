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
            case "Kick":
                note = NoteState.Note.kick;
                break;
            case "Clap":
                note = NoteState.Note.clap;
                break;
            case "Snare":
                note = NoteState.Note.snare;
                break;
            case "Hat":
                note = NoteState.Note.hat;
                break;
        }
        currentColor.color = NoteColorLookupTable.GetValue(note);  
        StateManager.instance.setNoteState(new NoteState(note));
    }
}
