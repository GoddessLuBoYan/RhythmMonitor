using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public interface INoteFactory
{
    INoteInfo Create(NoteType type, double value);
    INoteInfo Create(NoteType type, int timestamp, double value);
    INoteInfo Create(NoteType type, int timestamp, int trackId);
    INoteInfo Create(NoteType type, int timestamp, int trackId, double value);
}
