using ReactiveUI;
using SharpHook.Reactive;
using SharpHook;
using System.Reactive.Concurrency;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using BongoCat.ViewModels.ImageHelpers;
using System;
using System.Reflection.Metadata;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Threading;


namespace BongoCat.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        public Bitmap? bongoCatImage = null;
        public Bitmap? BongoCatImage {
            get => bongoCatImage;
            set => this.RaiseAndSetIfChanged(ref bongoCatImage, value);
        }


        private Listener listener;
        public Listener Listen{ 
            get {  return listener; } 
            set { listener = value; }
        }

        Bitmap?[] images { get; set; } = new Bitmap?[4];

        public int imageIndex = 0;

        private long crazyCounter = 0;

        public long CrazyCounter {
            get => crazyCounter; 
            set => this.RaiseAndSetIfChanged(ref crazyCounter, value);
        }

        private Bitmap? cat0;
        private Bitmap? cat1;
        private Bitmap? cat2;
        private Bitmap? cat3;

        public MainWindowViewModel()
        {
            Listen = new Listener(this);
            cat0 = ImageHelper.LoadFromResource(new Uri("resm:BongoCat.Assets.Cat0-.png?assembly=BongoCat"));
            cat1 = ImageHelper.LoadFromResource(new Uri("resm:BongoCat.Assets.Cat1-.png?assembly=BongoCat"));
            cat2 = ImageHelper.LoadFromResource(new Uri("resm:BongoCat.Assets.Cat2-.png?assembly=BongoCat"));
            cat3 = ImageHelper.LoadFromResource(new Uri("resm:BongoCat.Assets.Cat3-.png?assembly=BongoCat"));

            
            images[0] = cat0;
            images[1] = cat1;
            images[2] = cat2;
            images[3] = cat3;
            BongoCatImage = images[imageIndex];

            Listen.listen();
        }

        public void IncrementCrazyCounterCommand()
        {
            CrazyCounter++;
        }

        public void ChangeBackgroundImageCommand()
        {
            imageIndex += 1;
            if (imageIndex > images.Length - 1)
            {
                imageIndex = 0;
            }
            BongoCatImage = images[imageIndex];
        }

        public void closeCommand() 
        {
            listener.Hook.Dispose();
            Thread.Sleep(1000);
            Environment.Exit(0);
        }

    }
}