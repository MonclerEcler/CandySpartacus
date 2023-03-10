using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyWaveSpawner : MonoBehaviour
{
	public enum SpawnState { SPAWNING, WAITING, COUNTING };

	[System.Serializable]
	public class Wave
	{
		public string name;
		public GameObject enemy;
		public int count;
		public float rate;
		public bool shouldWaitWaveClear = true;
	}

	public Wave[] waves;
	private int nextWave = 0;
	private int currentWave = 0;

	public int NextWave
	{
		get { return nextWave + 1; }
	}

	public Transform[] spawnPoints;
	public float timeBetweenWaves = 5f;

	private float waveCountdown;
	public float WaveCountdown
	{
		get { return waveCountdown; }
	}

	private float searchCountdown = 1f;

	private SpawnState state = SpawnState.COUNTING;
	public SpawnState State
	{
		get { return state; }
	}

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void LateUpdate()
	{

		if (state == SpawnState.WAITING)
		{
			if (!EnemyIsAlive() || !waves[currentWave].shouldWaitWaveClear)
			{
				WaveCompleted(waves[currentWave]);
			}
			else
			{
				return;
			}
		}

		if (waveCountdown <= 0 || nextWave == 0)
		{
			if (state != SpawnState.SPAWNING)
			{
				StartCoroutine(SpawnWave(waves[nextWave]));
			}
		}
		else
		{
			waveCountdown -= Time.deltaTime;
		}
	}

	private void WaveCompleted(Wave _wave)
	{
		state = SpawnState.COUNTING;
		waveCountdown = timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1)
		{

			this.enabled = false;
		}
		else
		{
			nextWave++;
			currentWave++;
		}
	}

	private bool EnemyIsAlive()
	{
		searchCountdown -= Time.deltaTime;
		if (searchCountdown <= 0f)
		{
			searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag("Enemy") == null)
			{
				return false;
			}
		}
		return true;
	}

	private IEnumerator SpawnWave(Wave _wave)
	{
		state = SpawnState.SPAWNING;

		for (int i = 0; i < _wave.count; i++)
		{
			SpawnEnemy(_wave.enemy);
			yield return new WaitForSeconds(1f / _wave.rate);
		}

		state = SpawnState.WAITING;

		yield break;
	}

	private void SpawnEnemy(GameObject _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject enemyObject = Instantiate(_enemy, _sp.position, _sp.rotation);

    }
}