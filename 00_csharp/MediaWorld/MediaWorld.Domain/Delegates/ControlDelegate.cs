
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Delegates
{
  public abstract class ControlDelegate
  {
    public delegate bool ButtonDelegate(); //Delegate is a placeholder for the method of same signature.
    public delegate void ResultDelegate(AMedia media);
  }
}