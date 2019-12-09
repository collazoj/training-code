using System;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Models
{
  public class Song : AAudio
  {
    public Song()
    {
      Initialize();
    }
    public Song(string title, string artist, TimeSpan duration, int bitRate)
    {
      Initialize(title, artist, duration, bitRate);
      //This entire method can be commented out, and everything would still work bc of factory design.
    }
    private void Initialize(string title="Good Song", string artist="best artist", TimeSpan duration=new TimeSpan(), int bitRate=24)
    {
      Title=title;
      Author=artist;
      Duration=duration;
      BitRate=bitRate;
    }

    // public override bool Forward()
    // {
    //   throw new System.NotImplementedException();
    // }

    // public override bool Rewind()
    // {
    //   throw new System.NotImplementedException();
    // }
  }
}