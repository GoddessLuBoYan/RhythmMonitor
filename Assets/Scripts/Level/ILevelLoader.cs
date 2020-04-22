using UnityEngine;
using System.Collections;

public interface ILevelLoader
{
    ILevelInfo Load(string path);
}
