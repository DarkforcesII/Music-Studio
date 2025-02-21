using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeInteractions : Interactable
{
    private Renderer m_renderer;

    void Start()
    {
        m_renderer = GetComponent<Renderer>();
    }

    /// <summary>
    /// Called when the collision depth with this interactable changes
    /// </summary>
    public override void UpdateCollisionDepth(InteractableTool interactableTool, InteractableCollisionDepth oldCollisionDepth, 
        InteractableCollisionDepth collisionDepth)
    {
        if (collisionDepth == InteractableCollisionDepth.Action)
        {

            FingerTipPokeTool tool = (FingerTipPokeTool)interactableTool;
            OVRPlugin.HandFinger _fingerToFollow = tool._fingerToFollow;

            switch (_fingerToFollow)
            {
                case OVRPlugin.HandFinger.Thumb:
                    m_renderer.material.color = Color.green;
                    break;
                case OVRPlugin.HandFinger.Index:
                    m_renderer.material.color = Color.blue;
                    break;
                case OVRPlugin.HandFinger.Middle:
                    m_renderer.material.color = Color.red;
                    break;
                case OVRPlugin.HandFinger.Ring:
                    m_renderer.material.color = Color.yellow;
                    break;
                case OVRPlugin.HandFinger.Pinky:
                    m_renderer.material.color = Color.black;
                    break;
                default:
                    m_renderer.material.color = Color.white;
                    break;
            }
        }
        else
        {
            m_renderer.material.color = Color.white;
        }
    }
}