using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleGUn : MonoBehaviour
{   
    [Header("Outside variables")]
    [Tooltip("The player attached to tool")]
    public GameObject Player;
    [Tooltip("The rigidbody componenet attached to player")]
    public Rigidbody2D rb;
    [Tooltip("The material being used")]
    public Material Material;
    [Tooltip("Layermask of player")]
    public LayerMask mask;
    private RaycastHit2D hit;
    private bool wait;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shot());
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Movement>().on)
        {
            hit = Physics2D.Raycast(transform.position, -(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)), 10, ~mask);
            if (wait)
            {
                Material.color = Color.red;
            }
            else
            {
                Material.color = Color.green;
            }
            if (Input.GetMouseButtonDown(0) && !wait)
            {
                if (hit.collider != null)
                {
                    Player.transform.position = hit.point;
                    rb.AddForce(Vector2.up * Mathf.Clamp(Vector2.Angle(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)), 0, 180), ForceMode2D.Impulse);
                    wait = true;

                }
            }
        }
    }
    private void OnEnable()
    {
        StartCoroutine(Shot());
    }
    public IEnumerator Shot()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            wait = false;
            yield return wait == false;
        }
    }
}
