public enum NoteType:short
{
    Touch = 0x00, // 单点
    Slide = 0x01, // 滑键
    Press = 0x02, // 长条
    PolyFirstPress = 0x62, //折线先按
    PolyFirstSlide = 0x61, //折线先拐
    PolyPress = 0x22, //折线按
    PolySlide = 0x21, //折线拐
    PolyLastPress = 0xa2, //折线最后一根面条
    PolyLastSlide = 0xa1, //折线钩子

    SetBpm = 0xff, // 更改bpm
    SetTotalTime = 0xfe, // 更改总时间
}
