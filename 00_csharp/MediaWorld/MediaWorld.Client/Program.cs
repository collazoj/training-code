using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediaWorld.Domain.Abstracts;
// using MediaWorld.Domain.Models;
// using MediaWorld.Domain.Interfaces;
// using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Singletons;
using MediaWorld.Storing.Connectors;
// using MediaWorld.Domain.Factories;
using MediaWorld.Storing.Repositories;
using Serilog;

namespace MediaWorld.Client
{
  /// <summary>
  /// contains the start point
  /// </summary>
    internal class Program
    {
      /// <summary>
      /// starts the application
      /// </summary>
      private static MediaRepository _repository = new MediaRepository();
      private static void Main(string[] args)
      {
        (new Program()).ApplicationStart();
        // Play();
        // MagicThread();
        // MagicTask();
        MagicAsync().GetAwaiter().GetResult();
        Console.WriteLine(" end of code ");

        Log.Warning("end of main method");
        FileSystemConnector f = new FileSystemConnector();
        f.WriteXml(data, _path)
      }


      private static void MagicThread()
      {
        var t1 = new Thread(() => { Run("A");  }); //This whole thing is a lambda expression. 
        var t2 = new Thread(() => { Run("B");  });
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        // if (t1.IsAlive)    This is the kind of code you need if you want to stop a thread at a certain point.
      }

      private static void MagicTask()
      {
        var t1 = new Task(() => { Run("A");  }); //This whole thing is a lambda expression. 
        var t2 = new Task(() => { Run("B");  });

        t1.Start();
        t2.Start();

        Task.WaitAll(new Task[]{t1,t2}, 1000);
      }

      private static async Task MagicAsync()
      {
        await Task.Run(() => { Run("C"); }); 
      }

      private static void Run(string s)
      {
        for (var x = 0; x<1000; x++)
        {
          Console.Write(s);
        }
      }
      private void ApplicationStart()
      {
        Log.Logger = new LoggerConfiguration()
          .MinimumLevel.Debug()
          .WriteTo.Console()
          .WriteTo.File("log.txt")
          .CreateLogger();
      }
      private static void Play()
      {
        Log.Information("Play Method");
        var mediaPlayer = MediaPlayerSingleton.Instance;
        foreach(var item in _repository.MediaLibrary)
        {
          Log.Debug("{item}", item.Title); //add ".Title" to hide all item info and only display obj title.
          mediaPlayer.Execute(item.Play, item); //Here, we raise the event from Execute() in MediaPS
        }
      }



    }
}
