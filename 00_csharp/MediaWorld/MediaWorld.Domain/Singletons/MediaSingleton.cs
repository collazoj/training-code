using MediaWorld.Domain.Models;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Singletons
{
  public class MediaPlayerSingleton
  {
    private static readonly MediaPlayerSingleton _instance = new MediaPlayerSingleton();
    private MediaPlayerSingleton(){} //this is a singleton. Private, empty method within a class w same 
    public static MediaPlayerSingleton Instance
    {
      get{
        return _instance;
      }
    }

    public void Execute(string command, AMedia media) 
    {
      System.Console.WriteLine(media);
    }
  }
}