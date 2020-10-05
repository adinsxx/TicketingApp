using System;
using NLog.Web; 
using System.IO;
using System.Collections.Generic;

namespace TicketingApp
{
    public abstract class Ticket {
        public UInt64 ticketId{get; set;}
        public string summary{get; set;}
        public string priority {get; set;}
        public string submitter {get; set;}
        public string assigned {get; set;}
        public List<string> watching {get; set;}

        public Ticket(){
            watching = new List<string>();
        }

        public virtual string Display(){
        return $"ID: {ticketId}\nSummary: {summary}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\n";
        }
    }
    public class Incidents : Ticket
    {
        public string severity {get; set;}
        public override string Display(){
        return $"ID: {ticketId}\nSummary: {summary}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\nSeverity: {severity}";  
        }
    }



    //public class Enhancements : Ticket
    //public class Tasks : Ticket
}