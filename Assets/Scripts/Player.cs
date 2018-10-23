using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public override IEnumerator SelectCommand (List<ActionBase> actionList, List<Character> targetList) {
        bool isSelect = false;
        while(!isSelect) {
            // 攻撃
            if (Input.GetKeyDown(KeyCode.A)) {
                Debug.Log("Push A!");
                int index = Random.Range(0, targetList.Count);
                var list = new List<Character>() { targetList[index] };
                actionList.Add(new Attack(this, list));
                isSelect = true;
            }

            yield return null;
        }
    }
}
