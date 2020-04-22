public class SlideNote:ImdNoteBase 
{
    protected override void Draw()
    {
        base.Draw();
        AddFirstSprite();
        AddSlideSprite();
        AddLastSlideSprite();
    }
}
