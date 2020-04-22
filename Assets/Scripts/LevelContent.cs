using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LevelContent : MonoBehaviour
{
    public Camera LevelCamera;
    public AudioSource Audio;
    public GameObject NoteContainer;
    public ImdNoteFactory NoteFactory;
    public Canvas BgCanvas;
    public Camera BgCamera;

    public Image BackGround;

    private void Awake()
    {
        LoadLevel(new ImdLoader().Load("Songs/pureparade/pureparade_6k_hd.imd"));
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
        LevelCamera.transform.localPosition = new Vector3(2f, -1.6f, -5f);
        LevelCamera.transform.localEulerAngles = new Vector3(-45, 0, 0);
    }

    public void LoadAudio(string audioPath)
    {
        Audio.clip = Resources.Load<AudioClip>(audioPath.Replace(".mp3", ""));
    }

    public void InitNoteFactory(int trackCount)
    {
        NoteFactory.NoteScale = Math.Abs(LevelCamera.transform.localPosition.z / trackCount);
    }

    public void LoadImdFile(string filename)
    {
        var reader = new ImdFileReader(NoteFactory);
        reader.LoadFile(filename);
    }

    public IEnumerator Play()
    {
        Audio.Play();
        while (true)
        {
            var pos = NoteContainer.transform.localPosition;
            NoteContainer.transform.localPosition = new Vector3(pos.x, pos.y - 10 * Time.deltaTime, pos.z);
            yield return null;
        }
        yield break;
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
