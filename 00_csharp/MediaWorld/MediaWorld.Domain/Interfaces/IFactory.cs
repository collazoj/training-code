using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Interfaces
{
  public interface IFactory
  {
    AMedia Create<T>() where T : AMedia, new(); //<T> means the type T
  }
}