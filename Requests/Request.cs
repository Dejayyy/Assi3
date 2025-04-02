using System;

namespace Assi3
{
    //Implements the Command pattern to encapsulate request 
    class Request : Command
    {
        //Members
        public string Route;
        public int Payload;
        private AbstractServer targetServer;

        //Creates a new request
        public Request(string route, int payload) {
            Route = route;
            Payload = payload;
        }

        //Sets the target server that will be used for request
        public void SetTargetServer(AbstractServer server)
        {
            targetServer = server;
        }

        //Implementaion of Execute method by sending request to target server
        public void Execute()
        {
            if (targetServer != null)
            {
                targetServer.SetRequest(this);
            }
            else
            {
                Console.WriteLine("No server assigned to handle this request.");
            }
        }
    }
}
