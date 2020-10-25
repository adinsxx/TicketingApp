using System;
using NLog.Web; 
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TicketingApp
{
    class EnhancementsFile
    {
        public string enhancementList {get; set;}
        public List<Enhancements> Enhancements {get; set;}

        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public EnhancementsFile(string ticketListing)
        {
            enhancementList = ticketListing;
            Enhancements = new List<Enhancements>();

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