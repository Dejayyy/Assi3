using System;

namespace Assi3
{
    //Interface for Visitor pattern
    interface Query
    {
        //Visits a server to examine its current state
        void Visit(AbstractServer server);
    }
}
