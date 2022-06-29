using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    public static AudioClip charJump;
    public static AudioClip charTaunt;
    public static AudioClip enemyHit;
    public static AudioClip enemyDeath;
    public static AudioClip projSound;
    public static AudioClip projHit;

    static AudioSource audioSource;

    void Start()
    {
        charJump = Resources.Load<AudioClip>("charJump");
        charTaunt = Resources.Load<AudioClip>("taunt");
        enemyHit = Resources.Load<AudioClip>("sight");
        enemyDeath = Resources.Load<AudioClip>("death");
        projSound = Resources.Load<AudioClip>("plasma");
        projHit = Resources.Load<AudioClip>("projHit");

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public static void PlaySound(string clip) 
    {
        switch(clip) {
            case "charJump" :
                audioSource.PlayOneShot(charJump);
                break;
            case "taunt" :
                audioSource.PlayOneShot(charTaunt);
                break;
            case "sight" :
                audioSource.PlayOneShot(enemyHit);
                break;
            case "death" :
                audioSource.PlayOneShot(enemyDeath);
                break;
            case "plasma" :
                audioSource.PlayOneShot(projSound);
                break;
            case "projHit" :
                audioSource.PlayOneShot(projHit);
                break;                 
        }
    }
}
