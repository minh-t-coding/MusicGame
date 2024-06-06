using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip[] sfx;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void playNote(NoteState.Note note) {
        switch (note) {
            case NoteState.Note.C:
                src.PlayOneShot(sfx[0]);
                break;
            case NoteState.Note.D:
                src.PlayOneShot(sfx[1]);
                break;
            case NoteState.Note.E:
                src.PlayOneShot(sfx[2]);
                break;
            case NoteState.Note.F:
                src.PlayOneShot(sfx[3]);
                break;
            case NoteState.Note.G:
                src.PlayOneShot(sfx[4]);
                break;
            case NoteState.Note.A:
                src.PlayOneShot(sfx[5]);
                break;
            case NoteState.Note.B:
                src.PlayOneShot(sfx[6]);
                break;
        }
    }
}
