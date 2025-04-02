using System;

namespace Assi3
{
    //Route handler for /add request in the COR
    class AddRoute : Route
    {
        //Creates a new AddRoute and the option to pass a next route
        public AddRoute(string path, Route next = null) : base(path, next) {}

        //Process a add request by overriding base class
        protected override int ProcessRequest(int payload)
        {
            return payload + 8;
        }
    }
}
