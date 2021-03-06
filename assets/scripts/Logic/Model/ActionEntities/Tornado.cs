﻿using Industree.Miscellaneous;
using Industree.Time;
using Industree.Time.Internal;
using UnityEngine;

public class Tornado :ActionEntity {

    [Range(0, 1)]
    public float damageProbability;
    public float damageInterval;
    public float collisionRadius;
    public float moveRange;

    private Damaging damaging;
    private ITimer damageTimer;

    private void Awake(){
        damaging = GetComponent<Damaging>();
    }

    private void Start(){
        damageTimer = Timing.GetTimerFactory().GetTimer(damageInterval);
        damageTimer.Tick += OnDamageTimerTick;
        Transform planetTransform = GameObject.FindGameObjectWithTag(Tags.planet).transform;
        transform.LookAt(planetTransform.position);
        transform.Rotate(new Vector3(-90, 0, 0));

        foreach (AnimationState state in animation) {
            state.speed = 2.5f;
        }
    }

    private void OnDamageTimerTick(ITimer timer){
        Collider[] colliders = Physics.OverlapSphere(transform.position, collisionRadius, Layers.Building);
        foreach (Collider c in colliders){
            bool isHit = UnityEngine.Random.Range(0f, 1f) <= damageProbability;
            if (isHit){
                damaging.CauseDamage(Utilities.GetMostOuterAncestor(c.transform).GetComponent<Damagable>());
            }
        }   
    }

    private void Update(){
        float moveSpeed = GetComponent<SphericalMover>().moveSpeed;
        GetComponent<SphericalMover>().moveSpeed = Mathf.Lerp(-moveRange, moveRange, Mathf.Sin(Time.time / moveSpeed));
    }

    private void OnDestroy()
    {
        damageTimer.Stop();
    }
}

