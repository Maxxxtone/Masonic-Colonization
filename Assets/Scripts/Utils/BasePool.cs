using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class BasePool<T>
    {
        private Queue<T> _pool;
        private GameObject _prefab;
        private GameObject _root;
        public Queue<T> Pool => _pool;
        public BasePool(GameObject prefab, int preloadCount, string rootName)
        {
            _pool = new Queue<T>();
            _prefab = prefab;
            _root = new GameObject(rootName);
            for (int i = 0; i < preloadCount; i++)
            {
                Return(Preload(_prefab, _root).GetComponent<T>());
            }
        }
        public T Get()
        {
            T item = _pool.Count > 0 ? _pool.Dequeue() : Preload(_prefab, _root).GetComponent<T>();
            //(item as GameObject).SetActive(true);
            return item;
        }
        public void Return(T item)
        {
            _pool.Enqueue(item);
        }
        #region Basic Pool Methods
        public static GameObject Preload(GameObject prefab, GameObject root)
        {
            var obj = Object.Instantiate(prefab);
            obj.transform.SetParent(root.transform);
            return obj;
        }
        public static void GetAction(GameObject @object) => @object.SetActive(true);
        public static void ReturnAction(GameObject @object) => @object.SetActive(false);
        #endregion
    }
}
