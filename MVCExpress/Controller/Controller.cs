using System;
using Ninject;

namespace Samurai.MVCExpress
{
	public class Controller : IInitializable, IStartable
	{
		[Inject]
		public Notifier notifier{get; set;}

		public Controller ()
		{
			
		}

		virtual public void Initialize ()
		{

		}

		virtual public void Start()
		{

		}

		virtual public void Stop ()
		{
			
		}
	}
}

