﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.user.model
{
    public class Admin:User
    {
        // Constructors

        public Admin(int id, string name, string email, string password) : base(id, name, email, password, "Admin")
        {

        }

        public Admin(string text) : base(text)
        {

        }

        // Accessors

        public int Id
        {
            get { return base.Id; }
            set
            {
                base.Id = value;
            }
        }

        public string Name
        {
            get { return base.Name; }
            set
            {
                base.Name = value;
            }
        }

        public string Email
        {
            get { return base.Email; }
            set
            {
                base.Email = value;
            }
        }

        public string Password
        {
            get { return base.Password; }
            set
            {
                base.Password = value;
            }
        }

        // Methods

        public override string ToString()
        {
            string desc = base.ToString();

            return desc;
        }

        public override string ToSave()
        {
            string save = base.ToSave();

            return save;
        }
    }
}
