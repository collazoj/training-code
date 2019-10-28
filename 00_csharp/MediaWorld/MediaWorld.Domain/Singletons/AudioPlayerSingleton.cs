using MediaWorld.Domain.Models;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Singletons
{
  public class AudioPlayerSingleton
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
  }
}