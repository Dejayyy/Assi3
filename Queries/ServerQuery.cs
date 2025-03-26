using System;

namespace Assi3
{
    class ServerQuery : Query
    {
        public bool IsServerAvailable { get; private set; }

        public void Visit(AbstractServer server)
        {
            IsServerAvailable = server.IsAvailable();
        }
    }
}
