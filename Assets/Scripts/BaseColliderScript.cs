using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseColliderScript : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<GameHealthDisplay>().DecreaseGameHealth(1);
        Destroy(collision.gameObject);
    }
}
