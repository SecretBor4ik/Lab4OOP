using Lab4.Commands;
using Lab4.DB;
using Lab4.DB.Service;
using System.Windows.Input;
using ICommand = Lab4.Commands.ICommand;

namespace Lab4
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var context = new DbContext();
            var gameAccountService = new GameAccountService(context);
            var gameService = new GameService(context);
            Program program = new Program();
            program.Run(gameAccountService, gameService);
        }
        public void Run(GameAccountService gameAccountService, GameService gameService)
        {
            ICommand[] commands = new ICommand[6];
            commands[0] = new EndProgramCommand();
            commands[1] = new AddPlayerCommand(gameAccountService);
            commands[2] = new ShowAllPlayersCommand(gameAccountService);
            commands[3] = new StartGameCommand(gameAccountService, gameService);
            commands[4] = new ShowAllGamesCommand(gameAccountService);
            commands[5] = new ShowGamesForPlayerCommand(gameAccountService);


            commands[1].Execute();
            commands[1].Execute();

            int choose = 1;
            while (choose != 0)
            {
                Console.WriteLine("Choose command:\n 1.Add new player\n 2.Show info about all players\n 3.Start game\n 4.Show info about all players games\n 5.Show info about games of player\n 0.End programm");

                choose = int.Parse(Console.ReadLine());

                commands[choose].Execute();
            }
        }
    }
}