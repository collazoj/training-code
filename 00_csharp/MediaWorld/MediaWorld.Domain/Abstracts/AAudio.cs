using MediaWorld.Domain.Interfaces;


namespace MediaWorld.Domain.Abstracts
{
    public abstract class AAudio : AMedia {
      public int BitRate { get; set; }
      public string Author { get; set; }
      public string Narrator { get; set; }

      public override bool Pause()
      {
        return false;
      }
      public override bool Play()
      {
        return true;
      }
      public override bool Forward()
      {
        return true;
      }
      public override bool Rewind()
      {
        return true;
      }
      public new bool Stop() //this doesn't need "new" keyword, but it gives a warning if not
      {
        return true;
      }
      public override string ToString() 
      {
        return $"{Title}{Duration}\nBitRate: {BitRate}";
      }
    }

}