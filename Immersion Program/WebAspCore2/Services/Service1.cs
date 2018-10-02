using System;
using WebAspCore2.Interfaces;

namespace WebAspCore2.Services
{
    public class Service1 : IService1
    {
        public int GetRandomValue()
        {
            var r = new Random();
            return r.Next();
        }
    }
}
