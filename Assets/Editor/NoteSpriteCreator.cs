using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.IO;

public class NoteSpriteCreator : ScriptableObject
{
    [MenuItem("Tools/CreateNoteSprites")]
    public static void CreateNoteSprites()
    {
        CreateTouchSprite();
        CreatePressNote();
        CreateSlideNote();
        CreateLastSlideNote();
        CreateFirstPressSprite();
        AssetDatabase.Refresh();
    }

    static int width = 100;
    static int height = 40;
    static string rootPath = "Assets/Resources/Note/";
    static Color green = new Color32(0x00, 0xff, 0x00, 0xff);
    static Color blue = new Color32(0x00, 0xcc, 0xff, 0xff);
    static Color yellow = Color.yellow;
    static Color clear = Color.clear;

    public static void CreateTouchSprite()
    {
        var texture = new Texture2D(width, height);
        foreach (var w in Enumerable.Range(0, width)) foreach (var h in Enumerable.Range(0, height)) texture.SetPixel(w, h, blue);
        File.WriteAllBytes(rootPath + "Touch.png", texture.EncodeToPNG());
    }
    public static void CreateFirstPressSprite()
    {
        var texture = new Texture2D(width, height);
        foreach (var w in Enumerable.Range(0, width)) foreach (var h in Enumerable.Range(0, height)) texture.SetPixel(w, h, green);
        File.WriteAllBytes(rootPath + "FirstPress.png", texture.EncodeToPNG());
    }

    public static void CreatePressNote()
    {
        var texture = new Texture2D(width, height);
        foreach (var w in Enumerable.Range(0, width)) foreach (var h in Enumerable.Range(0, height)) texture.SetPixel(w, h, clear);
        foreach (var w in Enumerable.Range(width*45/100, width*11/100)) foreach (var h in Enumerable.Range(0, height)) texture.SetPixel(w, h, yellow);
        File.WriteAllBytes(rootPath + "Press.png", texture.EncodeToPNG());
    }

    public static void CreateSlideNote()
    {
        var texture = new Texture2D(width, height);
        foreach (var w in Enumerable.Range(0, width)) foreach (var h in Enumerable.Range(0, height)) texture.SetPixel(w, h, clear);
        foreach (var w in Enumerable.Range(0, width)) foreach (var h in Enumerable.Range(height*45/100, height*11/100)) texture.SetPixel(w, h, yellow);
        File.WriteAllBytes(rootPath + "Slide.png", texture.EncodeToPNG());

        var tex2 = new Texture2D(width, height);
        foreach (var w in Enumerable.Range(0, width)) foreach (var h in Enumerable.Range(0, height)) tex2.SetPixel(w, h, clear);
        foreach (var w in Enumerable.Range(0, width / 2)) foreach (var h in Enumerable.Range(0, height)) tex2.SetPixel(w, h, texture.GetPixel(w, h));
        File.WriteAllBytes(rootPath + "RightPolyLastSlide.png", tex2.EncodeToPNG());
        foreach (var w in Enumerable.Range(0, width)) foreach (var h in Enumerable.Range(0, height)) if (tex2.GetPixel(w, h) == yellow) tex2.SetPixel(w, h, green);
        File.WriteAllBytes(rootPath + "RightSlide.png", tex2.EncodeToPNG());

                var tex3 = new Texture2D(width, height);
        foreach (var w in Enumerable.Range(0, width)) foreach (var h in Enumerable.Range(0, height)) tex3.SetPixel(w, h, clear);
        foreach (var w in Enumerable.Range(width / 2, width - width / 2)) foreach (var h in Enumerable.Range(0, height)) tex3.SetPixel(w, h, texture.GetPixel(w, h));
        File.WriteAllBytes(rootPath + "LeftPolyLastSlide.png", tex3.EncodeToPNG());
        foreach (var w in Enumerable.Range(0, width)) foreach (var h in Enumerable.Range(0, height)) if (tex3.GetPixel(w, h) == yellow) tex3.SetPixel(w, h, green);
        File.WriteAllBytes(rootPath + "LeftSlide.png", tex3.EncodeToPNG());
    }

    public static void CreateLastSlideNote()
    {
        var texture = new Texture2D(width, height);
        foreach (var w in Enumerable.Range(0, width)) foreach (var h in Enumerable.Range(0, height)) 
            {
                texture.SetPixel(w, h, clear);
                var x = (float)w / (float)width;
                var y = Math.Abs((float)h - (float)height/2f) / ((float)height / 2f);
                var minX = 1 / 3f;
                var maxX = 2 / 3f;
                var minY = 0;
                var maxY = 1 / 2f;
                if (x < minX || x > maxX) continue;
                if (y < minY || y > maxY) continue;
                // 只要点在(minX, maxY)和(maxX, minY)这条线的下面就算正确
                // 这条线的方程为 y-maxY/minY-maxY = x-minX/maxX-minX
                // 即 y = (x-minX)/(maxX-minX)*(minY-maxY) + maxY
                if ((x - minX) / (maxX - minX) * (minY - maxY) + maxY < y) continue;
                texture.SetPixel(w, h, green);
            }
        File.WriteAllBytes(rootPath + "RightLastSlide.png", texture.EncodeToPNG());
        var tex2 = new Texture2D(width, height);
        foreach (var w in Enumerable.Range(0, width)) foreach (var h in Enumerable.Range(0, height)) tex2.SetPixel(w, h, texture.GetPixel(width - 1 - w, h));
        File.WriteAllBytes(rootPath + "LeftLastSlide.png", tex2.EncodeToPNG());

    }
}