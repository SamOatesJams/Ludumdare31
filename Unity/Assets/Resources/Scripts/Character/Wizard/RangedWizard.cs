﻿using UnityEngine;
using System.Collections;

public class RangedWizard : MeleeCharacter
{
    /// <summary>
    /// The number of seconds between spell casts
    /// </summary>
    public float FireRate = 1.0f;

    /// <summary>
    /// The last time a spell was cast
    /// </summary>
    private float m_lastFireTime = 0.0f;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        var isAgroed = false;
        var isAttacking = false;

        GameObject closestPlayer = null;
        float distanceToClosestPlayer = float.MaxValue;

        var players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 0)
        {
            // No player left
            return;
        }

        foreach (var player in players)
        {
            var toPlayerVector = (Vector2)player.transform.position - (Vector2)this.transform.position;
            var distance = toPlayerVector.magnitude;

            if (distance <= distanceToClosestPlayer)
            {
                closestPlayer = player;
                distanceToClosestPlayer = distance;
            }
        }

        if (distanceToClosestPlayer <= this.AttackRange)
        {
            isAttacking = true;

            if (Time.time - m_lastFireTime >= this.FireRate)
            {
                var toPlayerVector = (Vector2)closestPlayer.transform.position - (Vector2)this.transform.position;
                this.FireBullet(toPlayerVector.normalized);
                m_lastFireTime = Time.time;
            }
        }
        else if (distanceToClosestPlayer <= this.AgroRange || (m_lastDamageTime != -1.0f && (Time.time - m_lastDamageTime) < 2.0f))
        {
            var toPlayerVector = (Vector2)closestPlayer.transform.position - (Vector2)this.transform.position;
            var movement = toPlayerVector.normalized;
            this.transform.position = this.transform.position + ((Vector3)movement * this.Speed);
            isAgroed = true;
        }

        var animController = GetAnimationController();
        if (isAttacking)
        {
            animController.PlayAttackAnimation();
            if (!m_audioSource.isPlaying)
            {
                m_audioSource.clip = this.AttackAudio;
                m_audioSource.Play();
            }
        }
        else if (isAgroed)
        {
            animController.PlayWalkAnimation();
        }
        else
        {
            animController.PlayIdleAnimation();
        }
    }
}