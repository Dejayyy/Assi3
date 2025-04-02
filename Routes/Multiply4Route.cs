using System;

namespace Assi3
{
    //Route handler for /mul/4 request in the COR
    class Multiply4Route : Route
    {
        //Creates a new Multiply4Route and the option to pass a next route
        public Multiply4Route(string path, Route next = null) : base(path, next) {}

        //Process a multiply4 request by overriding base class
        protected override int ProcessRequest(int payload)
        {
            return payload * 4;
        }
    }
}
