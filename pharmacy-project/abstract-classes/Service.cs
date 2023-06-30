using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.interfaces;

namespace pharmacy_project.abstract_classes
{
    public abstract class Service<T> : IService<T> where T : IToSave, IHasId
    {
        private List<T> _list;

        // Constructors

        public Service(String path)
        {
            _list = new List<T>();
            this.ReadList(path);
        }

        public Service(List<T> list)
        {
            _list = list;
        }

        private T ClassConstructor(String text)
        {
            Type type = typeof(T);
            ConstructorInfo constructor = type.GetConstructor(new[] { typeof(String) });
            return (T)constructor.Invoke(new object[] { text });
        }

        // Methods

        public void ReadList(String path)
        {
            StreamReader sr = new StreamReader(path);

            _list = new List<T>();
            while (!sr.EndOfStream)
            {
                String text = sr.ReadLine();
                T t = ClassConstructor(text);
                _list.Add(t);
            }

            sr.Close();
        }

        public void SaveList(String path)
        {
            String toSave = "";
            Console.WriteLine("here");
            Console.WriteLine(_list.Count());
            foreach (T t in _list)
            {
                toSave += $"{t.ToSave()}\n";
                Console.WriteLine("herewtf");
            }

            StreamWriter sw = new StreamWriter(path);
            sw.Write(toSave);
            sw.Close();
        }

        public void Display()
        {
            if (!_list.Any())
            {
                Console.WriteLine("There are no manufacturers.\n");
                return;
            }

            foreach (T t in _list)
            {
                Console.WriteLine(t);
            }
        }

        public int Count()
        {
            return _list.Count();
        }

        public T FindById(int id)
        {
            foreach (T t in _list)
            {
                if (t.Id == id)
                {
                    return t;
                }
            }

            return (T)(object)null!;
        }

        public int NewId()
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 999999);

            while (this.FindById(id) != null!)
            {
                id = rnd.Next(1, 999999);
            }

            return id;
        }

        public void ClearList()
        {
            _list.Clear();
        }

        public int RemoveById(int id)
        {
            T t = this.FindById(id);

            // Checks if manufacturer exists. Returns 0 if not.
            if (t == null!)
            {
                return 0;
            }

            _list.Remove(t);
            return 1;
        }

        public virtual int Add(T t)
        {
            // Checks if id is already used.
            T foundById = this.FindById(t.Id);

            if (foundById != null!)
            {
                return 0;
            }

            _list.Add(t);
            return 1;
        }

        public int EditById(T t, int id)
        {
            T found = this.FindById(id);

            _list[_list.IndexOf(found)] = t;
            return 1;
        }

        public List<T> GetList()
        {
            return _list;
        }
    }
}
