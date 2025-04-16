using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using SharpHook;
using SharpHook.Reactive;

namespace BongoCat.ViewModels
{
    public class Listener
    {
        public MainWindowViewModel? MyViewModel { get; set; }

        public Listener(MainWindowViewModel viewModel) {  MyViewModel = viewModel; }

        public SimpleReactiveGlobalHook Hook { get; set; }

        public void listen()
        {
            Hook = new SimpleReactiveGlobalHook(TaskPoolScheduler.Default);

        
            Hook.KeyPressed.Subscribe(e => OnKeyPressed(e,Hook));
            Hook.KeyReleased.Subscribe(e => OnKeyReleased(e,Hook));

            Hook.RunAsync().Subscribe();
        }

        private void OnKeyPressed(KeyboardHookEventArgs e, IReactiveGlobalHook hook) {
            //Debug.Write(e.Data.KeyCode);
            MyViewModel?.IncrementCrazyCounterCommand();
            MyViewModel?.ChangeBackgroundImageCommand();
        }
        private void OnKeyReleased(KeyboardHookEventArgs e, IReactiveGlobalHook hook) {
            //Debug.Write(e.Data.KeyCode);
            MyViewModel?.ChangeBackgroundImageCommand();
        }
    }
}
