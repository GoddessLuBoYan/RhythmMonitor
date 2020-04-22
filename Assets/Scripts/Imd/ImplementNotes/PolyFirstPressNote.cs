public class PolyFirstPressNote:ImdNoteBase 
{
    protected override void Draw()
    {
        base.Draw();
        AddFirstSprite();
        AddPressSprite();
    }
}
