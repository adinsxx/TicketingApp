using System;
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
            string incidentPathFile = "Tickets.csv";
            logger.Info(incidentPathFile);
            // string enhancementPathFile = Directory.GetCurrentDirectory() +  "\\Enhancements.csv";
            // string taskPathFile = Directory.GetCurrentDirectory() + "\\Tasks.csv";

            IncidentsFile incidentsFile = new IncidentsFile(incidentPathFile);
            // EnhancementsFile enhancementsFile = new EnhancementsFile(enhancementPathFile);
            // TasksFile tasksFile = new TasksFile(taskPathFile);

            string choice = "";
            do
            {
                // ask user a question
                Console.WriteLine("1) Create ticket");
                Console.WriteLine("2) Read data from file.");
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
                            Incidents incidents = new Incidents();                    
                            // short summary of issue
                            Console.WriteLine("Please enter the summary of the issue:");
                            // save the summary
                            string summary = Console.ReadLine();
                            // prompt for ticket status
                            Console.WriteLine("What is the ticket status? (Open/Resolved)");
                            // save the course grade
                            string status = Console.ReadLine();
                            // enter pritority of ticket
                            Console.WriteLine("What is the priority of this ticket? (Low/Med/High)");
                            // save priority level
                            string priority = Console.ReadLine();
                            // prompt name of submitter
                            Console.WriteLine("Who is submitting this ticket?");
                            string submitter = Console.ReadLine();
                            // name of assigned analyst
                            Console.WriteLine("Who is assigned this ticket?");
                            string assigned = Console.ReadLine();
                            // name of person watching this ticket
                            Console.WriteLine("Who is watching this ticket?");
                            string watching = Console.ReadLine();
                            // serverity of issue
                            Console.WriteLine("What is the serverity of this issue?");
                            string serverity = Console.ReadLine();
                            incidentsFile.AddIncident(incidents);
                        }
                        else if (tChoice == "2")
                        {
                            Enhancements enhancements = new Enhancements();
                            // input the response
                            string resp = Console.ReadLine().ToUpper();
                            // if the response is anything other than "Y", stop asking
                            if (resp != "Y") { break; }                      
                            // short summary of issue
                            Console.WriteLine("Please enter the summary of the issue:");
                            // save the summary
                            string summary = Console.ReadLine();
                            // prompt for ticket status
                            Console.WriteLine("What is the ticket status? (Open/Resolved)");
                            // save the course grade
                            string status = Console.ReadLine();
                            // enter pritority of ticket
                            Console.WriteLine("What is the priority of this ticket? (Low/Med/High)");
                            // save priority level
                            string priority = Console.ReadLine();
                            // prompt name of submitter
                            Console.WriteLine("Who is submitting this ticket?");
                            string submitter = Console.ReadLine();
                            // name of assigned analyst
                            Console.WriteLine("Who is assigned this ticket?");
                            string assigned = Console.ReadLine();
                            // name of person watching this ticket
                            Console.WriteLine("Who is watching this ticket?");
                            string watchers;
                            do
                            {
                                Console.WriteLine("Enter ticket watchers. Enter done to move on");
                                watchers = Console.ReadLine();
                                if (watchers != "done" && watchers.Length > 0){
                                    enhancements.watching.Add(watchers);
                                }
                            } while (watchers != "done");
                            if (enhancements.watching.Count == 0){
                                enhancements.watching.Add("(No one is watching this ticket");
                            }
                            string watching = Console.ReadLine();
                            Console.WriteLine("What software requires enhancement?");
                            string software = Console.ReadLine();
                            Console.WriteLine("Why does this software require enhancement?");
                            string reason = Console.ReadLine();
                            Console.WriteLine("Estimated Cost?");
                            int cost = Console.Read();

                        }
                        else if (tChoice == "3")
                        {
                            Tasks tasks = new Tasks();
                            // input the response
                            string resp = Console.ReadLine().ToUpper();
                            // if the response is anything other than "Y", stop asking
                            if (resp != "Y") { break; }                      
                            // short summary of issue
                            Console.WriteLine("Please enter the summary of the issue:");
                            // save the summary
                            string summary = Console.ReadLine();
                            // prompt for ticket status
                            Console.WriteLine("What is the ticket status? (Open/Resolved)");
                            // save the course grade
                            string status = Console.ReadLine();
                            // enter pritority of ticket
                            Console.WriteLine("What is the priority of this ticket? (Low/Med/High)");
                            // save priority level
                            string priority = Console.ReadLine();
                            // prompt name of submitter
                            Console.WriteLine("Who is submitting this ticket?");
                            string submitter = Console.ReadLine();
                            // name of assigned analyst
                            Console.WriteLine("Who is assigned this ticket?");
                            string assigned = Console.ReadLine();
                            // name of person watching this ticket
                            Console.WriteLine("Who is watching this ticket?");
                            string watching = Console.ReadLine();
                            Console.WriteLine("What is the project name associated with this task?");
                            string projectName = Console.ReadLine();
                            Console.WriteLine("What is the due date for this task?");
                            string dueDate = Console.ReadLine();
                        }


                }
                else if (choice == "2")
                {
                    Console.WriteLine("Which data would you like to view?");
                    Console.WriteLine("1) Incidents");
                    Console.WriteLine("2) Enhancements");
                    Console.WriteLine("3) Tasks");
                    string dataChoice = Console.ReadLine();
                    // if (dataChoice == "1"){
                    //     foreach (Incidents inc in incidentsFile.Incidents)
                    //     {
                    //         Console.WriteLine(inc.Display());
                    //     }
                    // } 
                    // else if (dataChoice == "2"){
                    //     foreach (Enhancements enh in enhancementsFile.Enhancements)
                    //     {
                    //         Console.WriteLine(enh.Display());
                    //     }
                    // }
                    // else if (dataChoice == "3"){
                    //     foreach (Tasks task in tasksFile.Tasks)
                    //     {
                    //         Console.WriteLine(task.Display());
                    //     }                       
                    // }

                    switch (dataChoice)
                    {
                    case "1":
                        foreach (Incidents inc in incidentsFile.Incidents)
                        {
                            Console.WriteLine(inc.Display());
                        }
                    break;
                    // case "2":
                    //     foreach (Enhancements enh in enhancementsFile.Enhancements)
                    //     {
                    //         Console.WriteLine(enh.Display());
                    //     }
                    // break;
                    // case "3":
                    //     foreach (Tasks task in tasksFile.Tasks)
                    //     {
                    //         Console.WriteLine(task.Display());
                    //     }
                    // break;  
                    }
                   
                }
            } while (choice == "1" || choice == "2");


            logger.Info("Program ended");
        }
    }
}
