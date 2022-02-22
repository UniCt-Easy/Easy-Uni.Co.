
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


using Backend.Data;
using Backend.CommonBackend;
using BackendWebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Backend.WebSocket {
	public class WSocketDataSender : IDataSender {
		List<object> data = new List<object>();

		public WebSocketManager wm;

		private object _idRequest;

		public object IdRequest {
			get { return _idRequest; }
			set { _idRequest = value; }
		}

		private Dispatcher _dispatcher;

		public Dispatcher dispatcher {
			get { return _dispatcher; }
			set { _dispatcher = value; }
		}


		public WSocketDataSender(WebSocketManager wmPrm, object idRequest, Dispatcher dispatcher) {
			this.wm = wmPrm;
			this._idRequest = idRequest;
			this._dispatcher = dispatcher;
		}

		public void resolve(object data) {
			this.data.Clear();
			this.data.Add(data);
			wm.resolve(this.data, _idRequest);

		}

		public void notify(object data) {
			this.data.Clear();
			this.data.Add(data);
			wm.notify(this.data, _idRequest);

		}

		public void reject(HttpStatusCode code, object data) {
			//invia data
			this.data.Add(data);
			wm.reject(code, this.data, _idRequest);
		}

	}
}
