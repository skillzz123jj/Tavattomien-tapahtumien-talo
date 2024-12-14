using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimateItems : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float timeStamp;
    [SerializeField] private AudioSource idleAudioSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //Starts animations upon item discovery
    public void TriggerAnimation()
    {
        if (anim != null)
        {
            anim.SetTrigger("Activated");
        }
    }

    //Finishes animations
    public void AnimationCheck(string status)
    {
        if (status.Equals("Finished"))
        {
            anim.enabled = false;
        }
    }

    public void InteractWihtIdleAudio()
    {
        if (idleAudioSource != null && idleAudioSource.isPlaying)
        {
            idleAudioSource.Stop();
        }

    }

    //Continues to loop animations for items that have that feature
    public void LoopAnimation(string animationClip)
    {
        anim.Play(animationClip, 0, timeStamp);
       
    }
}
