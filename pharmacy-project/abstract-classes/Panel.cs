using pharmacy_project.interfaces;

namespace pharmacy_project.abstract_classes
{
    public abstract class Panel : IPanel
    {
        // Methods
        
        public void DrawLine()
        {
            Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
        }
        
        public abstract void RunMessage();
        
        public abstract void Run();
    }
}

