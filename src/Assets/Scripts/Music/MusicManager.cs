using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip clipToPlay;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        QueueSong();
    }


    private void OnLevelWasLoaded(int level)
    {
        QueueSong();
    }

    void QueueSong()
    {
        audioSource.Stop();
        clipToPlay = MusicPlayerSingleton.Instance.values[GetSongIndex()];
        audioSource.clip = clipToPlay;
        audioSource.Play();
    }

    public int GetSongIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

}
