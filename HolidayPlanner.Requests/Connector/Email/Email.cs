﻿using System.Collections.Generic;

namespace HolidayPlanner.Requests
{
    public class Email
    {
        public Email()
        {
            ReceiverCollection=new List<string>();
        }

        public List<string> ReceiverCollection { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}