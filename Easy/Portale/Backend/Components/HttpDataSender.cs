
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Backend.Components {

    /// <summary>
    /// Represents a service result
    /// </summary>
    public class ObjHttpDataSender {
        public string answer;
        public HttpStatusCode code;



        public ObjHttpDataSender(HttpStatusCode code, string answer) {
            this.code = code;
            this.answer = answer;
        }
    }

    public interface IHttpDataSender : IDataSender {
        Task<ObjHttpDataSender> getResult();
    }


    /// <summary>
    /// Implements IDataSender for http channel
    /// </summary>
    public class HttpDataSender : IHttpDataSender {
        SemaphoreSlim autoEvent;
        private ObjHttpDataSender result;

        private readonly List<object> _data = new List<object>();
        private object _idRequest;
        private bool partialData = false;

        /// <summary>
        /// 
        /// </summary>
        public object IdRequest {
            get { return _idRequest; }
            set { _idRequest = value; }
        }

        private Dispatcher _dispatcher;

        /// <summary>
        /// 
        /// </summary>
        public Dispatcher dispatcher {
            get { return _dispatcher; }
            set { _dispatcher = value; }
        }

        /// <summary>
        /// Wait for the result to be completed 
        /// </summary>
        /// <returns></returns>
        public async Task<ObjHttpDataSender> getResult() {
            await Task.Run(() => {
                autoEvent.Wait();
                autoEvent.Release();
            });
            return result;
        }

        /// <summary>
        /// Create an HttpDataSender
        /// </summary>
        /// <param name="idRequest"></param>
        /// <param name="dispatcher"></param>
        public HttpDataSender(object idRequest, Dispatcher dispatcher) {
            this._idRequest = idRequest;
            this._dispatcher = dispatcher;
            autoEvent = new SemaphoreSlim(1, 1);
            autoEvent.Wait(); //locks the resource
        }

        /// <summary>
        /// Appends data to the result
        /// </summary>
        /// <param name="d"></param>
        public void notify(object d) {
            _data.Add(d);
            partialData = true;
        }

        /// <summary>
        /// Sends an error message to the client
        /// </summary>
        /// <param name="code"></param>
        /// <param name="d"></param>
        public void reject(HttpStatusCode code, object d) {
            var answer = DataUtils.getJsonAnswer(_idRequest.ToString(), "reject", d);
            result = new ObjHttpDataSender(code, answer);
            autoEvent.Release();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        public void resolve(object d) {
            if (partialData && d != null) {
                throw new ArgumentException(
                    "When returning multiple data, resolve must be called with a null parameter");
            }

            if (d != null) _data.Add(d);
            var answer = DataUtils.getJsonAnswer(_idRequest.ToString(), "resolve", _data);
            result = new ObjHttpDataSender(HttpStatusCode.OK, answer);
            autoEvent.Release();
        }

    }


}


