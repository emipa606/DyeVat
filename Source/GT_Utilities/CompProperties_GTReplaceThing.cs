using Verse;

namespace GT_Utilities
{
    public class CompProperties_GTReplaceThing : CompProperties
    {
        public bool replaceInstantly = true;

        public IntRange replaceIntervalRange = new IntRange(10, 100);

        public int spawnCount = 1;
        public ThingDef thingToSpawn;

        public CompProperties_GTReplaceThing()
        {
            compClass = typeof(CompGTReplaceThing);
        }
    }
}