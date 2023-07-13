using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.user.model;

namespace pharmacy_project.user.service
{
    public interface IUserService
    {
        int DisplayAdmins();

        User FindByEmail(String email);

        User FindByEmailAndPassword(String email, String password);

        List<User> FindByName(String name);

        bool IsAdmin(User user);

        int RemoveByEmail(String email);

        int BlockById(int id);

        int UnblockById(int id);
    }
}
