using System; 
using System.IO;

class WriteData {
    static void Main(string[] args)
    {
        
    }
}
// else if (choice == "2")
//                 {
//                     StreamWriter sw = new StreamWriter(file);
//                     int ticketID = 0;
//                     for (int i = 0; i < 7; i++)
//                     {
//                         // ask a question
//                         Console.WriteLine("Reporting an issue? (Y/N)");
//                         // input the response
//                         string resp = Console.ReadLine().ToUpper();
//                         // if the response is anything other than "Y", stop asking
//                         if (resp != "Y") { break; }                      
//                         // short summary of issue
//                         ticketID++;
//                         Console.WriteLine("Please enter the summary of the issue:");
//                         // save the summary
//                         string summary = Console.ReadLine();
//                         // prompt for ticket status
//                         Console.WriteLine("What is the ticket status? (Open/Resolved)");
//                         // save the course grade
//                         string status = Console.ReadLine();
//                         // enter pritority of ticket
//                         Console.WriteLine("What is the priority of this ticket? (Low/Med/High)");
//                         // save priority level
//                         string priority = Console.ReadLine();
//                         // prompt name of submitter
//                         Console.WriteLine("Who is submitting this ticket?");
//                         string submitter = Console.ReadLine();
//                         // name of assigned analyst
//                         Console.WriteLine("Who is assigned this ticket?");
//                         string assigned = Console.ReadLine();
//                         // name of person watching this ticket
//                         Console.WriteLine("Who is watching this ticket?");
//                         string watching = Console.ReadLine();
//                         sw.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", ticketID, summary, status, priority, submitter, assigned, watching);
//                     }
//                     sw.Close();
//                 }