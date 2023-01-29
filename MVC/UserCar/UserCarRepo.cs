using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCar
{
    public class UserCarRepo
    {
        DBEntities db = new DBEntities();
        public void Insert(User user, Car car)
        {
            user.Cars.Add(car);
        }
    }
}
