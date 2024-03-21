using Verse;

namespace GT_Utilities;

public class CompGTReplaceThing : ThingComp
{
    private int ticksUntilReplace;

    private CompProperties_GTReplaceThing Props => (CompProperties_GTReplaceThing)props;

    public override void PostSpawnSetup(bool respawningAfterLoad)
    {
        base.PostSpawnSetup(respawningAfterLoad);
        if (Props.replaceInstantly)
        {
            TryReplace();
        }

        ResetCountdown();
    }

    public override void CompTick()
    {
        base.CompTick();
        ticksUntilReplace--;
        CheckCountDown();
    }

    public override void CompTickRare()
    {
        base.CompTickRare();
        ticksUntilReplace -= 250;
        CheckCountDown();
    }

    private void TryReplace()
    {
        var thing = ThingMaker.MakeThing(Props.thingToSpawn);
        thing.stackCount = 10;
        var map = parent.Map;
        var position = parent.Position;
        parent.Destroy(DestroyMode.WillReplace);
        GenSpawn.Spawn(thing, position, map);
    }

    private void CheckCountDown()
    {
        if (ticksUntilReplace <= 0)
        {
            TryReplace();
        }
    }

    private void ResetCountdown()
    {
        ticksUntilReplace = Props.replaceIntervalRange.RandomInRange;
    }
}