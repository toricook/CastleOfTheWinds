using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CastleOfTheWinds
{
    public sealed class ObjectStore
    {
        public static readonly ObjectStore Instance = new ObjectStore();

        private readonly HashSet<GameObject> _objects;
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();


        private ObjectStore()
        {
            _objects = new HashSet<GameObject>();
        }

        public void AddObject(GameObject obj)
        {
            _lock.EnterWriteLock();
            try
            {
                _objects.Add(obj);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void RemoveObject(GameObject obj)
        {
            _lock.EnterWriteLock();
            try
            {
                _objects.Remove(obj);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public IReadOnlyCollection<GameObject> GetObjects()
        {
            _lock.EnterReadLock();
            try
            {
                return _objects.ToList().AsReadOnly();
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }
    }
}
