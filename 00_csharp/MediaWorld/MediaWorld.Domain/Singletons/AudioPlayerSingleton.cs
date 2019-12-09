using MediaWorld.Domain.Models;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Singletons
{
  public class AudioPlayerSingleton : Interfaces.IPlayer
  {
    private static readonly AudioPlayerSingleton _instance = new AudioPlayerSingleton();
    private AudioPlayerSingleton(){}
    public static AudioPlayerSingleton Instance
    {
      get{
        return _instance;
      }
    }

    public void Execute(string command, AAudio audio) 
    {
      System.Console.WriteLine(audio);
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