﻿using UnityEngine;

    /// <summary>
    /// The distance a player needs to be for the character to attack them
    /// </summary>
    public float AttackRange = 2.0f;

    /// <summary>
    /// The amount of damage done per hit
    /// </summary>
    public float DamagePerHit = 1.0f;

        var isAgroed = false;
        var isAttacking = false;

        GameObject closestPlayer = null;
        float distanceToClosestPlayer = float.MaxValue;
            var toPlayerVector = player.transform.position - this.transform.position;
            var distance = toPlayerVector.magnitude;
            {
                closestPlayer = player;
                distanceToClosestPlayer = distance;
            }
        }

        if (distanceToClosestPlayer <= this.AttackRange)
        {
            isAttacking = true;
            var character = closestPlayer.GetComponent<ICharacter>();
            character.Damage(this.DamagePerHit);
        }
        else if (distanceToClosestPlayer <= this.AgroRange)
        {
            var toPlayerVector = closestPlayer.transform.position - this.transform.position;
            var movement = toPlayerVector.normalized;
            this.transform.position = this.transform.position + (movement * this.Speed);
            isAgroed = true;
        }
        if (isAttacking)
        {
            animController.PlayAttackAnimation();
            if (!m_audioSource.isPlaying)
            {
                m_audioSource.clip = this.AttackAudio;
                m_audioSource.Play();
            }
        }