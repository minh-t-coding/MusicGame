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
                src.clip = sfx[0];
                src.Play();
                break;
            case NoteState.Note.hat:
                src.clip = sfx[1];
                src.Play();
                break;
            case NoteState.Note.kick:
                src.clip = sfx[2];
                src.Play();
                break;
            case NoteState.Note.snare:
                src.clip = sfx[3];
                src.Play();
                break;
        }
    }
}
