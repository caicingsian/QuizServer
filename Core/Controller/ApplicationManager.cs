using System;
using Samurai.Utils;
using Ninject;
using Samurai.MVCExpress;
using Samura.QuizServer;
using QuizServer;

namespace Samurai.QuizServer
{
	public class ApplicationManager : Controller
	{
		[Inject]
		public TimerManager timer{ get; set; }

		[Inject]
		public ServerSocketController socket{ get; set;}

		[Inject]
		public PlayerManager playerManger{ get; set; }

		[Inject]
		public IDBManager dbManager{ get; set;}

		public ApplicationManager ()
		{
			
		}

		public override void Start ()
		{
			base.Start ();
		} 

		public override void Initialize ()
		{
			base.Initialize ();
			timer.OnTick.AddListener (OnTickHandler);
		}

		public void OnTickHandler(double delta)
		{

		}
	}
}

