public class PolyFirstHoldNote:ImdNoteBase 
{
    protected override void Draw()
    {
        base.Draw();
        AddFirstSprite();
        AddHoldSprite();
    }
}
