using System;

namespace Assi3
{
    //Route handler for /mul request in COR
    class MultiplyRoute : Route
    {
        //Creates a new MultiplyRoute and the option to pass a next route
        public MultiplyRoute(string path, Route next = null) : base(path, next) {}

        //Process a multiply request by overriding base class
        protected override int ProcessRequest(int payload)
        {
            return payload * 2;
        }
    }
}
