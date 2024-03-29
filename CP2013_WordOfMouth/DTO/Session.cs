﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_WordOfMouth.DTO
{
    public class Session
    {
        private long sessionID;
        private string username;
        private bool admin;

        public Session(long sessionID, string username, bool admin)
        {
            this.sessionID = sessionID;
            this.username = username;
            this.admin = admin;
        }

        public long GetSessionID()
        {
            return sessionID;
        }

        public string GetUsername()
        {
            return username;
        }

        public bool GetAdmin()
        {
            return admin;
        }
    }
}
