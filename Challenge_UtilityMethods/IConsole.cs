using System;

namespace Challenge_UtilityMethods
{
    public interface IConsole
    {
        void Clear();
        ConsoleKeyInfo ReadKey();
        string ReadLine();
        void Write(string s);
        void WriteLine(string s);
        void WriteLine(object o);
    }
}