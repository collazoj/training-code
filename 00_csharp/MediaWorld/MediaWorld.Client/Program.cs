﻿using System;
using MediaWorld.Domain.Models;
using MediaWorld.Domain.Interfaces;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Singletons;


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
        private static void Main(string[] args)
        {

          Play();

        }
        private static void Play()
        {
          var mediaPlayer = MediaPlayerSingleton.Instance;
          AMedia song = new Song();
          AMedia movie = new Movie();

          mediaPlayer.Execute("play", song);
          mediaPlayer.Execute("play", movie);
        }
    }
}
