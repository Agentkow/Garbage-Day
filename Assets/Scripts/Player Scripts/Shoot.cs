using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public int playerNum = 1;
    public Rigidbody bag;
    public Transform fireTransform;

    public float force = 5.95f;
    public float coolDown = 0.1f;

    private string fireButton;
    private float chargeSpeed;
    private bool canFire;

   
    void Start ()
    {
        fireButton = "Fire" + playerNum;
        canFire = true;

	}

    
    void FixedUpdate ()
    {
       
        if (canFire)
        {
            if (Input.GetButton(fireButton))
            {
                Debug.Log("fired");
                Fire();
                StartCoroutine(CoolDown());
            }
            
        }
       
    }

    //launch trashcan
    private void Fire()
    {
        Rigidbody instance = Instantiate(bag, fireTransform.position, fireTransform.rotation);
        
        instance.velocity = force * fireTransform.forward;
        
    }

    //cooldown
    private IEnumerator CoolDown()
    {
        canFire = false;
        yield return new WaitForSeconds(coolDown);
        canFire = true;
    }
}
