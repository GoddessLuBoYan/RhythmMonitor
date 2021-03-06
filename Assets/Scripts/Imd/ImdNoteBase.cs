﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class ImdNoteBase:MonoBehaviour
{
    public static int NoteWidth = 100;
    public static int NoteHeight = 40;
    public static string NoteSpriteRoot = "Note/";
    public float Scale = 5f/4f;
    public NoteType Type;

    public int Timestamp;

    public int TrackId;

    public double Value;
    public ImdNoteBase NextNote;

    public override string ToString()
    {
        if (Type == NoteType.SetBpm || Type == NoteType.SetTotalTime) return $"{Type}_{Value}";
        if (Type == NoteType.Touch) return $"{Type}_{Timestamp}_{TrackId}";
        return $"{Type}_{Timestamp}_{TrackId}_{(int)Value}";
    }

    private void Start()
    {
        transform.localPosition = new Vector2(TrackId * Scale, Timestamp/100f);
        Draw();
    }

    protected virtual void Draw()
    {

    }

    protected void AddSprite(string spriteName)
    {
        AddSprite(spriteName, 0, 0f);
    }

    protected void AddSprite(string spriteName, double x, double length)
    {
        var texture = Resources.Load<Texture2D>(NoteSpriteRoot + spriteName);
        if (!texture) return;
        var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), texture.width);
        var go = new GameObject(spriteName);
        go.transform.parent = this.transform;
        go.layer = LayerMask.NameToLayer("Note");
        var sr = go.AddComponent<SpriteRenderer>();
        sr.sprite = sprite;
        sr.size *= Scale;
        sr.transform.localPosition = new Vector2(((float)x + 0.5f) * Scale, (float)length / 2f);
        sr.transform.localScale = new Vector2(1f * Scale, 1f);
        if (length > 0)
        {
            sr.transform.localScale = new Vector2(1f, (float)length / sprite.rect.height * sprite.pixelsPerUnit);
        }
    }

    protected void AddSlideSprite()
    {
        if (Value > 0)
        {
            for (double i = 0; i < Value; i++)
            {
                AddSprite("Slide", i + 0.5, 0);
            }
        }
        else if (Value < 0)
        {
            for (double i = 0; i > Value; i--)
            {
                AddSprite("Slide", i - 0.5, 0);
            }
        }
    }

    protected void AddLastSlideSprite()
    {
        if(Value > 0)
        {
            AddSprite("RightLastSlide", Value, 0);
        }
        else if(Value < 0)
        {
            AddSprite("LeftLastSlide", Value, 0);
        }
    }

    protected void AddFirstSprite()
    {
        AddSprite("FirstHold");
    }

    protected void AddHoldSprite()
    {
        AddSprite("Hold", 0, Value / 100);
    }
}
