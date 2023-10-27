using UnityEngine;

namespace SY
{
    [System.Serializable]
    public class ParticleSetting
    {
        //[SerializeField, Tooltip("���O")] string name;
        [SerializeField, Tooltip("�p�[�e�B�N��")] ParticleSystem particle;
        [SerializeField, Tooltip("�p������")] float time = 1.0f;
        [SerializeField, Tooltip("���[�v")] bool loop = false;
        ParticleStopCheck stopCheck;
        bool isValid = false;

        //----------�v���p�e�B----------
        //public string Name { get { return name; } }
        public ParticleSystem Particle { get { return particle; } }
        public float Time { get { return time; } }
        public bool Loop { get { return loop; } set { loop = value; } }
        public bool IsValid { get { return isValid; } set { isValid = value; } }

        //----------�T�[�r�X----------
        public void PlayParticle()
        {
            if (particle == null) { return; }
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
