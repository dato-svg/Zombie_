using System.Collections.Generic;
using UnityEngine;

namespace BaseScript.Services
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<System.Type, object> services = new();

        public static void Register<T>(T service) where T : class
        {
            services[typeof(T)] = service;
        }

        public static T Get<T>() where T : class
        {
            services.TryGetValue(typeof(T), out var service);
            return service as T;
        }
    }
}