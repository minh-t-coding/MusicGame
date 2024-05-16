using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private Texture2D cursor;

    public void OnPointerEnter(PointerEventData eventData) {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData) {
        switch (StateManager.instance.getBrushState()) {
            case StateManager.BrushState.Pencil:
                StateManager.instance.setBrushState(StateManager.BrushState.Pencil);
                break;
            case StateManager.BrushState.Eraser:
                StateManager.instance.setBrushState(StateManager.BrushState.Eraser);
                break;
        }
        
    }
}
