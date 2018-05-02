using System;

namespace _08.PetClinic
{
    class Program
    {
        static void Main(string[] args)
        {
            ClinicDispatcher cd = new ClinicDispatcher();
            cd.Dispatch();
        }
    }
}
