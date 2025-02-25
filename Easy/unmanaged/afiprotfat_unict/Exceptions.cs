
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace afiprotfat.Exceptions {

    public class InvalidDataException : Exception {
        public InvalidDataException() { }

        public InvalidDataException(string message) : base(message) { }

        public InvalidDataException(string message, Exception inner) : base(message, inner) { }
    }

    public class TypeException : Exception {
        public TypeException() { }

        public TypeException(string message) : base(message) { }

        public TypeException(string message, Exception inner) : base(message, inner) { }
    }

    public class AttachmentException : Exception {
        public AttachmentException() { }

        public AttachmentException(string message) : base(message) { }

        public AttachmentException(string message, Exception inner) : base(message, inner) { }
    }

    public class OfficeIdException : Exception {
        public OfficeIdException() { }

        public OfficeIdException(string message) : base(message) { }

        public OfficeIdException(string message, Exception inner) : base(message, inner) { }
    }

    public class RequestBuildingException : Exception {
        public RequestBuildingException() { }

        public RequestBuildingException(string message) : base(message) { }

        public RequestBuildingException(string message, Exception inner) : base(message, inner) { }
    }

    public class ResponseDeserializationException : Exception {
        public ResponseDeserializationException() { }

        public ResponseDeserializationException(string message) : base(message) { }

        public ResponseDeserializationException(string message, Exception inner) : base(message, inner) { }
    }

    public class CommunicationException : Exception {
        public CommunicationException() { }

        public CommunicationException(string message) : base(message) { }

        public CommunicationException(string message, Exception inner) : base(message, inner) { }
    }

    public class ServerException : Exception {
        public ServerException() { }

        public ServerException(string message) : base(message) { }

        public ServerException(string message, Exception inner) : base(message, inner) { }
    }
}

