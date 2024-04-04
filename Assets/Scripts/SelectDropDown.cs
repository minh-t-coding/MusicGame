using TMPro;
using UnityEngine;

public class SelectDropDown : MonoBehaviour {
    [SerializeField] private TMP_Dropdown dropdown;

    public void SetDropdownValue() {
        int pickedEntryIndex = dropdown.value;
        switch (pickedEntryIndex) {
            case 0:
                StateManager.instance.setBrushState(StateManager.BrushState.Pencil);
                break;
            case 1:
                StateManager.instance.setBrushState(StateManager.BrushState.Eraser);
                break;
        }
    }
}
