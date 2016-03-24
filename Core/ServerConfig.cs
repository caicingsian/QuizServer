using System;

namespace Samura.QuizServer
{
	public class ServerConfig
	{
		public static int ServerPort = 8000;
		public static string DBIP = "";
		public static string DBUser = "";
		public static string DBPassword = "";
		public static string DBName = "";

		public ServerConfig ()
		{
			
		}

		static public void Init()
		{
			DBIP = System.Configuration.ConfigurationManager.AppSettings ["DBIP"];
			DBUser = System.Configuration.ConfigurationManager.AppSettings ["DBUSER"];
			DBPassword = System.Configuration.ConfigurationManager.AppSettings ["DBPASSWORD"];
			DBName = System.Configuration.ConfigurationManager.AppSettings ["DBNAME"];
		}
	}
}

