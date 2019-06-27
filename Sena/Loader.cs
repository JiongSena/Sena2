﻿using System.Reflection;
using System.Linq;
namespace Sena
{
    public class Loader
    {
        public static UnityEngine.GameObject BaseObject;

        public static void Load()
        {
            //RoR2.RoR2Application.isModded = true;
            while (BaseObject = UnityEngine.GameObject.Find("Sena "))
                UnityEngine.GameObject.Destroy(BaseObject);
            BaseObject = new UnityEngine.GameObject("Sena");
            UnityEngine.Object.DontDestroyOnLoad(BaseObject);
            BaseObject.SetActive(false);
            var types = Assembly.GetExecutingAssembly().GetTypes().ToList().Where(t => t.BaseType == typeof(UnityEngine.MonoBehaviour) && !t.IsNested);
            foreach(var type in types)
            {
                var component = (UnityEngine.MonoBehaviour)BaseObject.AddComponent(type);
                component.enabled = false;
            }
            BaseObject.GetComponent<Menu>().enabled = true;
            BaseObject.SetActive(true);
        }

        public static void Unload()
        {
            UnityEngine.Object.Destroy(BaseObject);
        }
    }
}
