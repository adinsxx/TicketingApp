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

        public IncidentsFile(string incidentFileListing)
        {
            incidentList = incidentFileListing;
            Incidents = new List<Incidents>();

            try
            {
                StreamReader ir = new StreamReader(incidentList);
                while (!ir.EndOfStream)
                {
                    Incidents incident = new Incidents();
                    string iLine = ir.ReadLine();
                    int idx = iLine.IndexOf('"');
                    if (idx == -1)
                    {
                        string[] incidentDetails = iLine.Split(',');
                        incident.ticketId = UInt64.Parse(incidentDetails[0]);
                        incident.summary = incidentDetails[1];
                        incident.status = incidentDetails[2];
                        incident.priority = incidentDetails[3];
                        incident.submitter = incidentDetails[4];
                        incident.assigned = incidentDetails[5];
                        incident.watching = incidentDetails[6].Split('|').ToList();
                        incident.severity = incidentDetails[7];
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
        public void AddIncident(Incidents incident){
            //tiertiary conditional if count = 0, change to 1 or add 1
            incident.ticketId = Incidents.Count() == 0 ? 1 : Incidents.Max(inc => inc.ticketId) + 1;
            StreamWriter sw = new StreamWriter(incidentList, true);
            sw.WriteLine($"{incident.ticketId},{incident.summary},{incident.priority}, {incident.submitter}, {incident.assigned}, {string.Join("|", incident.watching)}");
            sw.Close();
            Incidents.Add(incident);
            logger.Info("Incident {Id} added", incident.ticketId);
        }
    }
}