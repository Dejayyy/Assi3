using System;

namespace Assi3
{
    class Request : Command
    {
        public string Route;
        public int Payload;
        private AbstractServer targetServer;

        public Request(string route, int payload) {
            Route = route;
            Payload = payload;
        }
        public void SetTargetServer(AbstractServer server)
        {
            targetServer = server;
        }

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
