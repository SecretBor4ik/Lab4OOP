using Lab4.DB.Service;
using Lab4.Account;

namespace Lab4.Commands
{
    internal class AddPlayerCommand : ICommand
    {
        private readonly GameAccountService _gameAccountService;
        public AddPlayerCommand(GameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }
        public void Execute()
        {
            Console.WriteLine("New player name: ");
            string name = Console.ReadLine();
            GameAccount player = AccountChose(_gameAccountService, name);
            _gameAccountService.Create(player);
        }

        private GameAccount AccountChose(GameAccountService service, string userName)
        {
            Console.WriteLine("Choose account type: \n1.StandartAccount \n2.HalfAccount \n3.VIPAccount");
            int choose = int.Parse(Console.ReadLine());
            var Id = service.ReadAll().Count();
            switch (choose)
            {
                case 1:
                    var standartGameAccount = new StandartAccount(service, Id, userName);
                    return standartGameAccount;
                case 2:
                    var unrankedAccount = new UnrankedAccount(service, Id, userName);
                    return unrankedAccount;
                case 3:
                    var vipAccount = new VIPAccount(service, Id, userName);
                    return vipAccount;
                default:
                    Console.WriteLine("Incorrect. Write number between 1-3");
                    return AccountChose(service, userName);
            }
        }
    }
}
