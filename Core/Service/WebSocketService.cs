using System;
using SuperSocket.WebSocket;
using SuperSocket.SocketBase;
using Samurai.QuizServer;
using Samura.QuizServer;
using System.Security.Cryptography;

namespace Samurai.QuizServer
{
	public class WebSocketService : ISocketService
	{
		private WebSocketServer _socket;

		public WebSocketService ()
		{
			_socket = new WebSocketServer ();
			_socket.Setup (ServerConfig.ServerPort);

			_socket.NewSessionConnected += OnClientConnected;
			_socket.NewMessageReceived += OnReceiveClientMessage;
			_socket.SessionClosed += OnClientDisconnected;

		} 

		public void Start()
		{
			_socket.Start ();
		}

		public void Stop(){}

		private void OnClientConnected (WebSocketSession session)
		{
			//Console.WriteLine("Connected:"+session.SessionID);

			//Rfc2898DeriveBytes
		}

		private void OnReceiveClientMessage (WebSocketSession session, string value)
		{
			//throw new NotImplementedException ();
		}

		private void OnClientDisconnected (WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
		{
			//throw new NotImplementedException ();
			Console.WriteLine("OnClientDisconnected:"+
				session.SessionID);
		}
	}
}

