public class PressNote:ImdNoteBase 
{
    protected override void Draw()
    {
        base.Draw();
        AddFirstSprite();
        AddPressSprite();
    }
}
