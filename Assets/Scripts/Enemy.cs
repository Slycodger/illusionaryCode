using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [Header("Variables")]
    [Tooltip("How the enemy should move on the x axis")]
    public AnimationCurve XPositionLoop;
    [Tooltip("How the enemy should move on the y axis")]
    public AnimationCurve YPositionLoop;
    [Tooltip("The layer of the player")]
    public LayerMask playerLayer;
    public enum Sides { None, Left, Right, Top, Bottom};
    [Tooltip("The side that will destroy the enemy")]
    public Sides destroySide;
    [Tooltip("Decides if it will add or set the position of the enemy")]
    public bool SetPosition = false;
    private RaycastHit2D Left;
    private RaycastHit2D Right;
    private RaycastHit2D Top;
    private RaycastHit2D Bottom;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!SetPosition)
        {
            transform.localPosition += new Vector3(XPositionLoop.Evaluate(Time.time), YPositionLoop.Evaluate(Time.time), 0);
        }
        if (SetPosition)
        {
            transform.localPosition = new Vector3(XPositionLoop.Evaluate(Time.time), YPositionLoop.Evaluate(Time.time), 0);

        }
        Left = Physics2D.Linecast(transform.TransformPoint(-0.6f,0.49f,0), transform.TransformPoint(-0.6f, -0.49f, 0),playerLayer);
        Right = Physics2D.Linecast(transform.TransformPoint(0.6f, 0.49f, 0), transform.TransformPoint(0.6f, -0.49f, 0),playerLayer);
        Top = Physics2D.Linecast(transform.TransformPoint(0.49f, 0.6f, 0), transform.TransformPoint(-0.49f, 0.6f, 0),playerLayer);
        Bottom = Physics2D.Linecast(transform.TransformPoint(0.49f, -0.6f, 0), transform.TransformPoint(-0.49f, -0.6f, 0),playerLayer);
        

        
    }
    private void LateUpdate()
    {
        if (Left)
        {
            if (destroySide == Sides.Left)
            {
                Destroy(gameObject);
            }
            else
            {
                Left.collider.gameObject.transform.position = new Vector2(0, 0);
            }
        }
        if (Right)
        {
            if (destroySide == Sides.Right)
            {
                Destroy(gameObject);
            }
            else
            {
                Right.collider.gameObject.transform.position = new Vector2(0, 0);
            }
        }
        if (Top)
        {
            if (destroySide == Sides.Top)
            {
                Destroy(gameObject);
            }
            else
            {
                Top.collider.gameObject.transform.position = new Vector2(0, 0);
            }
        }
        if (Bottom)
        {
            if (destroySide == Sides.Bottom)
            {
                Destroy(gameObject);
            }
            else
            {
                Bottom.collider.gameObject.transform.position = new Vector2(0, 0);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.TransformPoint(-0.6f, 0.49f, 0), transform.TransformPoint(-0.6f, -0.49f, 0));
        Gizmos.DrawLine(transform.TransformPoint(0.6f, 0.49f, 0), transform.TransformPoint(0.6f, -0.49f, 0));
        Gizmos.DrawLine(transform.TransformPoint(0.49f, 0.6f, 0), transform.TransformPoint(-0.49f, 0.6f, 0));
        Gizmos.DrawLine(transform.TransformPoint(0.49f, -0.6f, 0), transform.TransformPoint(-0.49f, -0.6f, 0));
    }
}
