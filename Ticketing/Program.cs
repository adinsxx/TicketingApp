using System;
using System.IO;

namespace TicketingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string choice;
            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                                    // read data from file
                    if (File.Exists(file))
                    {
                        //ticketID accumulator
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // convert string to array
                            string[] arr = line.Split('|');
                            // display array data
                            Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                                        StreamWriter sw = new StreamWriter(file);
                    for (int i = 0; i < 7; i++)
                    {
                        // ask a question
                        Console.WriteLine("Reporting an issue? (Y/N)");
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
                        Console.WriteLine("What is the priority of this ticket? (Low/Med/High)")
                        // save priority level
                        string priority = Console.ReadLine();
                        // prompt name of submitter
                        Console.WriteLine("Who is submitting this ticket?")
                        string submitter = Console.ReadLine();
                        sw.WriteLine("{0}|{1}|{2}|{3}", ticketID, summary, status, priority);
                    }
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
