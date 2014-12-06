﻿using UnityEngine;
    /// <summary>
    /// The speed of the bullet
    /// </summary>
    public float Speed = 1.0f;

    /// <summary>
    /// The rigid body of the bullet
    /// </summary>
    protected Rigidbody2D m_body = null;

    /// <summary>
    /// The direction of the fired bullet
    /// </summary>
    protected Vector3 m_fireDirection = Vector3.zero;
        Setup();
    {
        m_body = this.GetComponent<Rigidbody2D>();
        if (m_body == null)
        {
            Debug.LogError(string.Format("The bullet {0} does not have a rigid body 2d component.", this.name));
            this.gameObject.SetActive(false);
        }
    }

    // Called when the player enters a collision
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
    }
        this.transform.position = startPosition;
        m_fireDirection = (new Vector3(direction.x, direction.y, 0.0f)) * this.Speed;
        this.gameObject.SetActive(true);