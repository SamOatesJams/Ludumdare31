﻿using UnityEngine;using System.Collections;public class MuteButton : MonoBehaviour {    /// <summary>    /// Is audio muted?    /// </summary>    private bool m_muted = false;    /// <summary>    /// The key for the mute save option    /// </summary>    public const string VAR_MUTED = "Muted";    /// <summary>    /// The image used for the mute button    /// </summary>    private UnityEngine.UI.Image m_speakerIcon = null;    // Use this for initialization	void Awake ()     {        m_speakerIcon = this.GetComponent<UnityEngine.UI.Image>();        if (m_speakerIcon == null)        {            Debug.LogError(string.Format("The button {0} does not have a speaker icon image component", this.name));        }        MuteAudio(PlayerPrefs.GetInt(MuteButton.VAR_MUTED, 0) == 1);	}	    private void MuteAudio(bool mute)    {
        AudioListener.pause = mute;        m_speakerIcon.color = mute ? Color.black : Color.white;        m_muted = mute;        PlayerPrefs.SetInt(MuteButton.VAR_MUTED, mute ? 1 : 0);    }    /// <summary>    ///     /// </summary>	public void OnClick()    {        MuteAudio(!m_muted);    }}