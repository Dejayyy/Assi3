using System;

namespace Assi3
{
    class MultiplyRoute : Route
    {
        public MultiplyRoute(string path, Route next = null) : base(path, next) {}

        protected override int ProcessRequest(int payload)
        {
            return payload * 2;
        }
    }
}
