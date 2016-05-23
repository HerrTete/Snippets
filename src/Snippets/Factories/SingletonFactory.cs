using System;
using System.Collections.Concurrent;

namespace Snippets.Factories
{
    public static class SingletonFactory
    {
        private static readonly ConcurrentDictionary<Type, object> TeilchenHalter = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Returns a intance from T
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        public static T GetInstance<T>()
        {
            return (T)TeilchenHalter.GetOrAdd(typeof(T), Activator.CreateInstance);
        }

        /// <summary>
        /// Disposes all cached instances of T
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        public static void DisposeInstance<T>()
        {
            lock (TeilchenHalter)
            {
                object o;
                if (TeilchenHalter.TryRemove(typeof(T), out o))
                {
                    if (((T)o) is IDisposable) ((IDisposable)o).Dispose();
                }
            }
        }

        /// <summary>
        /// Checks if a instance of T allready exists.
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <returns>TURE == if a instance allready exists</returns>
        public static bool IsAlreadyInstanced<T>()
        {
            return TeilchenHalter.ContainsKey(typeof(T));
        }

        /// <summary>
        /// Disposes all cached instances of any T
        /// </summary>
        public static void DisposeStatic()
        {
            lock (TeilchenHalter)
            {
                foreach (object o in TeilchenHalter.Values)
                {
                    if (o is IDisposable) ((IDisposable)o).Dispose();
                }
                TeilchenHalter.Clear();
            }
        }
    }
}
