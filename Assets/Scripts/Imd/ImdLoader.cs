using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

public class ImdLoader
{
    private static Regex imdNameReg = new Regex(@"([\S]+)_(\d+)k_(ez|nm|hd).imd");

    public ImdLevelInfo Load(string path)
    {
        var match = imdNameReg.Match(path);
        if (!match.Success) throw new LevelLoaderException("imd文件名不对");
        var name = match.Groups[1].Value;
        var trackStr = match.Groups[2].Value;
        if (!int.TryParse(trackStr, out int trackCount))
        {
            throw new LevelLoaderException("轨道数不对");
        }
        var diff = match.Groups[3].Value;

        var info = new ImdLevelInfo();
        info.AudioPath = name + ".mp3";
        info.Difficulty = diff;
        info.LevelName = name;
        info.TrackCount = trackCount;
        info.NoteCollectionPath = path;
        info.BackgroundTexturePath = name + ".png";
        return info;
    }
}
