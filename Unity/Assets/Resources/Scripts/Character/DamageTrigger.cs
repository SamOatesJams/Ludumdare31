﻿using UnityEngine;

    void OnTriggerEnter2D(Collider2D other)
    {
        var bullet = other.GetComponent<IBullet>();
        if (bullet != null)
        {
            bullet.OnHit(m_character);
        }
    }