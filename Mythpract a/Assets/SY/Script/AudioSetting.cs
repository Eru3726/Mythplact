using UnityEngine;

namespace SY
{
    [System.Serializable]
    public class AudioSetting
    {
        //[SerializeField, Tooltip("���O")] string name;
        [SerializeField, Tooltip("�T�E���h�N���b�v")] AudioClip clip;
        [SerializeField, Range(0, 1), Tooltip("����")] float volume = 1.0f;
        [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float pitch = 1.0f;
        [SerializeField, Tooltip("�T�E���h���[�v")] bool loop = false;

        //----------�v���p�e�B----------
        //public string Name { get { return name; } }
        public AudioClip Clip { get { return clip; } }
        public float Volume { get { return volume; } }
        public float Pitch { get { return pitch; } }
        public bool Loop { get { return loop; } }

        //----------�T�[�r�X----------
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