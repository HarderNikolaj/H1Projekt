
namespace H1ProjektNy
    
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Kunde.Select();
                Menu menu = new Menu();
                menu.Hovedmenu();
            }
        }
    }
}

