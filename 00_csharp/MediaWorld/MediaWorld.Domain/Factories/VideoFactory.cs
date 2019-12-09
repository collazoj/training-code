using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Interfaces;
using MediaWorld.Domain.Models;

namespace MediaWorld.Domain.Factories
{
  public class VideoFactory : IFactory
  {
    public AMedia Create<T>() where T : AMedia, new()
    {
      return new T();
    }
  }
}