public class PolyLastSlideNote:ImdNoteBase 
{
    protected override void Draw()
    {
        base.Draw();
        AddSlideSprite();
        AddLastSlideSprite();
    }
}
