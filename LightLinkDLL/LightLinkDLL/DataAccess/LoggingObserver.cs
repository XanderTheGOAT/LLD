using LightLinkModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightLinkDLL.DataAccess
{
    public class LoggingObserver : IObserver<Profile>
    {
        public void OnCompleted()
        {
            Console.WriteLine("All Profiles have be Logged");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(error + " was thrown");
        }

        public void OnNext(Profile value)
        {
            Console.WriteLine(value);
        }
    }
}
