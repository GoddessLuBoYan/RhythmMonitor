using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ImdLevelInfo : ILevelInfo
{
    public string LevelName { get; set; }
    public string AudioPath { get; set; }
    public string BackgroundTexturePath { get; set; }
    public string NoteCollectionPath { get; set; }
    public int TrackCount { get; set; }
    public Difficulty Difficulty { get; set; }
    public int TotalTime { get; set; }
}
