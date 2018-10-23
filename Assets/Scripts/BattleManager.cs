using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    private static readonly int MAX_ENEMY_COUNT = 3;

    [SerializeField] private Party party;
    [SerializeField] private Enemy enemyPrefab;

    private List<Character> enemyList;
    private List<ActionBase> playerActionList;
    private List<ActionBase> enemyActionList;

    private void Awake() {
        enemyList = new List<Character>();
        playerActionList = new List<ActionBase>();
        enemyActionList = new List<ActionBase>();
    }

    // Use this for initialization
    void Start () {
        Initialize();

        StartCoroutine(Battle());
	}
	
	// Update is called once per frame
	void Update () {

    }

    void Initialize() {
        party.Initialize();

        for (int i = 0; i < MAX_ENEMY_COUNT; ++i) {
            var enemy = Instantiate<Enemy>(enemyPrefab, transform, false);
            enemy.name += i.ToString();
            var pos = enemy.transform.localPosition;
            pos.x = -5;
            pos.y = 2 - i * 2;
            enemy.transform.localPosition = pos;
            enemyList.Add(enemy);
        }
    }

    IEnumerator Battle() {
        playerActionList.Clear();
        enemyActionList.Clear();

        yield return StartCoroutine(PlayerAction());
        yield return StartCoroutine(EnemyAction());
    }

    IEnumerator PlayerAction() {
        yield return StartCoroutine(party.SelectCommands(playerActionList, enemyList));

        foreach (var action in playerActionList) {
            action.Action();
        }
    }

    IEnumerator EnemyAction() {
        foreach (var enemy in enemyList) {
            yield return StartCoroutine(enemy.SelectCommand(enemyActionList, party.playerListToCharacter));
        }

        foreach (var action in enemyActionList) {
            action.Action();
        }
    }
}
