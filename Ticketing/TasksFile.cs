using System;
using NLog.Web; 
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TicketingApp
{
    class TasksFile
    {
        public string taskList {get; set;}
        public List<Tasks> Tasks {get; set;}

        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public TasksFile(string ticketListing)
        {
            taskList = ticketListing;
            Tasks = new List<Tasks>();

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