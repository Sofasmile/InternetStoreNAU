using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Infrustructure
{
    public class Operation_Module : NinjectModule
    {
        private string connectionString;
        public Operation_Module() { }
        public Operation_Module(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<Unit_Of_Works>().To<Unit_Of_Works>().WithConstructorArgument(connectionString);
        }
    }
}
