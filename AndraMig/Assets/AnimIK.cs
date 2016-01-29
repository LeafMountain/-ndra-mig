using UnityEngine;
using System.Collections;

public class AnimIK : MonoBehaviour
{

    Animator anim;

    public float ikWeight = 1;

    public Transform leftIKTarget;
    public Transform rightIKTarget;


    void Start()
    {
        //anim.SetLayerWeight(1, 1);
        //anim.SetLayerWeight(2, 1);

    }

    void OnAnimatorIK()
    {
        if (anim)
        {


            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, ikWeight);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, ikWeight);

            anim.SetIKPosition(AvatarIKGoal.LeftHand, leftIKTarget.position);
            anim.SetIKPosition(AvatarIKGoal.RightHand, rightIKTarget.position);
        }
    }
}
