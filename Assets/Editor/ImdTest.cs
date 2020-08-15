/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    class ImdNoteTestFactory : ImdNoteFactory
    {
        public override ImdNoteBase Create(NoteType type, double value)
        {
            Debug.Log($"{type} {value}");
            return null;
        }

        public override ImdNoteBase Create(NoteType type, int timestamp, double value)
        {
            Debug.Log($"{type} {timestamp} {value}");
            return null;
        }

        public override ImdNoteBase Create(NoteType type, int timestamp, int trackId)
        {
            Debug.Log($"{type} {timestamp} {trackId}");
            return null;
        }

        public override ImdNoteBase Create(NoteType type, int timestamp, int trackId, double value)
        {
            Debug.Log($"{type} {timestamp} {trackId} {value}");
            return null;
        }
    }
    class ImdTest:ScriptableObject
    {
        static string imdPath = @"C:\MyProjects\节奏大师\我自己制作的自制谱\待完善\explosive\explosive_5k_ez.imd";
        [MenuItem("Test/ReadImd")]
        public static void ReadImd()
        {
            var reader = new ImdFileReader(new ImdNoteTestFactory());
            reader.LoadFile(imdPath);
        }

        [MenuItem("Test/LoadImdToScene")]
        public static void LoadImdToScene()
        {
            FindObjectOfType<LevelContent>().LoadImdFile(imdPath);
        }
    }
}
*/