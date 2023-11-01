using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IndividualGames.CaseLib.DesignPattern
{
    /// <summary>
    /// Manager for SingletonBehaviors. Callback to their OnAwakes.
    /// 
    /// Persistent.
    /// Req: OnScene and high in Awake order.
    /// 
    /// Other Fixes:
    /// Access to singletons must be in Start if applicable.
    /// </summary>
    public class SingletonComponentInitializer : MonoBehaviour
    {
        [SerializeField] private bool _keepDuplicates;

        private SingletonBehavior[] singletons;

        private static SingletonComponentInitializer _instance;

        private void Awake()
        {
            InitializeSelf();
            InitializeSingletons();
        }

        private void InitializeSelf()
        {
            if (_instance == null)
            {
                DontDestroyOnLoad(gameObject);
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            SceneManager.activeSceneChanged += InitializeSingletons;
        }

        private void InitializeSingletons(Scene scene, Scene otherScene)
        {
            InitializeSingletons();
        }

        private void InitializeSingletons()
        {
            singletons = FindObjectsOfType(typeof(SingletonBehavior)) as SingletonBehavior[];

            foreach (var singleton in singletons)
            {
                singleton.KeepDuplicates(_keepDuplicates);

                MethodInfo onAwakeInfo = singleton.GetType().GetMethod("OnAwake", BindingFlags.Instance | BindingFlags.Public);
                onAwakeInfo?.Invoke(singleton, null);
            }
        }
    }
}
