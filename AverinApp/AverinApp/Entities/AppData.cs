using AverinApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverinApp.Entities
{
    public class AppData
    {
        public static AverinWarehouseDbEntities Context = new AverinWarehouseDbEntities();
        public static User CurrentUser;
        public static MessagesClass Message = new MessagesClass();
    }
}
