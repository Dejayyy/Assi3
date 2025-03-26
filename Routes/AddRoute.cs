using System;

namespace Assi3
{
    class AddRoute : Route
    {
        public AddRoute(string path, Route next = null) : base(path, next) {}
        protected override int ProcessRequest(int payload)
        {
            return payload + 8;
        }
    }
}
