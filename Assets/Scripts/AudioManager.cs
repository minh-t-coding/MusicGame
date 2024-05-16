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
            case NoteState.Note.clap:
                src.PlayOneShot(sfx[0]);
                break;
            case NoteState.Note.hat:
                src.PlayOneShot(sfx[1]);
                break;
            case NoteState.Note.kick:
                src.PlayOneShot(sfx[2]);
                break;
            case NoteState.Note.snare:
                src.PlayOneShot(sfx[3]);
                break;
        }
    }
}
