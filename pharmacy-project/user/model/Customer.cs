using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.user.model
{
    public  class Customer : User
    {
        private bool _locked;

        // Constructors

        public Customer(int id, string name, string email, string password) : base(id, name, email, password, "Customer")
        {
            _locked = false;
        }

        public Customer(string text) : base(text)
        {
            _locked = Boolean.Parse(text.Split('/')[5]);
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

        public bool Locked
        {
            get { return _locked; }
            set
            {
                _locked = value;
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

            save += $"/{_locked}";

            return save;
        }
    }
}
