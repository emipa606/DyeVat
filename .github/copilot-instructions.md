# GitHub Copilot Instructions for Dye Vat (Continued) Mod

## Mod Overview and Purpose

The **Dye Vat (Continued)** mod is an update to Sam’s original Dye Vat mod for RimWorld. The primary purpose of this mod is to introduce a dye vat that allows players to dye cloth into a wide range of bright colors, expanding the customization options in the game. Additionally, the mod now includes the functionality to bleach different colored cloth simultaneously, further enhancing the versatility of the dye vat.

## Key Features and Systems

### Available Colors

Players can now dye cloth into the following colors:

- Red
- Pink
- Magenta
- Purple
- Violet
- Blue
- Light Blue
- Cyan
- Turquoise
- Lime
- Green
- Yellow
- Orange
- Maroon
- Navy Blue
- Black
- Grey
- White

### Bleaching Functionality

The mod includes a new feature where players can bleach different colored cloth at the same time. This adds a new layer of complexity and strategy to cloth management and dyeing in the game.

### Integration with Other Mods

The Dye Vat (Continued) mod is compatible with several other mods, including:

- **Glitter Tech**
- **Glitter Tech (no surgery)**
- **Tilled Soil**
- **Furnace**
- **Fishing Nets**

## Coding Patterns and Conventions

### C# Files

- **CompGTReplaceThing.cs**:
  - **Types**: `CompGTReplaceThing`
  - **Members**: 
    - `checkCountDown`
    - `CompTick`
    - `CompTickRare`
    - `PostSpawnSetup`
    - `Props`
    - `resetCountdown`
    - `tryReplace`

- **CompProperties_GTReplaceThing.cs**:
  - **Types**: `CompProperties_GTReplaceThing`
  - **Members**:
    - `CompProperties_GTReplaceThing`

### XML Files

- **Recipes_DyeVat_Production.xml**: Contains definitions for dye vat recipes.
- **ResearchProjects_DyeVat_Tier1.xml**: Contains definitions for research projects related to the dye vat.
- **ThingCategories.xml**: Contains definitions for thing categories.
- **Buildings_DyeVat_Production.xml**: Contains definitions for dye vat buildings.
- **Items_Resource_DyeVat_Stuff.xml**: Contains definitions for dye vat resources.

## XML Integration

The mod heavily relies on XML for defining game entities, such as recipes, research projects, and building definitions. Developers should familiarize themselves with the XML structure and conventions used in the RimWorld modding community to ensure compatibility and functionality.

### Example XML Definition

xml
<ThingDef Name="DyeVat" abstract="false">
  <label>Dye Vat</label>
  <description>A machine for dyeing and bleaching cloth.</description>
  <defName>DyeVat</defName>
  <thingCategories>
    <li>Buildings</li>
  </thingCategories>
  <!-- Additional properties and configurations -->
</ThingDef>


## Harmony Patching

Harmony is a popular patching library used in RimWorld modding to modify existing game code. The Dye Vat (Continued) mod likely uses Harmony to patch various game functionalities to integrate the dye vat.

### Example Harmony Patch

csharp
using HarmonyLib;
using RimWorld;
using Verse;

namespace DyeVat.HarmonyPatches
{
    [HarmonyPatch(typeof(WorkGiver_DyeCloth), "JobOnThing")]
    public static class Patch_WorkGiver_DyeCloth_JobOnThing
    {
        public static void Postfix(ref Job __result, Pawn pawn, Thing t)
        {
            if (t is Apparel apparel)
            {
                // Custom logic for dyeing cloth
            }
        }
    }
}


## Suggestions for Copilot

### Code Snippets

- **Creating a new dye vat recipe**:
  csharp
  public static void CreateDyeRecipe()
  {
      var recipe = new RecipeDef
      {
          defName = "DyeCloth",
          label = "Dye Cloth",
          description = "Dye cloth into a variety of bright colors.",
          category = RecipeCategory.Crafting,
          workAmount = 10f,
          ingredients = new List<IngredientCount>
          {
              new IngredientCount(ThingDefOf.Cloth, 1),
              new IngredientCount(ThingDef.Named("Dye"), 1)
          },
          product = new ThingDefCountClass(ThingDef.Named("DyedCloth"), 1)
      };
      DefDatabase<RecipeDef>.Add(recipe);
  }
  

- **Bleaching cloth logic**:
  csharp
  public static void BleachCloth(Apparel apparel)
  {
      if (apparel.Color != Color.white)
      {
          apparel.SetColor(Color.white);
          Messages.Message("Cloth has been bleached.", apparel, MessageTypeDefOf.TaskCompletion);
      }
  }
  

### XML Templates

- **Recipe Definition Template**:
  xml
  <RecipeDef Name="DyeCloth">
    <label>Dye Cloth</label>
    <description>Dye cloth into a variety of bright colors.</description>
    <category>Crafting</category>
    <workAmount>10</workAmount>
    <ingredients>
      <li>
        <thingDef>Cloth</thingDef>
        <count>1</count>
      </li>
      <li>
        <thingDef>Dye</thingDef>
        <count>1</count>
      </li>
    </ingredients>
    <products>
      <li>
        <thingDef>DyedCloth</thingDef>
        <count>1</count>
      </li>
    </products>
  </RecipeDef>
  

- **Building Definition Template**:
  xml
  <ThingDef Name="DyeVat" abstract="false">
    <label>Dye Vat</label>
    <description>A machine for dyeing and bleaching cloth.</description>
    <defName>DyeVat</defName>
    <thingCategories>
      <li>Buildings</li>
    </thingCategories>
    <comps>
      <li>
        <compClass>CompProperties_GTReplaceThing</compClass>
        <props>
          <!-- Additional properties -->
        </props>
      </li>
    </comps>
  </ThingDef>
  

By following these guidelines and utilizing the suggestions provided, developers can contribute effectively to the Dye Vat (Continued) mod, enhancing its features and improving the overall player experience in RimWorld.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

