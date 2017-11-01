namespace DragonsLair_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

        private void Run()
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }
}