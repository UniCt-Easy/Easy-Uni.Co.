
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

namespace Chat.Client.Rocketchat.Serialization.UsersList {
    public class Email {
        public string address { get; set; }
        public bool verified { get; set; }
    }

    public class UsersListResult {
        public List<User> users { get; set; }
        public int count { get; set; }
        public int offset { get; set; }
        public int total { get; set; }
        public bool success { get; set; }
    }

    public class User {
        public string _id { get; set; }
        public string username { get; set; }
        public List<Email> emails { get; set; }
        public string type { get; set; }
        public List<string> roles { get; set; }
        public string status { get; set; }
        public bool active { get; set; }
        public string name { get; set; }
        public DateTime lastLogin { get; set; }
        public string nameInsensitive { get; set; }
        public string avatarETag { get; set; }
    }
}
