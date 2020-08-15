using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LevelContent : MonoBehaviour
{
    #region Components
    public Camera LevelCamera;
    public AudioSource Audio;
    public GameObject NoteContainer;
    public ImdNoteFactory NoteFactory;
    public Canvas BgCanvas;
    public Camera BgCamera;
    public Image BackGround;
    #endregion
    public GameConfig Config;

    private void Awake()
    {
        LoadLevel(new ImdLoader().Load("Songs/pureparade/pureparade_5k_hd.imd"));
        NoteFactory.Create(NoteType.Touch, 0, 0);
        NoteFactory.Create(NoteType.Touch, 0, 1);
        NoteFactory.Create(NoteType.Touch, 0, 2);
        NoteFactory.Create(NoteType.Touch, 0, 3);
        NoteFactory.Create(NoteType.Touch, 0, 4);
        StartCoroutine(Play());
    }

    public void LoadLevel(ILevelInfo info)
    {
        ResetLevelCamera();
        LoadAudio(info.AudioPath);
        LoadBg(info.BackgroundTexturePath);
        InitNoteFactory(info.TrackCount);
        LoadImdFile("Assets/Resources/" + info.NoteCollectionPath);
    }

    private void LoadBg(string backgroundTexturePath)
    {
        var tex = Resources.Load<Texture2D>(backgroundTexturePath.Replace(".png", ""));
        var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2f, tex.height / 2f));
        BackGround.sprite = sprite;
    }

    public void Clear()
    {
        ClearNotes();
        ResetLevelCamera();
    }

    private void ResetLevelCamera()
    {
        LevelCamera.transform.localEulerAngles = new Vector3(-Config.CameraAngle, 0, 0);
        LevelCamera.fieldOfView = Config.CameraHalfFieldOfView*2;
        var halfScreenWidthInScene = Mathf.Abs((float)Screen.width / (float)Screen.height * Mathf.Tan(Config.CameraAngle * Mathf.Deg2Rad) * Config.CameraHeight)/2;
        var pos = new Vector3(halfScreenWidthInScene, 0f, -Config.CameraHeight);
        pos.y = Config.CameraHeight * Mathf.Tan((LevelCamera.fieldOfView / 2 - Config.CameraAngle) * Mathf.Deg2Rad);
        LevelCamera.transform.localPosition = pos;
    }

    public void LoadAudio(string audioPath)
    {
        Audio.clip = Resources.Load<AudioClip>(audioPath.Replace(".mp3", ""));
    }

    public void InitNoteFactory(int trackCount)
    {
        //var screenWidthInScene = Math.Abs((float)Screen.width / (float)Screen.height * Mathf.Tan(Config.CameraAngle * Mathf.Deg2Rad) * Config.CameraHeight);
        //NoteFactory.NoteScale = screenWidthInScene / trackCount;
        NoteFactory.TrackCount = trackCount;
        NoteFactory.NoteScale = Mathf.Abs(LevelCamera.transform.localPosition.x)*2/trackCount;
    }

    public void LoadImdFile(string filename)
    {
        var reader = new ImdFileReader(NoteFactory);
        reader.LoadFile(filename);
    }

    public IEnumerator Play()
    {
        yield return new WaitForSeconds(1f);
        Audio.Play();
        while (true)
        {
            var pos = NoteContainer.transform.localPosition;
            NoteFactory.NotesTransform.localPosition += new Vector3(pos.x, pos.y - 10 * Time.deltaTime, pos.z);
            yield return null;
        }
    }

    public void ClearNotes()
    {
        for(var i = 0; i < NoteContainer.transform.childCount; i++)
        {
            var child = NoteContainer.transform.GetChild(i);
            Destroy(child.gameObject);
        }
    }

}
