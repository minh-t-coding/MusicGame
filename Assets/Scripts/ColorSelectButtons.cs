using UnityEngine;
using UnityEngine.UI;

public class ColorSelectButtons : MonoBehaviour {
    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject currentColor;
    [SerializeField] private GameObject noneButton;
    [SerializeField] private float currentColorSelectorOffset;

    void Start() {
        // Attach onClick event listeners to each button
        foreach (Button button in buttons) {
            button.onClick.AddListener(() => ButtonClicked(button));
        }

        // Move selector to the noneButton
        // Vector3 newPosition = noneButton.transform.position + new Vector3(0, currentColorSelectorOffset);
        // currentColor.transform.position = newPosition;
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
        
        Vector3 newPosition = clickedButton.transform.position + new Vector3(0, currentColorSelectorOffset);
        currentColor.transform.position = newPosition;
        
        StateManager.instance.setNoteState(new NoteState(note));
    }
}
