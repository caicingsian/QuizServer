using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using NLog;
using System.Configuration;
using Samurai.MVCExpress;
using Samurai.QuizServer;

namespace Samurai.QuizServer
{
	class MainClass
	{
		private static MainModule _mainModule;


		static void Main(string[] args) 
		{
			_mainModule = new MainModule ();
			_mainModule.Start ();
		}
	}
}
