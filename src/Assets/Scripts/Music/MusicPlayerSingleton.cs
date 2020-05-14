using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayerSingleton : MonoBehaviour
{
    public static MusicPlayerSingleton Instance { get; private set; }

    public AudioClip [] values;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
