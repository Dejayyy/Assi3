using System;

namespace Assi3
{
    //Interface for server and used in Visitor
    interface AbstractServer
    {
        //Check if the server is available
        bool IsAvailable();
        //Implmentation of Visitor pattern
        public abstract void Accept(Query query);
        //Assigns a request to get ready for future processing
        public abstract void SetRequest(Request request);
        //Process the current requrest
        public abstract void ProcessWork();
    }
}
