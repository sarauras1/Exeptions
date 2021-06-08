using System;
using System.Collections.Generic;

namespace Exceptionn
{
    class Program
    {
      
       public static void Main()

        {
            do
            {
                Console.WriteLine("Registrazione Utente");
                Registration reg = new Registration();
                Console.WriteLine("Iserisci il tuo username");
                reg.UserName = Console.ReadLine();
                Console.WriteLine("Iserisci la tua password");
                reg.Password = Console.ReadLine();
                DBManager.Login(reg.UserName, reg.Password);
            } while (true);
           


           
        }
    }

}