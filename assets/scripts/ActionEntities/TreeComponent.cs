﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// TODO: fix animations
public class TreeComponent: MonoBehaviour {

    public int[] creditsPerSec = { 1, 2, 3 };
    public int[] reducePollution = { 1, 2, 3 };
    public float timeBetweenClean;
	
	public float[] minLevelUpTimes;
	public float[] maxLevelUpTimes;

    public String plantAnim;
    public String[] idleAnim;
    public String[] growAnim;

    public Player player;

    private float dieSpeed = 0f;
	
	private Levelable levelable;
    private Damagable damagable;
    private Polluting polluting;
	
	public AudioClip levelUpSound;

	public Damagable Damagable { get { return damagable; } }
	
	private void Awake(){
		levelable = GetComponent<Levelable>();
		damagable = GetComponent<Damagable>();
		polluting = GetComponent<Polluting>();
		Timer.AddTimerToGameObject(gameObject, timeBetweenClean, OnCleanTimerTick);
	}

	private void Start(){
		levelable.LevelUp += OnLevelUp;
		damagable.BeforeDestroy += OnTreeDestroy;

		for(int i = 0; i < levelable.levelUpTimes.Length; i++){
			levelable.levelUpTimes[i] = UnityEngine.Random.Range(minLevelUpTimes[i], maxLevelUpTimes[i]);
		}
        polluting.pollution = -reducePollution[0];

        animation.Play(plantAnim);
        audio.PlayOneShot(levelUpSound);
	}

	private void OnLevelUp(Levelable levelable){
        polluting.pollution = -reducePollution[levelable.Level - 2];

		animation.Play(growAnim[levelable.Level - 2]);		
		audio.PlayOneShot(levelUpSound);
	}

	private void OnTreeDestroy(Damagable damagable){
		Destroy(gameObject, 2);
        levelable.LevelUp -= OnLevelUp;
        damagable.BeforeDestroy -= OnTreeDestroy;
	}

	private void OnCleanTimerTick(Timer timer){
		player.IncreaseCredits(creditsPerSec[levelable.Level - 1]);
	}

    public void Update(){
        if (damagable.Destroyed){
            dieAnimation();
        }

        // Plays the animation after the last animation
        animation.PlayQueued(idleAnim[levelable.Level - 1], QueueMode.CompleteOthers);
    }

    private void dieAnimation(){
        dieSpeed += 0.1f;

        if (transform.rotation == Quaternion.Euler(-90,0,0)){
            transform.position = -transform.up * Time.deltaTime * dieSpeed;
        }
        else{
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-90, 0, 0), dieSpeed);
        }
    }
}

