using System;
using static System.Net.Mime.MediaTypeNames;

namespace Assi3
{
    //Base class for routes in the COR
    class Route
    {
        //Members
        private Route Next;
        private string Path;

        //Creates a new route and allows for next route to be added
        public Route(string path, Route next = null) {
            this.Path = path;
            this.Next = next;
        }
        //Setter for next route in the chain
        public void SetNext(Route route)
        {
            Next = route;
        }

        //Handles a request or passes it to the next route if it cannot
        public virtual int Handle(string path, int payload)
        {
            if (path == Path)
            {
                return ProcessRequest(payload);
            }
            if (Next != null)
            {
                return Next.Handle(path, payload);
            }

            return -1; // -1 == 404 Not Found
        }

        //To be overriden by child classes
        protected virtual int ProcessRequest(int payload)
        {
            return -1; // Default implementation 
        }
    }
}
