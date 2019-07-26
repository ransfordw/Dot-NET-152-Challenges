using Challenge_UtilityMethods;

namespace Challenge_3
{
    class Program
    {
        static void Main(string[] args)
        {
            RealConsole console = new RealConsole();
            ProgramUI program = new ProgramUI(console);
            program.Run();
        }
    }
}
