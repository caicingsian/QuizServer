using System;
using strange.extensions.signal.impl;
using System.Timers;

namespace Samurai.Utils
{
	public class TimerManager
	{
		public Signal<double> OnTick = new Signal<double>();
		private Timer _timer;
		private DateTime _prevTime = DateTime.Now;

		public TimerManager ( int frequency )
		{
			_timer = new Timer ( frequency );
			_timer.Elapsed += OnTickHandler;
			_timer.AutoReset = true;
			_timer.Enabled = true;
			Stop ();
		}

		public void Start ()
		{
			_timer.Start ();
		}

		public void Stop()
		{
			_timer.Stop ();
		}

		private void OnTickHandler(Object source, ElapsedEventArgs e)
		{
			double delta = e.SignalTime.Subtract (_prevTime).TotalSeconds;
			_prevTime = e.SignalTime;
			OnTick.Dispatch (delta);
		}
	}
}

