using Lab4.DB.Service;

namespace Lab4.Commands
{
    internal class ShowAllGamesCommand : ICommand
    {
        private readonly GameAccountService _gameAccountService;
        public ShowAllGamesCommand(GameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }
        public void Execute()
        {
            Console.WriteLine("Info about games:");
            foreach (GameAccount thisPlayer in _gameAccountService.ReadAll())
            {
                List<GameResult> games = _gameAccountService.GameResults(thisPlayer);
                foreach (GameResult game in games)
                {
                    Console.WriteLine($"Against {game.Opponent}, {game.Winner}, Rating: {game.CurrentRating}, Game number #{game.GameIndex}");
                }
            }
        }
    }
}
