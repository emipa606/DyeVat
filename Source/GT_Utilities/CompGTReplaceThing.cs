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
            tryReplace();
        }

        resetCountdown();
    }

    public override void CompTick()
    {
        base.CompTick();
        ticksUntilReplace--;
        checkCountDown();
    }

    public override void CompTickRare()
    {
        base.CompTickRare();
        ticksUntilReplace -= 250;
        checkCountDown();
    }

    private void tryReplace()
    {
        var thing = ThingMaker.MakeThing(Props.thingToSpawn);
        thing.stackCount = 10;
        var map = parent.Map;
        var position = parent.Position;
        parent.Destroy(DestroyMode.WillReplace);
        GenSpawn.Spawn(thing, position, map);
    }

    private void checkCountDown()
    {
        if (ticksUntilReplace <= 0)
        {
            tryReplace();
        }
    }

    private void resetCountdown()
    {
        ticksUntilReplace = Props.replaceIntervalRange.RandomInRange;
    }
}