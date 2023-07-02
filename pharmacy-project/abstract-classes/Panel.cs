using pharmacy_project.interfaces;

namespace pharmacy_project.abstract_classes
{
    public abstract class Panel : IPanel
    {
        // Methods
        
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

