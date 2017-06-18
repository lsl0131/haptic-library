﻿using Bhaptics.Tac;
using UnityEngine;

public class Manager_HandModel : MonoBehaviour
{
    /* All dots should be registered */
    [SerializeField] private GameObject[] Dots;

    private Transform[] transforms = null;
    private MeshRenderer[] renderers = null;
	/* Initialization,default colors and scales of dots can be modified by user */
	void Start ()
	{
	    transforms = new Transform[Dots.Length];
        renderers = new MeshRenderer[Dots.Length];
        for (int i = 0; i< 20; i++)
        {
            transforms[i] = Dots[i].GetComponent<Transform>();
            if (transforms[i] != null)
            {
                transforms[i].localScale = new Vector3(4.3f, 0.14f, 4.3f);
            }
            renderers[i] = Dots[i].GetComponent<MeshRenderer>();

            if (renderers[i] != null)
            {
                renderers[i].material.color = new Color(0.8f, 0.8f, 0.8f, 0.2f);
            }
        }
	}

    /* Change the color and the scale of the dot according to haptic feedback */
    void UpdateFeedbacks(HapticFeedback feedback)
    {
        if (transform == null)
        {
            print("transform is null");
            return;
        }

        for (int i = 0; i < 20; i++)
        {
            var scale = feedback.Values[i] / 100f;

            if (transforms[i] != null)
            {
                transforms[i].localScale = new Vector3(4.3f + 3.0f * (scale * (8f / 10f)), 0.14f, 4.3f + 3.0f * (scale * (8f / 10f)));
            }

            if (renderers[i] != null)
            {
                renderers[i].material.color = new Color(0.8f + scale * 0.2f, 0.8f + scale * 0.01f, 0.8f - scale * 0.79f, 0.2f - 0.2f * scale);
            }
        }
    }
}