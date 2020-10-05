using System;
using NLog.Web; 
using System.IO;
using System.Collections.Generic;

namespace TicketingApp
{
    class ReadWrite
    {
        public List<Incidents> Incidents {get; set;}
        public string listPopulate {get; set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public ReadWrite(string ticketListing)
        {
            listPopulate = ticketListing;
            Incidents = new List<Incidents>();

            try
            {
                
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}