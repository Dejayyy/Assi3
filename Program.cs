using System;
using System.Collections.Generic;

namespace Assi3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Server> Servers = new List<Server>();
            Queue<Request> PendingRequests = new Queue<Request>();

            Console.WriteLine("Please enter a command.");
            string command = "";

            while(command != "quit") {
                string[] commandArgs = command.Split(":");
                Console.WriteLine();

                switch(commandArgs[0]) {
                    case "help":
                        Console.WriteLine("help\t\t\tDisplay this menu");
                        Console.WriteLine("createserver\t\tCreate a new server.");
                        Console.WriteLine("deleteserver:[id]\tDelete server #ID.");
                        Console.WriteLine("listservers\t\tList all servers.");
                        Console.WriteLine("new:[path]:[payload]\tCreate a new pending request.");
                        Console.WriteLine("dispatch\t\tSend a pending request to a server.");
                        Console.WriteLine("server:[id]\t\tHave server #ID execute its pending request and print the result.");
                        Console.WriteLine("quit\t\t\tQuit the application");
                        break;
                    case "createserver":
                        Servers.Add(new Server());
                        Console.WriteLine($"Created server #{Servers.Count - 1}");
                        break;
                    case "deleteserver":
                        if (commandArgs.Length > 1 && int.TryParse(commandArgs[1], out int serverId) && serverId >= 0 && serverId < Servers.Count)
                        {
                            Servers.RemoveAt(serverId);
                            Console.WriteLine($"Deleted server #{serverId}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid server ID.");
                        }
                        break;
                    case "listservers":
                        if (Servers.Count == 0)
                        {
                            Console.WriteLine("No servers available.");
                        }
                        else
                        {
                            for (int i = 0; i < Servers.Count; i++)
                            {
                                var query = new ServerQuery();

                                Servers[i].Accept(query);
                                string status = query.IsServerAvailable ? "Available" : "Busy";
                                Console.WriteLine($"Server #{i}: {status}");
                            }
                        }
                        break;
                    case "new":
                        if (commandArgs.Length >= 3 && int.TryParse(commandArgs[2], out int payload))
                        {
                            Request request = new Request(commandArgs[1], payload);
                            PendingRequests.Enqueue(request);
                            Console.WriteLine($"Added request to queue. Path: {commandArgs[1]}, Payload: {payload}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid request format. Use new:[path]:[payload]");
                        }
                        break;
                    case "dispatch":
                        if (PendingRequests.Count == 0)
                        {
                            Console.WriteLine("No pending requests.");
                        }
                        else
                        {
                            bool dispatched = false;
                            for (int i = 0; i < Servers.Count; i++)
                            {
                                var query = new ServerQuery();
                                Servers[i].Accept(query);

                                if (query.IsServerAvailable)
                                {
                                    Request request = PendingRequests.Dequeue();

                                    request.SetTargetServer(Servers[i]);

                                    request.Execute();

                                    Console.WriteLine($"Request dispatched to server #{i}");
                                    dispatched = true;
                                    break;
                                }
                            }

                            if (!dispatched)
                            {
                                Console.WriteLine("No available servers to handle the request.");
                            }
                        }
                        break;
                    case "server":
                        if (commandArgs.Length > 1 && int.TryParse(commandArgs[1], out int serverToProcess)
                           && serverToProcess >= 0 && serverToProcess < Servers.Count)
                        {
                            Servers[serverToProcess].ProcessWork();
                        }
                        else
                        {
                            Console.WriteLine("Invalid server ID.");
                        }
                        break;
                    default:
                        if(command != "") {
                            Console.WriteLine("Invalid command.");
                        }
                        break;
                }

                Console.WriteLine();
                command = Console.ReadLine();
            }
        }
    }
}
