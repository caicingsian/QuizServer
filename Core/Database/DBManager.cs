using System;
using Samurai.MVCExpress;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using NLog;
using Samura.QuizServer;

namespace Samurai.QuizServer
{
	public class DBManager : Controller,IDBManager
	{
		private static Logger logger = LogManager.GetCurrentClassLogger ();

		public DBManager ()
		{

		}

		private string _connStr;

		public override void Initialize ()
		{
			base.Initialize ();

			string DB_IP = ServerConfig.DBIP;
			string DB_USERID = ServerConfig.DBUser;
			string DB_PASSWORD = ServerConfig.DBPassword;
			string DB_NAME = ServerConfig.DBName;  

			this._connStr = String.Format(
				"Data Source={0};" +
				"User Id={1};" +
				"Password={2};" +
				"Initial Catalog={3};" +
				"Connection Timeout=3"
				, DB_IP, DB_USERID, DB_PASSWORD, DB_NAME);

			Console.WriteLine (_connStr);
			Console.WriteLine (IsConnectable ());

		}

		private IDbConnection GetConn ()
		{
			return new SqlConnection (this._connStr);
		}

		public bool IsConnectable ()
		{
			using (var conn = GetConn ()) {
				try {
					conn.Open ();	
				} catch (Exception ex) {
					logger.Error (ex.Message);
					return false;
				}
			}
			return true;
		}
	}
}

