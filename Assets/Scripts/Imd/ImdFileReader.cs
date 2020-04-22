using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

public class ImdFileReader : FileReaderBase
{
    public ImdFileReader(INoteFactory factory) : base(factory) { }
    public override void LoadBinaryReader(BinaryReader reader)
    {
        var totalTime = reader.ReadInt32();
        factory.Create
        (
            type: NoteType.SetTotalTime,
            value: totalTime
        );
        var beatCount = reader.ReadInt32();
        var bpm = 0d;
        foreach (var _ in Enumerable.Range(0, beatCount))
        {
            var timestamp = reader.ReadInt32();
            var currBpm = reader.ReadDouble();
            if (currBpm != bpm)
            {
                factory.Create
                (
                    type: NoteType.SetBpm,
                    timestamp: timestamp,
                    value: currBpm
                );
                bpm = currBpm;
            }
        }
        reader.ReadBytes(2); // 0x03 0x03
        var actionCount = reader.ReadInt32();
        foreach(var _ in Enumerable.Range(0, actionCount))
        {
            var type = (NoteType)reader.ReadInt16();
            var timestamp = reader.ReadInt32();
            var trackId = (int)reader.ReadByte();
            var value = reader.ReadInt32();
            factory.Create
            (
                type: type,
                timestamp: timestamp,
                trackId: trackId,
                value: value
            );
        }
    }
}
