using System;
using Samurai.MVCExpress;
using Ninject;
using Samurai.Utils;

namespace Samurai.QuizServer
{
	public class ApplicationStartCommand : Command
	{
		[Inject]
		public ApplicationManager server{ get; set;}

		public override void Excute (object data)
		{
			server.Start ();
		}
	}
}

