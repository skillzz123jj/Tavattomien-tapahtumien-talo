using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimateItems : MonoBehaviour
{
    private Animator anim;
    [SerializeField] float timeStamp;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void TriggerAnimation()
    {
        if (anim != null)
        {
            anim.SetTrigger("Activated");
        }
    }

    public void AnimationCheck(string status)
    {
        if (status.Equals("Finished"))
        {
            anim.enabled = false;
        }
    }

    public void LoopAnimation(string animationClip)
    {
        anim.Play(animationClip, 0, timeStamp);
       
    }
 
}
