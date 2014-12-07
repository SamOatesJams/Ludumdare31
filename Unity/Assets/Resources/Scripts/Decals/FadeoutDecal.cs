﻿using UnityEngine;

    /// <summary>
    /// The initial color of the decal
    /// </summary>
    private Color m_initialColor = Color.white;

    /// <summary>
    /// The faded color of the decal
    /// </summary>
    private Color m_fadedColor = Color.white;

        var colorVarience = 0.5f;
        var grayScale = (1.0f - colorVarience) + Random.Range(0.0f, colorVarience);
        m_initialColor = new Color(grayScale, grayScale, grayScale);
        m_fadedColor = new Color(grayScale, grayScale, grayScale, 0.0f);
        m_decal.color = m_initialColor;
                var fadeColor = Color.Lerp(m_initialColor, m_fadedColor, progress);