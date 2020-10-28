using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TicketingApp
{
    class IncidentsFile
    {
        public string incidentList { get; set; }
        public List<Incidents> Incidents { get; set; }

        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public IncidentsFile(string ticketListing)
        {
            incidentList = ticketListing;
            Incidents = new List<Incidents>();

            try
            {
                StreamReader ir = new StreamReader(incidentList);
                ir.ReadLine();
                while (!ir.EndOfStream)
                {
                    Incidents incident = new Incidents();
                    string iLine = ir.ReadLine();
                    string[] incidentDetails = iLine.Split(',');
                    incident.ticketId = UInt64.Parse(incidentDetails[0]);
                    incident.summary = incidentDetails[1];
                    incident.priority = incidentDetails[2];
                    incident.submitter = incidentDetails[3];
                    incident.assigned = incidentDetails[4];
                    incident.watching = incidentDetails[5].Split('|').ToList();
                    Incidents.Add(incident);
                }
                ir.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
        public void AddIncident(Incidents incidents){
            incidents.ticketId = Incidents.Max(inc => inc.ticketId) + 1;
            StreamWriter sw = new StreamWriter(incidentList, true);
            sw.WriteLine($"{incidents.ticketId},{incidents.summary},{incidents.priority}, {incidents.submitter}, {incidents.assigned}, {string.Join("|", incidents.watching)}");
            sw.Close();
            Incidents.Add(incidents);
            logger.Info("Incident {Id} added", incidents.ticketId);

        }
    }
}