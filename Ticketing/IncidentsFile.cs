using System;
using NLog.Web; 
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TicketingApp
{
    class IncidentsFile
    {
        public List<Incidents> Incidents {get; set;}
        public string listPopulate {get; set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public IncidentsFile(string ticketListing)
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