
namespace SpartaDungeon
{
    internal class FontColorChange
    {
        public void Write(ConsoleColor newForeColor, string text)
        {
            Console.ForegroundColor = newForeColor;
            Console.Write(text);
            Console.ResetColor();
        }

        public void WriteLine(ConsoleColor newForeColor, string text)
        {
            Console.ForegroundColor = newForeColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
