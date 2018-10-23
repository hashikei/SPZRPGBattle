using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [SerializeField] private int _hp;
    [SerializeField] private int _atk;

    public int hp {
        get { return _hp; }
        protected set { _hp = value; }
    }
    public int atk {
        get { return _atk; }
        protected set { _atk = value; }
    }

    public void Damage(int damage) {
        hp = Mathf.Max(hp - damage, 0);

        Debug.Log("name:" + name + " / hp:" + hp.ToString());
    }

    public abstract IEnumerator SelectCommand(List<ActionBase> actionList, List<Character> targetList);
}
