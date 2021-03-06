﻿using System;
using NLog.Web; 
using System.IO;
using System.Linq;

namespace TicketingApp
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Info("Program started");
            string incidentPathFile = Directory.GetCurrentDirectory() + "\\Tickets.csv";
            logger.Info(incidentPathFile);
            string enhancementPathFile = Directory.GetCurrentDirectory() +  "\\Enhancements.csv";
            logger.Info(enhancementPathFile);
            string taskPathFile = Directory.GetCurrentDirectory() + "\\Tasks.csv";
            logger.Info(taskPathFile);

            IncidentsFile incidentsFile = new IncidentsFile(incidentPathFile);
            EnhancementsFile enhancementsFile = new EnhancementsFile(enhancementPathFile);
            TasksFile tasksFile = new TasksFile(taskPathFile);

            string choice = "";
            do
            {
                // ask user a question
                Console.WriteLine("1) Create ticket");
                Console.WriteLine("2) Read data from file.");
                Console.WriteLine("3) Search for ticket");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                        string tChoice = "";

                        Console.WriteLine("What kind of ticket are you submitting?");
                        Console.WriteLine("1) Incident");
                        Console.WriteLine("2) Enhancement");
                        Console.WriteLine("3) Task");
                        tChoice = Console.ReadLine();

                        if (tChoice == "1")
                        {    
                            Incidents incident = new Incidents();
                    
                            // short summary of issue
                            Console.WriteLine("Please enter the summary of the issue:");
                            // save the summary
                            incident.summary = Console.ReadLine();
                            // prompt for ticket status
                            Console.WriteLine("What is the ticket status? (Open/Resolved)");
                            // save the course grade
                            incident.status = Console.ReadLine();
                            // enter pritority of ticket
                            Console.WriteLine("What is the priority of this ticket? (Low/Med/High)");
                            // save priority level
                            incident.priority = Console.ReadLine();
                            // prompt name of submitter
                            Console.WriteLine("Who is submitting this ticket?");
                            incident.submitter = Console.ReadLine();
                            // name of assigned analyst
                            Console.WriteLine("Who is assigned this ticket?");
                            incident.assigned = Console.ReadLine();
                            // name of person watching this ticket
                            Console.WriteLine("Who is watching this ticket?");
                            string watchers;
                            do
                            {
                                Console.WriteLine("Enter ticket watchers. Enter done to move on");
                                watchers = Console.ReadLine();
                                if (watchers != "done" && watchers.Length > 0){
                                    incident.watching.Add(watchers);
                                }
                            } while (watchers != "done");
                            if (incident.watching.Count == 0){
                                incident.watching.Add("(No one is watching this ticket)");
                            }
                            // serverity of issue
                            Console.WriteLine("What is the serverity of this issue?");
                            incident.severity = Console.ReadLine();
                            incidentsFile.AddIncident(incident);
                        }
                        else if (tChoice == "2")
                        {
                            Enhancements enhancement = new Enhancements();
                            Console.WriteLine("Please enter the summary of the issue:");
                            // save the summary
                             enhancement.summary = Console.ReadLine();
                            // prompt for ticket status
                            Console.WriteLine("What is the ticket status? (Open/Resolved)");
                            // save the course grade
                            enhancement.status = Console.ReadLine();
                            // enter pritority of ticket
                            Console.WriteLine("What is the priority of this ticket? (Low/Med/High)");
                            // save priority level
                             enhancement.priority = Console.ReadLine();
                            // prompt name of submitter
                            Console.WriteLine("Who is submitting this ticket?");
                            enhancement.submitter = Console.ReadLine();
                            // name of assigned analyst
                            Console.WriteLine("Who is assigned this ticket?");
                            enhancement.assigned = Console.ReadLine();
                            // name of person watching this ticket
                            Console.WriteLine("Who is watching this ticket?");
                            string watchers;
                            do
                            {
                                Console.WriteLine("Enter ticket watchers. Enter done to move on");
                                watchers = Console.ReadLine();
                                if (watchers != "done" && watchers.Length > 0){
                                    enhancement.watching.Add(watchers);
                                }
                            } while (watchers != "done");
                            if (enhancement.watching.Count == 0){
                                enhancement.watching.Add("(No one is watching this ticket)");
                            }
                            Console.WriteLine("What software requires enhancement?");
                            enhancement.software = Console.ReadLine();
                            Console.WriteLine("Why does this software require enhancement?");
                            enhancement.reason = Console.ReadLine();
                            Console.WriteLine("Estimated Cost?");
                            enhancement.costEstimate = Console.ReadLine();
                            enhancementsFile.AddEnhancements(enhancement);                            

                        }
                        else if (tChoice == "3")
                        {
                            Tasks tasks = new Tasks();
                            Console.WriteLine("Please enter the summary of the issue:");
                            // save the summary
                            tasks.summary = Console.ReadLine();
                            // prompt for ticket status
                            Console.WriteLine("What is the ticket status? (Open/Resolved)");
                            // save the course grade
                            tasks.status = Console.ReadLine();
                            // enter pritority of ticket
                            Console.WriteLine("What is the priority of this ticket? (Low/Med/High)");
                            // save priority level
                            tasks.priority = Console.ReadLine();
                            // prompt name of submitter
                            Console.WriteLine("Who is submitting this ticket?");
                            tasks.submitter = Console.ReadLine();
                            // name of assigned analyst
                            Console.WriteLine("Who is assigned this ticket?");
                            tasks.assigned = Console.ReadLine();
                            // name of person watching this ticket
                            Console.WriteLine("Who is watching this ticket?");
                            string watchers;
                            do
                            {
                                Console.WriteLine("Enter ticket watchers. Enter done to move on");
                                watchers = Console.ReadLine();
                                if (watchers != "done" && watchers.Length > 0){
                                    tasks.watching.Add(watchers);
                                }
                            } while (watchers != "done");
                            if (tasks.watching.Count == 0){
                                tasks.watching.Add("(No one is watching this ticket)");
                            }
                            Console.WriteLine("What is the project name associated with this task?");
                            tasks.projectName = Console.ReadLine();
                            Console.WriteLine("What is the due date for this task?");
                            tasks.dueDate = Console.ReadLine();
                            tasksFile.AddTasks(tasks);                            

                        }


                }
                else if (choice == "2")
                {
                    Console.WriteLine("Which data would you like to view?");
                    Console.WriteLine("1) Incidents");
                    Console.WriteLine("2) Enhancements");
                    Console.WriteLine("3) Tasks");
                    string dataChoice = Console.ReadLine();
                    if (dataChoice == "1"){
                        foreach (Incidents inc in incidentsFile.Incidents)
                        {
                            Console.WriteLine(inc.Display());
                        }
                    } 
                    else if (dataChoice == "2"){
                        foreach (Enhancements enh in enhancementsFile.Enhancements)
                        {
                            Console.WriteLine(enh.Display());
                        }
                    }
                    else if (dataChoice == "3"){
                        foreach (Tasks task in tasksFile.Tasks)
                        {
                            Console.WriteLine(task.Display());
                        }                       
                    }
                   
                }

                else if (choice == "3"){
                    Console.WriteLine("Are you looking for tickets based on status, priority, or submitter?");
                    Console.WriteLine("1) Status");
                    Console.WriteLine("2) Priority");
                    Console.WriteLine("3) Submitter");
                    string lookUp = Console.ReadLine();
                    if (lookUp == "1"){
                        Console.WriteLine("Please enter status (Open/Resolved)");
                        string statusLookup = Console.ReadLine();
                        var incidentStatus = incidentsFile.Incidents.Where(i => i.status.Contains(statusLookup)).Select(i => i.status); 
                        var enhancementStatus = enhancementsFile.Enhancements.Where(e => e.status.Contains(statusLookup)).Select(e => e.status);
                        var taskStatus = tasksFile.Tasks.Where(t => t.status.Contains(statusLookup)).Select(t => t.status);
                        Console.WriteLine($"There are {incidentStatus.Count() + enhancementStatus.Count() + taskStatus.Count()} tickets with that status code");
                    }
                    else if (lookUp == "2"){
                        Console.WriteLine("Please enter priority (Low/Med/High)");
                        string priorityLookup = Console.ReadLine();
                        var incidentPriority = incidentsFile.Incidents.Where(i => i.priority.Contains(priorityLookup)).Select(i => i.priority); 
                        var enhancementPriority = enhancementsFile.Enhancements.Where(e => e.priority.Contains(priorityLookup)).Select(e => e.priority);
                        var taskPriority = tasksFile.Tasks.Where(t => t.priority.Contains(priorityLookup)).Select(t => t.priority);
                        Console.WriteLine($"There are {incidentPriority.Count() + enhancementPriority.Count() + taskPriority.Count()} tickets with that status code");
                    }
                    else if (lookUp == "3"){
                        Console.WriteLine("Please enter the name of the submitter");
                        string submitterLookup = Console.ReadLine();
                        var incidentSub = incidentsFile.Incidents.Where(i => i.submitter.Contains(submitterLookup)).Select(i => i.submitter); 
                        var enhancementSub = enhancementsFile.Enhancements.Where(e => e.submitter.Contains(submitterLookup)).Select(e => e.submitter);
                        var taskSub = tasksFile.Tasks.Where(t => t.submitter.Contains(submitterLookup)).Select(t => t.submitter);
                        Console.WriteLine($"There are {incidentSub.Count() + enhancementSub.Count() + taskSub.Count()} tickets submitted by that user");
                    }
                  
                }
            } while (choice == "1" || choice == "2" || choice == "3");


            logger.Info("Program ended");
        }
    }
}
