using MediaWorld.Domain.Models;
using MediaWorld.Domain.Abstracts;
using static MediaWorld.Domain.Delegates.ControlDelegate;

namespace MediaWorld.Domain.Singletons
{
  public class MediaPlayerSingleton : Interfaces.IPlayer
  {
    private static readonly MediaPlayerSingleton _instance = new MediaPlayerSingleton();
    private MediaPlayerSingleton(){} //this is a singleton. Private, empty method within a class w same name.
    public static MediaPlayerSingleton Instance
    {
      get{
        return _instance;
      }
    }
    public bool Execute(ButtonDelegate button, AMedia media) 
    {
      media.ResultEvent += ResultHandler; //Here, we invoke the event
      return button();
    }

    public void ResultHandler(AMedia media)
    {
      System.Console.WriteLine("{0} is playing...", media.Title);
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
      return true;
    }
    public bool VolumeMute()
    {
      return true;
    }
    public bool VolumeUp()
    {
      return true;
    }
  }
}