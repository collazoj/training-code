using MediaWorld.Domain.Interfaces;
using System;
using System.Threading;
using static MediaWorld.Domain.Delegates.ControlDelegate;

namespace MediaWorld.Domain.Abstracts
{
  public abstract class AMedia : IControl //there is technically "Object," before "IControl"
  {
    
    public event ResultDelegate ResultEvent; //this is where we define the Event
    public TimeSpan Duration { get; set; }

    public string Title { get; set; }
    public abstract bool Forward();
    public int FrameRate { get; set; }
    public virtual bool Pause()
    {
      throw new System.NotImplementedException();
    }
    public virtual bool Play()
    {
      int count =0;
      if (ResultEvent==null)
      {
        return false;
      }
      while (count<10)
      {
        // Thread.Sleep(2000);
        ResultEvent(this); //our event is called
        count+=1;
      }
      return true;
    }










    public abstract bool Rewind();
    public bool Stop()
    {
      throw new System.NotImplementedException();
    }
    public override string ToString()
    {
      return $"{this.Title}";
    }
  }
}