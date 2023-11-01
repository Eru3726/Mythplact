using UnityEngine;

namespace SY
{
    [System.Serializable]
    public class ParticleSetting
    {
        //[SerializeField, Tooltip("名前")] string name;
        [SerializeField, Tooltip("パーティクル")] ParticleSystem particle;
        [SerializeField, Tooltip("継続時間")] float time = 1.0f;
        [SerializeField, Tooltip("ループ")] bool loop = false;
        ParticleStopCheck stopCheck;
        bool isValid = false;

        //----------プロパティ----------
        //public string Name { get { return name; } }
        public ParticleSystem Particle { get { return particle; } }
        public float Time { get { return time; } }
        public bool Loop { get { return loop; } set { loop = value; } }
        public bool IsValid { get { return isValid; } set { isValid = value; } }

        //----------サービス----------
        public void PlayParticle()
        {
            if (particle == null) { return; }
            Debug.Log(particle.name);
            var main = particle.main;
            main.duration = time;
            main.loop = loop;
            stopCheck = particle.GetComponent<ParticleStopCheck>();
            isValid = true;
            if (stopCheck != null) { stopCheck.IsStop = false; }
            particle.Play();
        }

        public void StopCheck() { isValid = (stopCheck.IsStop == true) ? false : true; }
    }
}
