
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

namespace Chat.Client.Rocketchat.Serialization.ChannelsList {
    public class Channel {
        public string _id { get; set; }
        public string name { get; set; }
        public string t { get; set; }
        public List<string> usernames { get; set; }
        public int msgs { get; set; }
        public U u { get; set; }
        public DateTime ts { get; set; }
        public bool ro { get; set; }
        public bool sysMes { get; set; }
        public DateTime _updatedAt { get; set; }
    }

    public class ChannelsListResult {
        public List<Channel> channels { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public int total { get; set; }
        public bool success { get; set; }
    }

    public class U {
        public string _id { get; set; }
        public string username { get; set; }
    }
}
