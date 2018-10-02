using System;
using WebAspCore2.Interfaces;


namespace WebAspCore2.Services
{
    public class Service2
    {
      
            private readonly IService1 _service;

            public Service2(IService1 serv)
            {
                _service = serv;
            }

            public int GetRandomValue()
            {
                return _service.GetRandomValue();
            }

        public int GetRandomValueBy2()
        {
            return _service.GetRandomValue() * 2;
        }

        public int GetRandomValueBy3()
        {
            return _service.GetRandomValue() * 3;
        }
    }
}


