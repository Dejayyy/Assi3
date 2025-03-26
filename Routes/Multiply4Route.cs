using System;

namespace Assi3
{
    class Multiply4Route : Route
    {
        public Multiply4Route(string path, Route next = null) : base(path, next) {}
        protected override int ProcessRequest(int payload)
        {
            return payload * 4;
        }
    }
}
