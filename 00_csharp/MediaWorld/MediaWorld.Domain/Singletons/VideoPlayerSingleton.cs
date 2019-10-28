using MediaWorld.Domain.Models;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Singletons
{
  public class VideoPlayerSingleton
  {
    private static readonly VideoPlayerSingleton _instance = new VideoPlayerSingleton();
    private VideoPlayerSingleton(){}
    public static VideoPlayerSingleton Instance
    {
      get{
        return _instance;
      }
    }

    public void Execute(string s, AVideo video)
    {
      System.Console.WriteLine(video);
    }
  }
}