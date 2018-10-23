using System.Collections.Generic;

public class Attack : ActionBase {

    public Attack(Character self, List<Character> targetList) : base(self, targetList) {}

    public override void Action() {
        int damage = self.atk;
        targetList[0].Damage(damage);
    }
}
