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
                StreamReader er = new StreamReader(enhancementList);
                while (!er.EndOfStream)
                {
                    Enhancements enhancement = new Enhancements();
                    string iLine = er.ReadLine();
                    int idx = iLine.IndexOf('"');
                    if (idx == -1)
                    {
                        string[] enhancementDetails = iLine.Split(',');
                        enhancement.ticketId = UInt64.Parse(enhancementDetails[0]);
                        enhancement.summary = enhancementDetails[1];
                        enhancement.status = enhancementDetails[2];
                        enhancement.priority = enhancementDetails[3];
                        enhancement.submitter = enhancementDetails[4];
                        enhancement.assigned = enhancementDetails[5];
                        enhancement.watching = enhancementDetails[6].Split('|').ToList();
                        enhancement.software = enhancementDetails[7];
                        enhancement.reason = enhancementDetails[8];
                        enhancement.costEstimate = enhancementDetails[9];
                    }
                    Enhancements.Add(enhancement);
                }
                er.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        public void AddEnhancements(Enhancements enhancement)
        {
            enhancement.ticketId = Enhancements.Count() == 0 ? 1 : Enhancements.Max(inc => inc.ticketId) + 1;
            StreamWriter sw = new StreamWriter(enhancementList, true);
            sw.WriteLine($"{enhancement.ticketId},{enhancement.summary},{enhancement.priority}, {enhancement.submitter}, {enhancement.assigned}, {string.Join("|", enhancement.watching)}, {enhancement.software}, {enhancement.reason}, {enhancement.costEstimate}");
            sw.Close();
            Enhancements.Add(enhancement);
            logger.Info("enhancement {Id} added", enhancement.ticketId);
        }
    }
}