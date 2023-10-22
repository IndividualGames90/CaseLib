// Part of  IndividualGames.CaseLib | IndividualGames@yandex.com | https://github.com/IndividualGames90
using UnityEngine;

namespace IndividualGames.CaseLib.DataStructures
{
    public abstract class SingletonBehavior<T> : MonoBehaviour where T : SingletonBehavior<T>
    {
        private static bool destroyed = false;
        private static T instance = null;

        public static T Instance
        {
            get
            {
                if (destroyed)
                {
                    return null;
                }

                if (instance == null)
                {
                    var singletons = FindObjectsOfType<T>();

                    if (singletons.Length != 0)
                    {
                        if (singletons.Length > 1)
                        {
                            for (int i = 0; i < singletons.Length - 1; i++)
                            {
                                Destroy(singletons[i]);
                            }
                        }
                        return singletons[0];
                    }

                    var singleton = new GameObject($"Singleton.{typeof(T)}");
                    var singletonType = singleton.AddComponent<T>();
                    DontDestroyOnLoad(singleton);
                    return singletonType;
                }

                return instance;
            }
        }

        private void OnDestroy()
        {
            destroyed = true;
        }

    }
}