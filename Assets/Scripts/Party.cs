using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour {

    private static readonly int MAX_MEMBER = 4;

    [SerializeField] private Player playerPrefab;

    private List<Player> playerList;
    public List<Character> playerListToCharacter { get; private set; }

    private void Awake() {
        playerList = new List<Player>(MAX_MEMBER);
        playerListToCharacter = new List<Character>(MAX_MEMBER);
    }

    // Use this for initialization
    void Start () {
		
	}

    public void Initialize() {
        for (int i = 0; i < MAX_MEMBER; ++i) {
            var player = Instantiate<Player>(playerPrefab, transform, false);
            player.name += i.ToString();
            var pos = player.transform.localPosition;
            pos.y = 3 - i * 2;
            player.transform.localPosition = pos;
            playerList.Add(player);
            playerListToCharacter.Add(player);
        }
    }

    public IEnumerator SelectCommands(List<ActionBase> actionList, List<Character> targetList) {
        foreach (var player in playerList) {
            yield return StartCoroutine(player.SelectCommand(actionList, targetList));
        }
    }
}
