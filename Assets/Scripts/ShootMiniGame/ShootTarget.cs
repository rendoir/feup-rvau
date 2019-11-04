using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTarget : MonoBehaviour
{
    public ShootRow row;
    public LayerMask rowEndColliderLayer;
    public LayerMask bulletLayer;
    public float flipSpeed = 1f;

    private bool hit;
    private AudioSource source;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private float timeCounter;

    public enum TargetDifficulty { EASY, NORMAL, HARD }
    
    public TargetDifficulty difficulty = TargetDifficulty.NORMAL;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        initialRotation = transform.localRotation;
        targetRotation = Quaternion.Euler(initialRotation.eulerAngles + new Vector3(0f,0f,-90f));
    }

    void Start()
    {
        Restart();
    }
    
    void Update()
    {
        switch(difficulty) {
            case TargetDifficulty.NORMAL:
                transform.position += transform.forward * row.speed * Time.deltaTime;
                break;
            case TargetDifficulty.HARD:
                transform.position += transform.forward * row.speed * Time.deltaTime + transform.up * Mathf.Sin(Time.time * 10f + GetInstanceID()) / 5f * Time.deltaTime;
                break;
        }
        

        if(hit) {
            transform.localRotation = Quaternion.Slerp(initialRotation, targetRotation, timeCounter);
            timeCounter += Time.deltaTime * flipSpeed;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(Utils.MaskContainsLayer(bulletLayer, collision.gameObject.layer))
            OnBulletHit();
    }

    void OnTriggerEnter(Collider other) {
        if(Utils.MaskContainsLayer(rowEndColliderLayer, other.gameObject.layer))
            OnRowEnd();
    }

    void OnBulletHit() {
        if(!hit) {
            hit = true;
            row.shootMiniGame.OnTargetHit();
        }
        source.Play();
    }

    void OnRowEnd() {
        transform.position = row.startTransform.position;
    }

    public void Restart() {
        hit = false;
        transform.localRotation = initialRotation;
        timeCounter = 0f;
    }
}
