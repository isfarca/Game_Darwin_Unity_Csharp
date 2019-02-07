using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    [SerializeField] private SpecialAbilities _specialAbilitiesScript;
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //slow falling
        other.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        //slow jumping
        other.GetComponent<ActionJumpLogic>().JumpForce = 2.5f;
        //jump always enabled
        if (_specialAbilitiesScript.FishActive)
        {
            StopAllCoroutines();
            
            other.GetComponent<ActionJumpLogic>().IsGrounded = true;
        }
        else if (!_specialAbilitiesScript.FishActive)
        {
            StartCoroutine(LoseCountDown());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //slow falling
        other.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        //slow jumping
        other.GetComponent<ActionJumpLogic>().JumpForce = 5.0f;
        other.GetComponent<ActionJumpLogic>().IsGrounded = false;
    }
    
    private static IEnumerator LoseCountDown()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(0);
    }
}