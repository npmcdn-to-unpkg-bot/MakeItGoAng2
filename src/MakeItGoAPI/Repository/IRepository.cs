using MakeItGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeItGoAPI.Repository
{


    public interface IRepository<T, in TPk> where T : class {
        IEnumerable<T> GetAll();
        T Get(TPk id);
        //  IEnumerable<T> Add(T obj);
        void Add(T obj);
        void Update(TPk id, T obj);
        T Delete(TPk id);
    }

    public interface IRepository2 {
        void Add(Doctor item);
        IEnumerable<Doctor> GetAll();
        Doctor Find(int key);
        Doctor Remove(int key);
        void Update(Doctor item);
    }

}
