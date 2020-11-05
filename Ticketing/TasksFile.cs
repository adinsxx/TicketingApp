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
                StreamReader tr = new StreamReader(taskList);
                while (!tr.EndOfStream)
                {
                    Tasks task = new Tasks();
                    string iLine = tr.ReadLine();
                    int idx = iLine.IndexOf('"');
                    if (idx == -1)
                    {
                        string[] taskDetails = iLine.Split(',');
                        task.ticketId = UInt64.Parse(taskDetails[0]);
                        task.summary = taskDetails[1];
                        task.status = taskDetails[2];
                        task.priority = taskDetails[3];
                        task.submitter = taskDetails[4];
                        task.assigned = taskDetails[5];
                        task.watching = taskDetails[6].Split('|').ToList();
                        task.projectName = taskDetails[7];
                        task.dueDate = taskDetails[8];
                    }
                    Tasks.Add(task);
                }
                tr.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }


        }
            public void AddTasks(Tasks task){
            //tiertiary conditional if count = 0, change to 1 or add 1
            task.ticketId = Tasks.Count() == 0 ? 1 : Tasks.Max(inc => inc.ticketId) + 1;
            StreamWriter sw = new StreamWriter(taskList, true);
            sw.WriteLine($"{task.ticketId},{task.summary},{task.priority}, {task.submitter}, {task.assigned}, {string.Join("|", task.watching)}, {task.projectName}, {task.dueDate}");
            sw.Close();
            Tasks.Add(task);
            logger.Info("Task {Id} added", task.ticketId);
        }
    }
}