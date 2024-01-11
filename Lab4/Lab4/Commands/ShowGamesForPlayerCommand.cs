using Lab4.DB.Service;

namespace Lab4.Commands
{
    internal class ShowGamesForPlayerCommand : ICommand
    {
        private readonly GameAccountService _gameAccountService;
        public ShowGamesForPlayerCommand(GameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }

        public void Execute()
        {
            Console.WriteLine("Input ID of playes, games which you want see:");
            int playerID = int.Parse(Console.ReadLine());
            GameAccount player = _gameAccountService.ReadById(playerID);
            Console.WriteLine($"Info about player {player.UserName} games:");
            List<GameResult> games = _gameAccountService.GameResults(player);
            foreach (GameResult game in games)
            {
                Console.WriteLine($"Against {game.Opponent}, {game.Winner}, Rating: {game.CurrentRating}, Game number #{game.GameIndex}");
            }
        }
    }
}
