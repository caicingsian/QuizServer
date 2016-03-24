using System;
using NLog;
using System.Timers;
using Ninject;
using System.Reflection;

namespace Samurai.MVCExpress
{
	public class MainCore
	{
		protected IKernel _kernal = null;
		protected CommandInvoker _commandInvoker;

		public MainCore ()
		{
			OnInit ();
		}

		virtual	public void Start()
		{
			
		}

		virtual public void Exit()
		{
			
		}

		virtual public void OnInit()
		{
			AppDomain.CurrentDomain.ProcessExit += new EventHandler (OnAppExit);

			_kernal = new StandardKernel ();
			_kernal.Load (Assembly.GetExecutingAssembly ());

			_commandInvoker = new CommandInvoker (_kernal);
			_kernal.Bind<CommandInvoker> ().ToConstant (_commandInvoker);
		}

		private void OnAppExit (object sender, EventArgs e)
		{
			Exit ();
		}
	}
}

