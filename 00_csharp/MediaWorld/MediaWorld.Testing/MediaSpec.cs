using System;
using Xunit;
using MediaWorld.Domain.Factories;
using MediaWorld.Domain.Models;
using Moq;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Singletons;

namespace MediaWorld.Testing
{
    public class MediaSpec
    {
      AudioFactory af = new AudioFactory();
      VideoFactory vf = new VideoFactory();
      Mock<AMedia> mock;
      public MediaSpec()
      {
        mock = new Mock<AMedia>();
        mock.Setup(am => am.Play()).Returns(false); //I am mocking that Play will return a boolean, it doesn't 
                                                    //matter so long as it's a boolean. When Play() is written,
                                                    //we can comment this out.
      }
      [Fact] //We want this to run before Test_AudioObject(). In order to call Test_Audio... we need to run Fact first.
      public void Test_AudioObject()
      {
        var sut = af; //"subject under test"
        var expected = typeof(Song);
        //Act
        var actual = af.Create<Song>() as Song;
        //Assert
        Assert.True(expected == actual.GetType());
      }
      [Fact]
      public void Test_VideoPlay()
      {
        var sut = MediaPlayerSingleton.Instance;
        var mm = mock.Object; //This gives me the Mock Object(fake object). 
        Assert.False(sut.Execute(mm.Play, mm)); //pretend that execute returns a boolean, in which case we are mocking MediaPlayerSingleton 
      }
    }
}
