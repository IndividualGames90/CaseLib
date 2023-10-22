using IndividualGames.CaseLib.DataStructures;
using System.Collections;
using UnityEngine;

namespace Assets.IndividualGames.CaseLib.UI.Animation
{
    public class AnimationController : SingletonBehavior<AnimationController>
    {
        [SerializeField] private AnimationCurve bounce;
        [SerializeField] private float animationSpeed = .01f;

        private WaitForSeconds waitAnimationUpdate;

        private void Awake()
        {
            waitAnimationUpdate = new(animationSpeed);
        }

        public void DOEntryBounce(GameObject go) => StartCoroutine(DOEntryBounceCoroutine(go));
        private IEnumerator DOEntryBounceCoroutine(GameObject go)
        {
            float timeElapsed = 0;
            float endTime = bounce.keys[bounce.length - 1].time;

            float scaleX = go.transform.localScale.x;
            float scaleY = go.transform.localScale.y;
            float scaleZ = go.transform.localScale.z;

            while (timeElapsed < endTime)
            {
                var animationValue = bounce.Evaluate(timeElapsed);

                go.transform.localScale = new Vector3(scaleX * animationValue,
                                                      scaleY * animationValue,
                                                      scaleZ * animationValue);

                yield return waitAnimationUpdate;
                timeElapsed += Time.deltaTime;
            }
        }
    }
}