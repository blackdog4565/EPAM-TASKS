using System;
using Users.Entities;
using System.Collections.Generic;
using System.Text;

namespace UsersAwards
{
    public class Award
    {
        public int ID { get; private set; }
        public string Title { get; private set; }
        public List<int> UsersID { get; private set; }

    }
}
