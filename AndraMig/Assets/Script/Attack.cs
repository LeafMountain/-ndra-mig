using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    public int damageStrenght;
    public AudioClip[] hitSound;
    public AudioClip[] hitSoundEnvironment;

    public disenableUi dUI;

    void Awake ()
    {
        dUI = GameObject.Find("Buddy").GetComponent<disenableUi>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Rigidbody>())
        {
            if (col.GetComponent<Health>())
                col.GetComponent<Health>().Damaged(damageStrenght);
            col.GetComponent<Rigidbody>().AddForce((transform.forward + transform.up) * 10, ForceMode.Impulse);
            //PlayAudio(hitSound[Random.Range(0, hitSound.Length)], col.transform.position);
        }
        else
        {
            //PlayAudio(hitSoundEnvironment[Random.Range(0, hitSoundEnvironment.Length)], col.transform.position);
        }

        if (col.gameObject.tag == "Player")
        {
            dUI.CountBuddyLives();
            dUI.buddyHealth--;
        }
    }

    void PlayAudio(AudioClip audio, Vector3 soundPos)
    {
        AudioSource.PlayClipAtPoint(audio, soundPos);

    }
}
