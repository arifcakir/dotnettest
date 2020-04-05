using System;
using System.Collections.Generic;
using System.Text;

namespace FirstTestApp.Tests.Infra
{
    public class MyClassFixture : IDisposable
    {

        public MyClassFixture()
        {

            Persons = new List<Person>();
        }


        public void Dispose()
        {
            
        }

        public List<Person> Persons { get; private set; }

    }
}
