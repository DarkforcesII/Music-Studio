using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Interactable))]
public class CustomTriggerZone : MonoBehaviour, ColliderZone
{
    public Collider Collider => GetComponent<Collider>();

    public Interactable ParentInteractable => GetComponent<Interactable>();

    public InteractableCollisionDepth CollisionDepth => InteractableCollisionDepth.Action;
}