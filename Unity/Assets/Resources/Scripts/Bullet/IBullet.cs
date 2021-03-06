﻿using UnityEngine;using System.Collections;public abstract class IBullet : MonoBehaviour {    /// <summary>    /// The speed of the bullet    /// </summary>    public float Speed = 1.0f;    /// <summary>    /// The rigid body of the bullet    /// </summary>    protected Rigidbody2D m_body = null;    /// <summary>    /// The direction of the fired bullet    /// </summary>    protected Vector3 m_fireDirection = Vector3.zero;	// Use this for initialization	protected virtual void Start ()     {        Setup();	}    // Setup the bullet    public void Setup()    {        m_body = this.GetComponent<Rigidbody2D>();        if (m_body == null)        {            Debug.LogError(string.Format("The bullet {0} does not have a rigid body 2d component.", this.name));            this.gameObject.SetActive(false);        }    }		// Update is called once per physics update    protected virtual void FixedUpdate()    {	}    // Called when the player enters a collision    protected virtual void OnCollisionEnter2D(Collision2D collision)    {    }    // Fire a bullet in a given direction    public virtual void Fire(Vector2 startPosition, Vector2 direction)    {        this.transform.position = startPosition;
        m_fireDirection = new Vector3(direction.x, direction.y, 0.0f) * this.Speed;

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90.0f, Vector3.forward);        this.gameObject.SetActive(true);    }    /// <summary>
    /// Called when a bullet hits a character
    /// </summary>
    /// <param name="character"></param>    public virtual void OnHit(ICharacter character)
    {

    }}