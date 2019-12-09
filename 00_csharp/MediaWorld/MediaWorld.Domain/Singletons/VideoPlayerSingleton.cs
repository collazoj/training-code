using MediaWorld.Domain.Models;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Singletons
{
  public class VideoPlayerSingleton : Interfaces.IPlayer
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
    public bool PowerDown()
    {
      throw new System.NotImplementedException();
    }
    public bool PowerUp()
    {
      throw new System.NotImplementedException();
    }
    public bool VolumeDown()
    {
      throw new System.NotImplementedException();
    }
    public bool VolumeMute()
    {
      throw new System.NotImplementedException();
    }
    public bool VolumeUp()
    {
      throw new System.NotImplementedException();
    }
  }
}