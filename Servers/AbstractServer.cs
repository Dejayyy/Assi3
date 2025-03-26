using System;

namespace Assi3
{
    interface AbstractServer
    {
        bool IsAvailable();
        public abstract void Accept(Query query);
        public abstract void SetRequest(Request request);
        public abstract void ProcessWork();
    }
}
