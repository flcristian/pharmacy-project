using pharmacy_project.user.model;

namespace pharmacy_project.panels.login
{
    public interface ILoginPanel
    {
        string ObtainName();

        string ObtainEmail();

        string ObtainPassword();

        void AdminChoice(User user);

        void Login();

        void Register();
    }
}
