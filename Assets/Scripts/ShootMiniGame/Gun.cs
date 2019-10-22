using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource source;
    public ParticleSystem flash;
    public ParticleSystem sparks;

    public void OnShoot() {
        source.Play();
        flash.Emit(1);
        sparks.Emit(Random.Range(1,6));
    }
}
