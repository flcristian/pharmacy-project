using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.user.model
{
    public class Admin : User
    {
        // Constructors

        public Admin(int id, String name, String email, String password) : base(id, name, email, password, "Admin") { }

        public Admin(String text) : base(text) { }

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

        // Methods

        public override String ToString()
        {
            String desc = base.ToString();

            return desc;
        }

        public override String ToSave()
        {
            String save = base.ToSave();

            return save;
        }
    }
}
