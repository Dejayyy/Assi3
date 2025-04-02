using System;

namespace Assi3
{
    //Concrete server element
    class Server : AbstractServer
    {
        //Members
        public Request CurrentRequest { get; set; }
        private Route firstRoute;

        //Initalizes new server and sets up the COR for routes
        public Server()
        {
            var addRoute = new AddRoute("add");
            var mul4Route = new Multiply4Route("mul/4", addRoute);
            var mulRoute = new MultiplyRoute("mul", mul4Route);

            firstRoute = mulRoute;
        }

        //Allows visitor to exmain servers state
        public void Accept(Query query)
        {
            query.Visit(this);
        }

        //Assigns a request to this server to be processed later
        public void SetRequest(Request request)
        {
            CurrentRequest = request;
        }

        //Check if the server can accept a new request or not
        public bool IsAvailable()
        {
            return CurrentRequest == null;
        }

        //Process the currect request by passing it down the COR
        public void ProcessWork()
        {
            if (CurrentRequest == null)
            {
                Console.WriteLine("No request to process.");
                return;
            }

            int result = firstRoute.Handle(CurrentRequest.Route, CurrentRequest.Payload);

            //Output if nothing matches to display to user
            if (result == -1)
            {
                Console.WriteLine("404");
            }
            else
            {
                Console.WriteLine($"Path: {CurrentRequest.Route}");
                Console.WriteLine($"Input: {CurrentRequest.Payload}");
                Console.WriteLine($"Results: {result}");
            }

            CurrentRequest = null;
        }
    }
}
