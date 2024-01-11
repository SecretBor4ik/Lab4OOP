using Lab4.DB.Service;

namespace Lab4.Commands
{
    internal class ShowAllPlayersCommand : ICommand
    {
        private readonly GameAccountService _gameAccountService;
        public ShowAllPlayersCommand(GameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }

        public void Execute()
        {
            List<GameAccount> playersList = _gameAccountService.ReadAll();
            foreach (GameAccount player in playersList)
            {
                Console.WriteLine($"Player ID: {player.Id}, Name: {player.UserName}, Current rating: {player.CurrentRating}");
            }
        }
    }
}
