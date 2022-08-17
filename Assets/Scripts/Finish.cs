using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject ParticleParent;
    [SerializeField] private AudioSource Audio;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision == null)
        {
            return;
        }

        if (collision.tag == "Player")
        {
            Events.PlayerFinished.Invoke();
            ParticleParent.SetActive(true);
            if (Audio != null)
                Audio.Play();
        }

        if (collision.tag == "Contestant")
        {
            var contestant = collision.GetComponent<ContestantController>();
            contestant.Finished();
        }
    }
}
