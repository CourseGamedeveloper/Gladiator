using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealt = 100;
    int currentHealth;
    private Animator animator;
    public GameObject winText; // Reference to the Win Text GameObject


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        currentHealth = maxHealt;

        if (winText == null)
        {
            winText = GameObject.Find("WinText");
        }

        if (winText != null)
        {
            winText.SetActive(false); // Ensure the text is hidden at start
        }
    }

    public void Take_Damage(int damage)
    {
        currentHealth -= damage;

        Debug.Log($"Enemy {name} took {damage} damage. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        animator.SetTrigger("death");
        StartCoroutine(DestroyAfterAnimation()); // Wait for the animation before destroying this object


    }
    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        // Show the "You Win" text
        if (winText != null)
        {
            winText.SetActive(true);
        }
        Destroy(gameObject); // Destroy this GameObject after the animation is done
    }


}
