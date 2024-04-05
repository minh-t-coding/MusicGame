using System.Collections.Generic;
using UnityEngine;

public class NoteColorLookupTable {
    // Static dictionary for lookup table
    private static Dictionary<NoteState.Note, Color32> dataLookup = new Dictionary<NoteState.Note, Color32>();

    // Static constructor to initialize the lookup table
    static NoteColorLookupTable() {
        // Add data to the lookup table
        dataLookup.Add(NoteState.Note.none, new Color32(44, 62, 80, 255));
        dataLookup.Add(NoteState.Note.kick, new Color32(46, 204, 113, 255));
        dataLookup.Add(NoteState.Note.clap, new Color32(52, 152, 219, 255));
        dataLookup.Add(NoteState.Note.snare, new Color32(155, 89, 182, 255));
        dataLookup.Add(NoteState.Note.hat, new Color32(231, 76, 60, 255));
    }

    // Method to access the lookup table
    public static Color GetValue(NoteState.Note key) {
        // Check if the key exists in the dictionary
        if (dataLookup.ContainsKey(key)) {
            // Return the corresponding value
            return dataLookup[key];
        }
        else {
            // Key not found, return a default value or handle accordingly
            Debug.Log($"Key '{key}' not found in the lookup table.");
            return new Color(); // Default value or error handling
        }
    }
}
