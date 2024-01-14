namespace RandomPickerSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                new Game().Play();
            } while (IO.GetYesOrNo("Play again?"));
        }
    }
}
