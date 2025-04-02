using System;

namespace Assi3
{
    //Concrete visitor that checks if server is available
    class ServerQuery : Query
    {
        //Bool to store if server is avilable 
        public bool IsServerAvailable { get; private set; }

        //Visits a server to check if it is available or not
        public void Visit(AbstractServer server)
        {
            IsServerAvailable = server.IsAvailable();
        }
    }
}
