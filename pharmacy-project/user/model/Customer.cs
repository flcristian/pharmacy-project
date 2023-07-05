using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.interfaces;

namespace pharmacy_project.user.model
{
    public  class Customer : User
    {
        private bool _locked;

        // Constructors

        public Customer(int id, String name, String email, String password) : base(id, name, email, password, "Customer")
        {
            _locked = false;
        }

        public Customer(String text) : base(text)
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

        public String Name
        {
            get { return base.Name; }
            set
            {
                base.Name = value;
            }
        }

        public String Email
        {
            get { return base.Email; }
            set
            {
                base.Email = value;
            }
        }

        public String Password
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

        public override String ToString()
        {
            String desc = base.ToString();

            return desc;
        }

        public override String ToSave()
        {
            String save = base.ToSave();

            save += $"/{_locked}";

            return save;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj) && _locked == (obj as Customer)._locked;
        }
    }
}
