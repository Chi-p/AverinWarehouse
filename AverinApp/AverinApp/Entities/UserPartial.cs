﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverinApp.Entities
{
    public partial class User
    {
        public string Greeting
        {
            get
            {
                int hour = DateTime.Now.Hour;
                string greeting = "";

                if (hour >= 0 && hour < 5)
                    greeting = "Доброй ночи";
                else if (hour >= 5 && hour < 12)
                    greeting = "Доброго утра";
                else if (hour >= 12 && hour < 17)
                    greeting = "Доброго дня";
                else if (hour >= 17)
                    greeting = "Доброго вечера";

                return $"{greeting}, {Login}!";
            }
        }

        public string Warehouse
        {
            get
            {
                if (Operator != null)
                {
                    if (Operator.Warehouse.Count != 0)
                        return Operator.Warehouse.First().Name;
                    else
                        return "Не назначен";
                }
                else
                    return "";
            }
        }
    }
}
