using System;
using UnityEngine;
/*
public partial class TouchNote:ImdNoteBase { }
public partial class SlideNote:ImdNoteBase { }
public partial class HoldNote:ImdNoteBase { }
public partial class PolyFirstHoldNote:ImdNoteBase { }
public partial class PolyFirstSlideNote:ImdNoteBase { }
public partial class PolyHoldNote:ImdNoteBase { }
public partial class PolySlideNote:ImdNoteBase { }
public partial class PolyLastHoldNote:ImdNoteBase { }
public partial class PolyLastSlideNote:ImdNoteBase { }
public partial class SetBpmNote:ImdNoteBase { }
public partial class SetTotalTimeNote:ImdNoteBase { }
*/
public class ImdNoteFactory:MonoBehaviour, INoteFactory
{
    public float NoteScale { get; set; } = 1f;
    public INoteInfo Create(NoteType type, double value) { return Create(type, 0, -1, value); }
    public INoteInfo Create(NoteType type, int timestamp, double value) { return Create(type, timestamp, -1, value); }
    public INoteInfo Create(NoteType type, int timestamp, int trackId) { return Create(type, timestamp, trackId, 0); }
    public INoteInfo Create(NoteType type, int timestamp, int trackId, double value)
    {
        var go = new GameObject();
        var t = go.GetOrAddComponent(Enum.GetName(typeof(NoteType), type) + "Note") as ImdNoteBase;
        if (t == null) { DestroyImmediate(go); return null; }
        t.Type = type;
        t.Timestamp = timestamp;
        t.TrackId = trackId;
        t.Value = value;
        t.Scale = NoteScale;
        go.name = t.ToString();
        go.transform.parent = this.transform;
        go.tag = "Note";
        return t;
    }
}