using UnityEngine;

namespace SY
{
    public class ParticleStopCheck : MonoBehaviour
    {
        ParticleSetting setting;
        bool isStop = false;

        public bool IsStop { get { return isStop; } set { isStop = value; } }

        private void OnParticleSystemStopped()
        {
            Debug.Log("パーティクル終わり");
            isStop = true;
            gameObject.SetActive(false);
        }
    }
}
