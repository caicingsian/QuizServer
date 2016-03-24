using System;
using System.Timers;
using NLog;
using Ninject;
using System.Reflection;
using QuizServer;
using Samurai.Utils;
using Samurai.MVCExpress;
using Samura.QuizServer;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Samurai.QuizServer
{
	public class MainModule : MainCore
	{
		private static Logger logger = LogManager.GetCurrentClassLogger ();

		private const string _readPrompt = "console>";
		private bool _isApplicationExit = false;

		public MainModule ()
		{
			
		}

		public override void OnInit ()
		{
			base.OnInit ();

			ServerConfig.Init ();

			_commandInvoker.Map (CommandType.ApplicationStart, typeof(ApplicationStartCommand), false);

			_kernal.Bind<ApplicationManager> ().To<ApplicationManager>().InSingletonScope ();
			_kernal.Bind<PlayerManager> ().ToSelf ().InSingletonScope ();
			_kernal.Bind<IHttpService> ().To<HttpService> ().InSingletonScope ();
			_kernal.Bind<ISocketService> ().To<WebSocketService> ().InSingletonScope ();
			_kernal.Bind<ServerSocketController> ().ToSelf ().InSingletonScope ();
			_kernal.Bind<IDBManager> ().To<DBManager> ().InSingletonScope ();
			_kernal.Bind<TimerManager> ().ToConstant (new TimerManager (100));

		}

		public override void Start ()
		{
			base.Start ();
			Console.WriteLine ("Server Initializing");

//			int saltSize = 16;
//			int bytesRequired = 32;
//			byte[] array = new byte[1 + saltSize + bytesRequired];
//			int iterations = 1000; // 1000, afaik, which is the min recommended for Rfc2898DeriveBytes
//			using (var pbkdf2 = new Rfc2898DeriveBytes("aA12345", saltSize, iterations))
//			{
//				byte[] salt = pbkdf2.Salt;        
//				Buffer.BlockCopy(salt, 0, array, 1, saltSize);
//				byte[] bytes = pbkdf2.GetBytes(bytesRequired);
//				Buffer.BlockCopy(bytes, 0, array, saltSize+1, bytesRequired);
//			}
//			Console.WriteLine (Convert.ToBase64String (array));

			_commandInvoker.Excute (CommandType.ApplicationStart, null);
			Run ();
		}

		public override void Exit ()
		{
			base.Exit ();
			_isApplicationExit = true;
		}

		private void Run ()
		{
			while (true) {  

				if (_isApplicationExit)
					break;

				var consoleInput = ReadFromConsole ();

				if (string.IsNullOrWhiteSpace (consoleInput))
					continue;

				switch (consoleInput) {
				case "clear" :
					Console.Clear ();
					break;
				}

				try {
					_commandInvoker.Excute (consoleInput, null);
				} catch (Exception ex) {
					logger.Error (ex.Message);
				}
			}
		}

		public static string ReadFromConsole (string promptMessage = "")
		{
			Console.Write (_readPrompt + promptMessage);
			return Console.ReadLine ();
		}
	}
}

