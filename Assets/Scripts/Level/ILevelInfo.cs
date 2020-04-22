using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelInfo
{
    string LevelName { get; set; }
    string AudioPath { get; set; }
    string BackgroundTexturePath { get; set; }
    string NoteCollectionPath { get; set; }
    int TrackCount { get; set; }
    Difficulty Difficulty { get; set; }
    int TotalTime { get; set; }
}
