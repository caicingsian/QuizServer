using System;
using Samurai.MVCExpress;
using Ninject;
using Samurai.QuizServer;

namespace Samura.QuizServer
{
	public class ServerSocketController : Controller
	{
		[Inject]
		public ISocketService socket{ get; set;}

		public ServerSocketController ()
		{


		}

		public override void Initialize ()
		{
			base.Initialize ();
			socket.Start ();
		}
	}
}

