using UnityEngine;
using UnityEngine.UI;

public class PlayPauseButton : MonoBehaviour {
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Button button;

    public void SwapButtonImage() {
        if (StateManager.instance.getIsPlaying()) {
            button.image.sprite = pauseSprite;
        } else {
            button.image.sprite = playSprite;
        }
    }
}
