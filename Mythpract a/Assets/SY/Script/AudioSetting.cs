using UnityEngine;

namespace SY
{
    [System.Serializable]
    public class AudioSetting
    {
        //[SerializeField, Tooltip("名前")] string name;
        [SerializeField, Tooltip("サウンドクリップ")] AudioClip clip;
        [SerializeField, Range(0, 1), Tooltip("音量")] float volume = 1.0f;
        [SerializeField, Range(-3, 3), Tooltip("再生速度")] float pitch = 1.0f;
        [SerializeField, Tooltip("サウンドループ")] bool loop = false;

        //----------プロパティ----------
        //public string Name { get { return name; } }
        public AudioClip Clip { get { return clip; } }
        public float Volume { get { return volume; } }
        public float Pitch { get { return pitch; } }
        public bool Loop { get { return loop; } }

        //----------サービス----------
        public void PlayAudio(AudioSource audioSource)
        {
            if (clip == null) { return; }
            SetAudio(audioSource);
            audioSource.Play();
        }

        //
        void SetAudio(AudioSource audioSource)
        {
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.loop = loop;
        }
    }
}