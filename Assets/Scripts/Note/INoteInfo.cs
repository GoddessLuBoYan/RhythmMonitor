public interface INoteInfo
{
    NoteType Type { get; set; }
    int Timestamp { get; set; }
    int TrackId { get; set; }
    double Value { get; set; }
}
