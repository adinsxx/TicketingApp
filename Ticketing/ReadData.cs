using System; 
using System.IO;

class ReadData {
    static void Main(string[] args)
    {
        
    }
}
// if (choice == "1")
// {
// // read data from file
//     if (File.Exists(file))
//     {
//         //ticketID accumulator
//         // read data from file
//         StreamReader sr = new StreamReader(file);
//         while (!sr.EndOfStream)
//         {
//             string line = sr.ReadLine();
//             // convert string to array
//             string[] arr = line.Split('|');
//             // display array data
//             Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
//         }
//         sr.Close();
//     }
//     else
//     {
//         Console.WriteLine("File does not exist");
//     }
// }