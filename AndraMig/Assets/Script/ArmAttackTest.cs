using UnityEngine;
using System.Collections;

public class ArmAttackTest : MonoBehaviour {

	private Animator anim;
    private bool attack;
    private Collider _col;

	void Start ()
	{
		anim = GetComponent<Animator>();
        _col = GetComponent<Collider>();
	}
	

	void Update ()
	{
        anim.SetBool("Attack", attack);

		if (Input.GetKeyDown(KeyCode.E))
		{
            attack = true;
			Invoke("ResetAttack", 0.1f);
		}

        if(attack)
        {
            _col.enabled = true;
        }
        else if (!attack && _col.enabled == true)
        {
            _col.enabled = false;
        }
	}
	void ResetAttack()
	{
        attack = false;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.GetComponent<Health>())
			col.gameObject.GetComponent<Health>().Damaged(1);
	}
}
