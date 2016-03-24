using System;

namespace Samurai.MVCExpress
{
	public class Command : ICommand
	{
		public Command ()
		{
		}

		#region ICommand implementation

		virtual public void Excute ( object data )
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

