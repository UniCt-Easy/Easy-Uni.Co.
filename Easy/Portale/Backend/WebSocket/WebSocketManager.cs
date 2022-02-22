
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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



using Microsoft.Web.WebSockets;
using Newtonsoft.Json.Linq;
using System.Net;
using Backend.CommonBackend;
using Backend.Data;
using Backend.WebSocket;
using System.Web;
using System.Web.Configuration;
using System;
using System.Collections.Generic;
using metadatalibrary;

namespace BackendWebSocket {
	public class WebSocketManager : WebSocketHandler {
		private static WebSocketCollection clients = new WebSocketCollection();
		private static Dispatcher dispatcher;

		public override void OnOpen() {

			// solo la prima invocazione isntanzio il dispatcher
			if (dispatcher == null) {
				dispatcher = new Dispatcher();
				dispatcher.createDbConnection();
			}

			clients.Add(this);
		}

		/// <summary>
		/// N.B obj js è 
		///    {
		///        method: "select",
		///        token:xxx,
		///        idRequest: xxxx,
		///        prm: { p1: "p1", p2: "p2"... }
		///   } 
		/// </summary>
		/// <param name="message"></param>
		public override void OnMessage(string message) {

			var objMessage = JObject.Parse(message);
			var method = ((JValue) objMessage["method"]).Value.ToString();
			var prms = (JObject) objMessage["prm"];

			// trasformo i prm in un JObject leggibile
			var prmsObject = JObject.Parse(prms.ToString());
			var idRequest = ((JValue) prmsObject["idRequest"]).Value;

			// inizializzo oggetto che smista le resolve notify o reject
			var IDataSender = new WSocketDataSender(this, idRequest, dispatcher);

			// TODO fare un routing più chiaro se possibile
			if (method == "select") {
				DataManager.selectAsync(prmsObject, IDataSender);
			}

			if (method == "multiRunSelect") {
				var selBuilderArr = prms["selBuilderArr"]?.ToString();
				var selList = DataUtils.getSelList(selBuilderArr, dispatcher);
				DataManager.multiRunSelect(selList, IDataSender);
			}

			// E' un metodo di test
			if (method == "testNotify") {
				DataManager.testNotify(prmsObject, IDataSender);
			}
		}

		public override void OnClose() {
			clients.Remove(this);
		}

		public void resolve(object data, object idRequest) {
			//invia data
			string answer = DataUtils.getJsonAnswer(idRequest.ToString(), "resolve", data);
			this.Send(answer);
		}

		public void notify(object data, object idRequest) {
			//invia data
			string answer = DataUtils.getJsonAnswer(idRequest.ToString(), "notify", data);
			this.Send(answer);
		}

		public void reject(HttpStatusCode code, object data, object idRequest) {
			string answer = DataUtils.getJsonAnswer(idRequest.ToString(), "reject", data, code.ToString());
			this.Send(answer);
		}

	}

}
