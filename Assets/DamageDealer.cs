using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the player is pressing the attack key while in collision
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            Damageable target = collision.gameObject.GetComponent<Damageable>();
            if (target != null)
            {
                target.TakeDamage(damageAmount);
            }
        }
    }
}


//using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
//public class DamageDealer : MonoBehaviour
//{
//    public int damageAmount = 10;
//    private Rigidbody2D rb;
//    private Damageable currentTarget;

//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        currentTarget = collision.gameObject.GetComponent<Damageable>();
//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.GetComponent<Damageable>() == currentTarget)
//        {
//            currentTarget = null;
//        }
//    }

//    private void Update()
//    {
//        if (currentTarget != null && (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)))
//        {
//            currentTarget.TakeDamage(damageAmount);
//            currentTarget = null; // Prevents repeated damage until another collision occurs
//        }
//    }
//}

