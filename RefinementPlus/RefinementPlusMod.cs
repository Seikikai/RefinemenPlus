using Harmony;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RefinementPlus
{

	public class RefinementPlus_Data
	{
		public static List<string> recipesIDs = new List<string>();

		public static List<string> getRecipesIDs() { return recipesIDs; }
	}

	/*
	[HarmonyPatch(typeof(ComplexRecipe), "GetUIIcon")]
	public class RefinementPlusRecipeIcons : RefinementPlusData
	{
		public static void Prefix(ComplexRecipe __instance)
		{
			AccessTools.Field(typeof(ComplexRecipe), "nameDisplay").SetValue(__instance, ComplexRecipe.RecipeNameDisplay.Result);
		}
	}*/
	/*
	[HarmonyPatch(typeof(ComplexRecipe), "GetUIIcon")]
	public class RefinementPlusRecipeIcons : RefinementPlusData
	{
		public static Sprite Prefix(ComplexRecipe __instance)
		{
			Sprite result = null;
			Tag tag = __instance.results[0].material;
			GameObject prefab = Assets.GetPrefab(tag);
			KBatchedAnimController component = prefab.GetComponent<KBatchedAnimController>();
			result = Def.GetUISpriteFromMultiObjectAnim(component.AnimFiles[0], "ui", false, string.Empty);

			return result;
	}	}
	*/

	[HarmonyPatch(typeof(KilnConfig), "ConfgiureRecipes")]
	public class RefinementPlus_KilnRecipes
	{
		public static void Postfix()
		{
			Debug.Log("Refinement Plus - KilnConfig Postfix: ");

			Methods mtd = new Methods();

			/* Burn Cloth */			mtd.burnCloth();
			/* Burn Rot */				mtd.burnRot();
			//* Corpses To Coal */		mtd.corpseToCoal();
			/* Seeds To Coal */			mtd.seedsToCoal();
	}	}

	[HarmonyPatch(typeof(RockCrusherConfig), "ConfigureBuildingTemplate", new Type[] { typeof(GameObject), typeof(Tag) })]
	public class RefinementPlus_RockCrusherRecipes
	{
		private static bool Prefix(RockCrusherConfig __instance, ref GameObject go)
		{
			Debug.Log("Refinement Plus - RockCrusherConfig Postfix: ");

			Prioritizable.AddRef(go);
			go.AddOrGet<DropAllWorkable>();
			go.AddOrGet<BuildingComplete>().isManuallyOperated = true;
			ComplexFabricator complexFabricator = go.AddOrGet<ComplexFabricator>();
			complexFabricator.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;
			complexFabricator.duplicantOperated = true;
			go.AddOrGet<FabricatorIngredientStatusManager>();
			go.AddOrGet<CopyBuildingSettings>();
			ComplexFabricatorWorkable complexFabricatorWorkable = go.AddOrGet<ComplexFabricatorWorkable>();
			BuildingTemplates.CreateComplexFabricatorStorage(go, complexFabricator);
			complexFabricatorWorkable.overrideAnims = new KAnimFile[]
			{	Assets.GetAnim("anim_interacts_rockrefinery_kanim") };
			complexFabricatorWorkable.workingPstComplete = "working_pst_complete";

			Methods mtd = new Methods();

			/* Clay To Slime */					mtd.clayToSlime();
			//* Corpses To Meal And Lime */		mtd.corpseToMeal();
			/* Eggs To Lime */					mtd.limeCrushing();
			/* Fossils To Lime And Sand */		mtd.fossilCrushing();
			/* Mafic Rock To Regolith */		mtd.maficToRegolith();
			/* Minerals To Sand Overhaul */		mtd.mineralsCrushing();
			/* Ores To Refined */				mtd.oresToRefined();
			/* Organic To Fert */				mtd.organicToFert();
			/* Refined To Ores */				mtd.refinedToOres();
			/* Salt To Table Salt */			mtd.saltCrushing();
			/* Crush Ice */						mtd.snowCone();

			return false;
	}	}

}