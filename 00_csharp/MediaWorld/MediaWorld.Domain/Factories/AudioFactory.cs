using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Interfaces;
// using MediaWorld.Domain.Models;

namespace MediaWorld.Domain.Factories
{
  public class AudioFactory : IFactory
  {
    public AMedia Create<T>() where T : AMedia, new() //new() is an empty constructor. "I don't need to know what you're making."
    {
      return new T();
      // switch(type) //this is what we had before
      // {
      //   case "book":
      //     return new Book();
      //   case "song":
      //     return new Song();
      //   default:
      //     return null;
      // }
    }
  }
}