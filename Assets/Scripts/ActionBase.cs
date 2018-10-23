using System.Collections.Generic;

public abstract class ActionBase {

    protected Character self;
    protected List<Character> targetList;

    public ActionBase(Character self, List<Character> targetList) {
        this.self = self;
        this.targetList = targetList;
    }

    public abstract void Action();
}
