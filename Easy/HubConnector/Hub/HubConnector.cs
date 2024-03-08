
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


using Microsoft.AspNet.SignalR.Client;
using System;
using System.Data;

namespace HubConnector
{
	public delegate void ActionCaller(byte[] reportContents);
	public delegate void ActionError(string msg);

	public sealed class HubConn
	{
		private static HubConn _instance;

		private HubConnection hubConnection;

		public IHubProxy HubProxy;

		public static HubConn GetInstance(ActionCaller actionCaller, ActionError actionError, string HubServiceUrl, string HubName, string FunctionCaller, string FunctionError)
		{
			if (_instance == null)
			{
				_instance = new HubConn(actionCaller, actionError, HubServiceUrl, HubName, FunctionCaller, FunctionError);
			}
			return _instance;
		}
		
		// ========================================================================
		// Check Is Connected
		// ========================================================================
		public bool isConnected()
		{
			return hubConnection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected;
		}

		// ========================================================================
		// Hub Service
		// ========================================================================
		private HubConn(ActionCaller actionCaller, ActionError actionError, string HubServiceUrl, string HubName, string FunctionCaller, string FunctionError)
		{
			try
			{
				// Nuovo Hub
				hubConnection = new HubConnection(HubServiceUrl);

				// Crea Proxy
				HubProxy = hubConnection.CreateHubProxy(HubName);

				// Funzione da chiamare sul client quando si ricevono i dati
				HubProxy.On<byte[]>(FunctionCaller, pdfBytes => { actionCaller.Invoke(pdfBytes); });

				// Funzione da chiamare sul client quando si riceve errore
				HubProxy.On<string>(FunctionError, msg => { actionError.Invoke(msg); });

				// Start della connection
				hubConnection.Start().Wait();
			}
			catch { }
		}

		public void Generate(string HubMethod, DataRow moduleReport, DataRow parameters)
		{

			// Nuovo Report Request
			ReportRequest rr = new ReportRequest()
			{
				Report = moduleReport.ToHashtable(),		// conversione della DataRow in Hashtable
				ReportParameter = parameters.ToHashtable(), // conversione della DataRow in Hashtable
			};

			// Serializzazione della Report Request
			string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(rr);

			// Invoca il metodo
			HubProxy.Invoke(HubMethod, jsonData);
		}
	}
}
