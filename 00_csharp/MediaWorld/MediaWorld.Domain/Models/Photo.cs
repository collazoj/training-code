using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Models
{
  public class Photo : AVideo
  {
    public Photo()
    {
      Initialize();
    }
    public Photo(string title, string photographer)
    {
      Initialize(title, photographer);
    }
    private void Initialize(string title="best photo", string photographer="photographer")
    {
      Title=title;
      Director=photographer;
    }





    public override bool Forward()
    {
      throw new System.NotImplementedException();
    }

    public override bool Rewind()
    {
      throw new System.NotImplementedException();
    }
  }
}