﻿using UnityEngine;
    /// <summary>
    /// The animator of the character
    /// </summary>
    protected Animator m_animator = null;
        m_animator = this.GetComponent<Animator>();
        if (m_animator == null)
        {
            Debug.LogError(string.Format("The character {0} does not have an animator component.", this.name));
            this.gameObject.SetActive(false);
        }