﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.bases.service_base;

public interface IService<T>
{
    void ReadList(String path);

    void SaveList(String path);

    void Display();

    int Count();

    int NewId();

    void ClearList();

    int Add(T item);

    int RemoveById(int id);

    int EditById(T item, int id);

    int DisplayById(int id);

    T FindById(int id);

    List<T> GetList();
}
