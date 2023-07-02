using pharmacy_project.interfaces;

namespace pharmacy_project.abstract_classes
{
    public abstract class Panel : IPanel
    {
        // Methods
        
        // In case entered email or something is wrong
        // Ususally a "do you want to try again?" question
        public bool YesNoChoice(String startMessage, String choiceMessage, String endMessage)
        {
            Console.WriteLine(startMessage);
            Console.WriteLine(choiceMessage + " (Y/N)");
            String wrongEmailChoice = Console.ReadLine().ToLower();
            if(wrongEmailChoice.Equals("y") || wrongEmailChoice.Equals("yes"))
            {
                return true;
            } else
            {
                this.DrawLine();
                Console.WriteLine(endMessage + "\n");
            }
            return false;
        }

        public void WaitForKey()
        {
            Console.WriteLine("Enter anything to continue:");
            Console.ReadLine();
        }

        public void DrawLine()
        {
            Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
        }
        
        public abstract void RunMessage();
        
        public abstract void Run();
    }   
}

