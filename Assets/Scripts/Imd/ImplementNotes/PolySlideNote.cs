public class PolySlideNote:ImdNoteBase 
{
    protected override void Draw()
    {
        base.Draw();
        if (Value == 0) return;
        AddSlideSprite();
    }
}
