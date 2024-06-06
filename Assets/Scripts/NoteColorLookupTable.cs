using System.Collections.Generic;
using UnityEngine;

public class NoteColorLookupTable {
    // Static dictionary for lookup table
    private static Dictionary<NoteState.Note, Color32> dataLookup = new Dictionary<NoteState.Note, Color32>();

    // Static constructor to initialize the lookup table
    static NoteColorLookupTable() {
        // Add data to the lookup table
        dataLookup.Add(NoteState.Note.none, new Color32(44, 62, 80, 255)); // none = black
        dataLookup.Add(NoteState.Note.C, new Color32(255, 87, 51, 255)); // C = Red
        dataLookup.Add(NoteState.Note.D, new Color32(255, 141, 26, 255)); // D = Orange
        dataLookup.Add(NoteState.Note.E, new Color32(255, 215, 0, 255)); // E = Yellow
        dataLookup.Add(NoteState.Note.F, new Color32(50, 205, 50, 255)); // F = Green
        dataLookup.Add(NoteState.Note.G, new Color32(30, 144, 255, 255)); // G = Blue
        dataLookup.Add(NoteState.Note.A, new Color32(75, 0, 130, 255)); // A = Indigo
        dataLookup.Add(NoteState.Note.B, new Color32(138, 43, 226, 255)); // B = Violet
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
