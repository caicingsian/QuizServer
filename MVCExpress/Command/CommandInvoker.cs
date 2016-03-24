using System;
using Ninject;
using System.Collections.Generic;

namespace Samurai.MVCExpress
{
	public class CommandInvoker
	{
		private IKernel _kernel;
		private Dictionary<string,Type> _commandmMap;

		public CommandInvoker (IKernel kernel)
		{
			_kernel = kernel;
			_commandmMap = new Dictionary<string, Type> ();

		}

		public void Map (string type, Type command, bool pooled = false)
		{
			_commandmMap.Add (type, command);
			if (pooled)
				_kernel.Bind (command).ToSelf ().InSingletonScope ();
			else
				_kernel.Bind (command).ToSelf ();
		}

		public void Unmap (string type)
		{
			if (_commandmMap.ContainsKey (type))
				_commandmMap.Remove (type);
		}

		public void Excute (string type, object data)
		{
			if (_commandmMap.ContainsKey (type)) 
			{
				Type commandType = _commandmMap[type];
				var command = _kernel.Get(commandType);
				if (command != null && command is ICommand)
					(command as ICommand).Excute (data);
			}
		}
	}
}

