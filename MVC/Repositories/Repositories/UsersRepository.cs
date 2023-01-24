using Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class UsersRepository : GenericRepository<User>
    {
        public UsersRepository(IUnitOfWork<CRUDDBEntities> unitOfWork) : base(unitOfWork)
        {}

        public UsersRepository(CRUDDBEntities context) : base(context)
        {}
    }
}
