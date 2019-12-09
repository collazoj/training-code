using System;
using MediaWorld.Domain.Abstracts;


namespace MediaWorld.Domain.Models
{
  public class Book : AAudio
  {
    public Book()
    {
      Initialize();
    }
    public Book(string title, string author, string narrator, TimeSpan duration, int bitRate)
    {
      Initialize(title, author, narrator, duration, bitRate);
    }
    private void Initialize(string title="Of Mice and Men", string author="John Steinbeck", string narrator="Morgan Freeman" ,TimeSpan duration=new TimeSpan(), int bitRate=256)
    {
      Title=title;
      Author=author;
      Duration=duration;
      BitRate=bitRate;
    }
  }
}