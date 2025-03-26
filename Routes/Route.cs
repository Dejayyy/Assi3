using System;
using static System.Net.Mime.MediaTypeNames;

namespace Assi3
{
    class Route
    {
        private Route Next;
        private string Path;

        public Route(string path, Route next = null) {
            this.Path = path;
            this.Next = next;
        }
        public void SetNext(Route route)
        {
            Next = route;
        }

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
        protected virtual int ProcessRequest(int payload)
        {
            return -1; // Default implementation 
        }
    }
}
