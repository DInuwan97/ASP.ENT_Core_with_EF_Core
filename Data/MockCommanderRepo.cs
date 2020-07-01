using MYTestingASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYTestingASPNETCore.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 1, HowTo = "Boil an Egg - 1", Line = "Boil Water - 1", Platform = "Dinuwan Kalubowila - 1" },
                new Command { Id = 2, HowTo = "Boil an Egg - 2", Line = "Boil Water - 2", Platform = "Dinuwan Kalubowila - 2" },
                new Command { Id = 3, HowTo = "Boil an Egg - 3", Line = "Boil Water - 2", Platform = "Dinuwan Kalubowila - 3" }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 1, HowTo = "Boil an Egg - 1", Line = "Boil Water - 1", Platform = "Dinuwan Kalubowila - 1" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
