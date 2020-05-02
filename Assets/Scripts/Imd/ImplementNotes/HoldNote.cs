public class HoldNote:ImdNoteBase 
{
    protected override void Draw()
    {
        base.Draw();
        AddFirstSprite();
        AddHoldSprite();
    }
}
