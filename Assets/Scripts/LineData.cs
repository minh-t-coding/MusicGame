using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LineData
{
    public string name;
    public NoteState.Note note;
    public List<Vector2Data> points;

    public LineData(string name, NoteState.Note note, List<Vector2Data> points)
    {
        this.name = name;
        this.note = note;
        this.points = points;
    }
}

[Serializable]
public class Vector2Data
{
    public float x;
    public float y;

    public Vector2Data(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2 ToVector2()
    {
        return new Vector2(x, y);
    }
}