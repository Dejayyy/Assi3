using System;

namespace Assi3
{
    class Server : AbstractServer
    {
        public Request CurrentRequest { get; set; }
        private Route firstRoute;

        public Server()
        {
            var addRoute = new AddRoute("/add");
            var mul4Route = new Multiply4Route("/mul/4", addRoute);
            var mulRoute = new MultiplyRoute("/mul", mul4Route);

            firstRoute = mulRoute;
        }

        public void Accept(Query query)
        {
            query.Visit(this);
        }

        public void SetRequest(Request request)
        {
            CurrentRequest = request;
        }
        public bool IsAvailable()
        {
            return CurrentRequest == null;
        }

        public void ProcessWork()
        {
            if (CurrentRequest == null)
            {
                Console.WriteLine("No request to process.");
                return;
            }

            int result = firstRoute.Handle(CurrentRequest.Route, CurrentRequest.Payload);

            if (result == -1)
            {
                Console.WriteLine("404");
            }
            else
            {
                Console.WriteLine($"{result}");
            }

            CurrentRequest = null;
        }
    }
}
