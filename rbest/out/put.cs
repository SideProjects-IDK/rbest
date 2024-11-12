using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbest.@out
{
    public class put
    {
        public static void e_print(string _message)
        {
            print_program_name();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(_message);
        }
        public static void ec_print(string _message)
        {
            cu_print("Critical",_message,ConsoleColor.Red);
        }


        public static void print_program_name()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\n{Program.__name__} ");
        }


        public static void print(string _message)
        {
            print_program_name();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(_message);
        }
        public static void n_print(string _message)
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\n{_message}");
        }



        public static void cu_print(string _type,string _message,ConsoleColor _clr)
        {
            print_program_name();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"<");
            Console.ForegroundColor = _clr;
            Console.Write($"{_type}");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"> ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(_message);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
