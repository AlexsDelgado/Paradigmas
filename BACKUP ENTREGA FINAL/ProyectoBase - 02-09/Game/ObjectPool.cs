using System;
using System.Collections.Generic;

namespace Game
{
    public class ObjectPool<T> where T : new()
    {
        private Queue<T> availableObjects;
        private List<T> allObjects;

        public ObjectPool(int initialCapacity = 0)
        {
            availableObjects = new Queue<T>();
            allObjects = new List<T>();

            for (int i = 0; i < initialCapacity; i++)
            {
                T obj = new T();
                availableObjects.Enqueue(obj);
                allObjects.Add(obj);
            }
        }

        public T GetObject()
        {
            if (availableObjects.Count > 0)
            {
                return availableObjects.Dequeue();
            }
            else
            {
                T newObj = new T();
                allObjects.Add(newObj);
                return newObj;
            }
        }

        public void ReturnObject(T obj)
        {
            availableObjects.Enqueue(obj);
        }
    }
}
