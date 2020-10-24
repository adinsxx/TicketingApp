using System;
using NLog.Web; 
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TicketingApp
{
    class IncidentsFile
    {
        public string incidentList {get; set;}
        public List<Incidents> Incidents {get; set;}

        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public IncidentsFile(string ticketListing)
        {
            incidentList = ticketListing;
            Incidents = new List<Incidents>();

            try
            {
                StreamReader ir = new StreamReader(incidentList);
                ir.ReadLine();
                while(!ir.EndOfStream){
                    Incidents incident = new Incidents();
                    string iLine = ir.ReadLine();
                    int idx = iLine.IndexOf('"');
                    if (idx == -1){
                        string[] incidentDetails = iLine.Split(',');
                        incident.ticketId = UInt64.Parse(incidentDetails[0]);
                        incident.summary = incidentDetails[1];
                        incident.priority = incidentDetails[2];
                    }
                    Incidents.Add(incident);
                }
                ir.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}