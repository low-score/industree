﻿using UnityEngine;
using System.Collections;

public class InstantiateOnPlayerSpawnpointAction : InstantiateOnPositionAction {

	protected override Vector3 GetInitialActionEntityPosition(Player player, float actionDirection){
		GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(Tags.spawnPoint);

        GameObject leftSpawnPoint = null, rightSpawnPoint = null;

        foreach(var spawnPoint in spawnPoints){
        	if(spawnPoint.transform.position.x > 0){
        		rightSpawnPoint = spawnPoint;
        	}
        	else {
        		leftSpawnPoint = spawnPoint;
        	}
        }

        if(actionDirection > 0){
        	return leftSpawnPoint.transform.position;
        }
        else {
        	return rightSpawnPoint.transform.position;
        }
	}
}