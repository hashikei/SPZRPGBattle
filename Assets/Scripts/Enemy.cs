using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    public override IEnumerator SelectCommand(List<ActionBase> actionList, List<Character> targetList) {
        int index = Random.Range(0, targetList.Count);
        var list = new List<Character>() { targetList[index] };
        actionList.Add(new Attack(this, list));
        yield break;
    }
}
