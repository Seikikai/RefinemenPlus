using STRINGS;
using System.Collections.Generic;

namespace RefinementPlus
{
	class Methods : RefinementPlusData
	{
		public void burnCloth()
		{
			Dictionary<string, string> vests = new Dictionary<string, string>
			{
				{	"Cool_Vest",	EQUIPMENT.PREFABS.COOL_VEST.NAME	},
				{	"Funky_Vest",	EQUIPMENT.PREFABS.FUNKY_VEST.NAME	},
				{	"Warm_Vest",	EQUIPMENT.PREFABS.WARM_VEST.NAME	}
			};

			Tag coal = SimHashes.Carbon.CreateTag();
			string descBurn = "Burn old {0}";

			foreach (KeyValuePair<string, string> vest in vests)
			{
				ComplexRecipe.RecipeElement[] input = new ComplexRecipe.RecipeElement[]
				{	new ComplexRecipe.RecipeElement(vest.Key, 1)	 };

				ComplexRecipe.RecipeElement[] output = new ComplexRecipe.RecipeElement[]
				{	new ComplexRecipe.RecipeElement(coal, 3)	 };

				ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("Kiln", input, output), input, output);
				recipe.time = 55f;
				recipe.description = string.Format(descBurn, vest.Value);
				recipe.fabricators = new List<Tag> { TagManager.Create("Kiln") };
				recipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;

				recipesIDs.Add(recipe.id);
		}	}

		public void burnRot()
		{
			Tag coal = SimHashes.Carbon.CreateTag();
			string descBurn = "Burn rotten food";

			ComplexRecipe.RecipeElement[] input = new ComplexRecipe.RecipeElement[]
			{	new ComplexRecipe.RecipeElement("RotPile", 100)	};

			ComplexRecipe.RecipeElement[] output = new ComplexRecipe.RecipeElement[]
			{	new ComplexRecipe.RecipeElement(coal, 50)	};

			ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("Kiln", input, output), input, output);
			recipe.time = 35f;
			recipe.description = descBurn;
			recipe.fabricators = new List<Tag> { TagManager.Create("Kiln") };
			recipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;

			recipesIDs.Add(recipe.id);
		}

		public void clayToSlime()
		{
			Tag clay = SimHashes.Clay.CreateTag();
			Tag dirt = SimHashes.ToxicSand.CreateTag();
			Tag slime = SimHashes.SlimeMold.CreateTag();
			string desc = "Mixes {0} with {1} to create {2}";

			ComplexRecipe.RecipeElement[] input = new ComplexRecipe.RecipeElement[]
			{
				new ComplexRecipe.RecipeElement(clay, 200),
				new ComplexRecipe.RecipeElement(dirt, 200)
			};

			ComplexRecipe.RecipeElement[] output = new ComplexRecipe.RecipeElement[]
			{	new ComplexRecipe.RecipeElement(slime, 400) };

			ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("RockCrusher", input, output), input, output);
			recipe.time = 100f;
			recipe.description = string.Format(desc, clay, dirt, slime);
			recipe.fabricators = new List<Tag> { TagManager.Create("RockCrusher") };
			recipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;

			recipesIDs.Add(recipe.id);
		}

		public void limeCrushing()
		{
			Dictionary<string[], float[]> organics = new Dictionary<string[], float[]>
			{
				{	new string[]{"EggShell",		MISC.TAGS.EGGSHELL},						new float[]{5, 5}	},
				{	new string[]{"BabyCrabShell",	ITEMS.INDUSTRIAL_PRODUCTS.CRAB_SHELL.NAME},	new float[]{1, 5}	},
				{	new string[]{"CrabShell",		ITEMS.INDUSTRIAL_PRODUCTS.CRAB_SHELL.NAME},	new float[]{1, 10}	}
			};

			Tag lime = SimHashes.Lime.CreateTag();
			string desc = "Crushes {0} into {1}";

			foreach (KeyValuePair<string[], float[]> organic in organics)
			{
				ComplexRecipe.RecipeElement[] input = new ComplexRecipe.RecipeElement[]
				{	new ComplexRecipe.RecipeElement(organic.Key[0] , organic.Value[0]), };

				ComplexRecipe.RecipeElement[] output = new ComplexRecipe.RecipeElement[]
				{	new ComplexRecipe.RecipeElement(lime, organic.Value[1]) };

				ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("RockCrusher", input, output), input, output);
				recipe.time = 40f;
				recipe.description = string.Format(desc, organic.Key[1], lime);
				recipe.fabricators = new List<Tag> { TagManager.Create("RockCrusher") };
				recipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;

				recipesIDs.Add(recipe.id);
			}
		}

		public void fossilCrushing()
		{
			Tag fossil = SimHashes.Fossil.CreateTag();
			Tag lime = SimHashes.Lime.CreateTag();
			Tag sand = SimHashes.Sand.CreateTag();
			string desc = "Crushes {0} into {1} and {2}";

			ComplexRecipe.RecipeElement[] input = new ComplexRecipe.RecipeElement[]
			{	new ComplexRecipe.RecipeElement(fossil, 100)	 };

			ComplexRecipe.RecipeElement[] output = new ComplexRecipe.RecipeElement[]
			{
				new ComplexRecipe.RecipeElement(lime, 5),
				new ComplexRecipe.RecipeElement(sand, 95)
			};

			ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("RockCrusher", input, output), input, output);
			recipe.time = 40f;
			recipe.description = string.Format(desc, fossil, lime, sand);
			recipe.fabricators = new List<Tag> { TagManager.Create("RockCrusher") };
			recipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;

			recipesIDs.Add(recipe.id);
		}

		public void maficToRegolith()
		{
			Tag mafic = SimHashes.MaficRock.CreateTag();
			Tag regolith = SimHashes.Regolith.CreateTag();
			string desc = "Crushes {0} into {1}";

			ComplexRecipe.RecipeElement[] input = new ComplexRecipe.RecipeElement[]
			{	new ComplexRecipe.RecipeElement(mafic, 100)	  };

			ComplexRecipe.RecipeElement[] output = new ComplexRecipe.RecipeElement[]
			{	new ComplexRecipe.RecipeElement(regolith, 80)	};

			ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("RockCrusher", input, output), input, output);
			recipe.time = 80f;
			recipe.description = string.Format(desc, mafic, regolith);
			recipe.fabricators = new List<Tag> { TagManager.Create("RockCrusher") };
			recipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;

			recipesIDs.Add(recipe.id);
		}

		public void mineralsCrushing()
		{
			Dictionary<Tag, Tag> minerals = new Dictionary<Tag, Tag>
			{
				{	SimHashes.Katairite.CreateTag(),		SimHashes.IronOre.CreateTag()			},
				{	SimHashes.Granite.CreateTag(),			SimHashes.Wolframite.CreateTag()		},
				{	SimHashes.IgneousRock.CreateTag(),		SimHashes.IronOre.CreateTag()			},
				{	SimHashes.Obsidian.CreateTag(),			SimHashes.IronOre.CreateTag()			},
				{	SimHashes.SandStone.CreateTag(),		SimHashes.Cuprite.CreateTag()			},
				{	SimHashes.SedimentaryRock.CreateTag(),	SimHashes.GoldAmalgam.CreateTag()		}
			};

			Tag sand = SimHashes.Sand.CreateTag();
			string desc = "Crushes {0} into {1} and a bit of {2}";

			foreach (KeyValuePair<Tag, Tag> mineral in minerals)
			{
				ComplexRecipe.RecipeElement[] input = new ComplexRecipe.RecipeElement[]
				{
					new ComplexRecipe.RecipeElement(mineral.Key, 100),
				};

				ComplexRecipe.RecipeElement[] output = new ComplexRecipe.RecipeElement[]
				{
					new ComplexRecipe.RecipeElement(sand, 90),
					new ComplexRecipe.RecipeElement(mineral.Value, 10)
				};

				ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("RockCrusher", input, output), input, output);
				recipe.time = 50f;
				recipe.description = string.Format(desc, mineral.Key, sand, mineral.Value);
				recipe.fabricators = new List<Tag> { TagManager.Create("RockCrusher") };
				recipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;

				recipesIDs.Add(recipe.id);
			}
		}

		public void oresToRefined()
		{
			Dictionary<Tag, Tag> ores = new Dictionary<Tag, Tag>
			{
				{	SimHashes.AluminumOre.CreateTag(),		SimHashes.Aluminum.CreateTag()	},
				{	SimHashes.Cuprite.CreateTag(),			SimHashes.Copper.CreateTag()	},
				{	SimHashes.GoldAmalgam.CreateTag(),		SimHashes.Gold.CreateTag()		},
				{	SimHashes.IronOre.CreateTag(),			SimHashes.Iron.CreateTag()		},
				{	SimHashes.Wolframite.CreateTag(),		SimHashes.Tungsten.CreateTag()	}
			};

			Tag sand = SimHashes.Sand.CreateTag();
			string desc = "Crushes {0} into {1} and {2}";

			foreach (KeyValuePair<Tag, Tag> ore in ores)
			{
				ComplexRecipe.RecipeElement[] input = new ComplexRecipe.RecipeElement[]
				{	new ComplexRecipe.RecipeElement(ore.Key, 100)	};

				ComplexRecipe.RecipeElement[] output = new ComplexRecipe.RecipeElement[]
				{
					new ComplexRecipe.RecipeElement(sand, 50),
					new ComplexRecipe.RecipeElement(ore.Value, 50)
				};

				ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("RockCrusher", input, output), input, output);
				recipe.time = 50f;
				recipe.description = string.Format(desc, ore.Key, sand, ore.Value);
				recipe.fabricators = new List<Tag> { TagManager.Create("RockCrusher") };
				recipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;

				recipesIDs.Add(recipe.id);
			}
		}

		public void refinedToOres()
		{
			Dictionary<Tag, Tag> refineds = new Dictionary<Tag, Tag>
			{
				{	SimHashes.Aluminum.CreateTag(),		SimHashes.AluminumOre.CreateTag()	},
				{	SimHashes.Copper.CreateTag(),		SimHashes.Cuprite.CreateTag()		},
				{	SimHashes.Gold.CreateTag(),			SimHashes.GoldAmalgam.CreateTag()	},
				{	SimHashes.Iron.CreateTag(),			SimHashes.IronOre.CreateTag()		},
				{	SimHashes.Tungsten.CreateTag(),		SimHashes.Wolframite.CreateTag()	}
			};

			Tag sand = SimHashes.Sand.CreateTag();
			string desc = "Mixes {0} and {1} into {2}";

			foreach (KeyValuePair<Tag, Tag> refined in refineds)
			{
				ComplexRecipe.RecipeElement[] input = new ComplexRecipe.RecipeElement[]
				{
					new ComplexRecipe.RecipeElement(refined.Key, 50),
					new ComplexRecipe.RecipeElement(sand, 50)
				};

				ComplexRecipe.RecipeElement[] output = new ComplexRecipe.RecipeElement[]
				{	new ComplexRecipe.RecipeElement(refined.Value, 100) };

				ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("RockCrusher", input, output), input, output);
				recipe.time = 50f;
				recipe.description = string.Format(desc, refined.Key, sand, refined.Value);
				recipe.fabricators = new List<Tag> { TagManager.Create("RockCrusher") };
				recipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;

				recipesIDs.Add(recipe.id);
			}
		}

		public void organicToFert()
		{
			List<string> organics = new List<string> { "MushBar", "BasicForagePlant", "RotPile" };
			List<float> organicsCtr = new List<float> { 0.5f, 0.5f, 500f };
			Tag dirt = SimHashes.ToxicSand.CreateTag();
			Tag fert = SimHashes.Fertilizer.CreateTag();
			int idx = 0;
			string desc = "Mixes {0} with {1} to create {2}";

			foreach (string organic in organics)
			{
				ComplexRecipe.RecipeElement[] input = new ComplexRecipe.RecipeElement[]
				{
					new ComplexRecipe.RecipeElement(organic, organicsCtr[idx]),
					new ComplexRecipe.RecipeElement(dirt, 1000)
				};

				ComplexRecipe.RecipeElement[] output = new ComplexRecipe.RecipeElement[]
				{	new ComplexRecipe.RecipeElement(fert, 1500) };

				ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("RockCrusher", input, output), input, output);
				recipe.time = 120f;
				recipe.description = string.Format(desc, organic, dirt, fert);
				recipe.fabricators = new List<Tag> { TagManager.Create("RockCrusher") };
				recipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;

				recipesIDs.Add(recipe.id);

				idx++;
			}
		}

		public void saltCrushing()
		{
			Tag salt = SimHashes.Salt.CreateTag();
			Tag tableSalt = TableSaltConfig.ID.ToTag();
			Tag sand = SimHashes.Sand.CreateTag();
			float num = 5E-05f;
			string desc = "Crushes {0} into {1} and some {2}";

			ComplexRecipe.RecipeElement[] input = new ComplexRecipe.RecipeElement[]
			{	new ComplexRecipe.RecipeElement(salt, 100)  };

			ComplexRecipe.RecipeElement[] output = new ComplexRecipe.RecipeElement[]
			{
				new ComplexRecipe.RecipeElement(tableSalt, 100 * num),
				new ComplexRecipe.RecipeElement(sand, 100 * (1- num))
			};

			ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("RockCrusher", input, output), input, output);
			recipe.time = 120f;
			recipe.description = string.Format(desc, salt, tableSalt, sand);
			recipe.fabricators = new List<Tag> { TagManager.Create("RockCrusher") };
			recipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;

			recipesIDs.Add(recipe.id);
		}

		public void seedsToCoal()
		{
			Dictionary<string, string> seeds = new Dictionary<string, string>
			{
				{	"ForestTreeSeed",					CREATURES.SPECIES.SEEDS.WOOD_TREE.NAME					},
				{	"SwampLilySeed",					CREATURES.SPECIES.SEEDS.SWAMPLILY.NAME					},
				{	"PrickleGrassSeed",					CREATURES.SPECIES.SEEDS.PRICKLEGRASS.NAME				},
				{	"PrickleFlowerSeed",				CREATURES.SPECIES.SEEDS.PRICKLEFLOWER.NAME				},
				{	"BulbPlantSeed",					CREATURES.SPECIES.SEEDS.BULBPLANT.NAME					},
				{	"SaltPlantSeed",					CREATURES.SPECIES.SEEDS.SALTPLANT.NAME					},
				{	"MushroomSeed",						CREATURES.SPECIES.SEEDS.MUSHROOMPLANT.NAME				},
				{	"GasGrassSeed",						CREATURES.SPECIES.SEEDS.GASGRASS.NAME					},
				{	"CactusPlantSeed",					CREATURES.SPECIES.SEEDS.CACTUSPLANT.NAME				},
				{	"BasicSingleHarvestPlantSeed",		CREATURES.SPECIES.SEEDS.BASICSINGLEHARVESTPLANT.NAME	},
				{	"LeafyPlantSeed",					CREATURES.SPECIES.SEEDS.LEAFYPLANT.NAME					},
				{	"BeanPlantSeed",					CREATURES.SPECIES.SEEDS.BEAN_PLANT.NAME					},
				{	"SpiceVineSeed",					CREATURES.SPECIES.SEEDS.SPICE_VINE.NAME					},
				{	"ColdWheatSeed",					CREATURES.SPECIES.SEEDS.COLDWHEAT.NAME					},
				{	"EvilFlowerSeed",					CREATURES.SPECIES.SEEDS.EVILFLOWER.NAME					},
				{	"BasicFabricMaterialPlantSeed",		CREATURES.SPECIES.SEEDS.BASICFABRICMATERIALPLANT.NAME	},
				{	"SeaLettuceSeed",					CREATURES.SPECIES.SEEDS.SEALETTUCE.NAME					},
				{	"ColdBreatherSeed",					CREATURES.SPECIES.SEEDS.COLDBREATHER.NAME				}
			};
			Tag coal = SimHashes.Carbon.CreateTag();
			string descBurn = "Burns {0} to convert them into {1}";

			foreach (KeyValuePair<string, string> seed in seeds)
			{
				ComplexRecipe.RecipeElement[] input = new ComplexRecipe.RecipeElement[]
				{
					new ComplexRecipe.RecipeElement(seed.Key, 1),
					new ComplexRecipe.RecipeElement(coal, 50)
				};

				ComplexRecipe.RecipeElement[] output = new ComplexRecipe.RecipeElement[]
				{	new ComplexRecipe.RecipeElement(coal, 800)  };

				ComplexRecipe recipeSeedToCoal = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("Kiln", input, output), input, output);
				recipeSeedToCoal.time = 35f;
				recipeSeedToCoal.description = string.Format
					(descBurn, seed.Value, ElementLoader.FindElementByHash(SimHashes.Carbon).name);
				recipeSeedToCoal.fabricators = new List<Tag> { TagManager.Create("Kiln") };
				recipeSeedToCoal.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;

				recipesIDs.Add(recipeSeedToCoal.id);
			}
		}

		public void snowCone()
		{
			Tag ice = SimHashes.Ice.CreateTag();
			Tag snow = SimHashes.Snow.CreateTag();

			ComplexRecipe.RecipeElement[] input = new ComplexRecipe.RecipeElement[]
			{	new ComplexRecipe.RecipeElement(ice, 100)	};

			ComplexRecipe.RecipeElement[] output = new ComplexRecipe.RecipeElement[]
			{	new ComplexRecipe.RecipeElement(snow, 100)  };

			ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("RockCrusher", input, output), input, output);
			recipe.time = 10f;
			recipe.description = string.Format
				(BUILDINGS.PREFABS.ROCKCRUSHER.RECIPE_DESCRIPTION, ice.ProperName(), snow.ProperName());
			recipe.fabricators = new List<Tag> { TagManager.Create("RockCrusher") };
			recipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;

			recipesIDs.Add(recipe.id);
		}

		/*
		public void corpseToCoal()
		{
			Tag coal = SimHashes.Carbon.CreateTag();
			string descBurn = "Burns {0} to convert them to {1}"; 

			assignable.AddAutoassignPrecondition(new Func<MinionAssignablesProxy, bool>(CanAutoAssignTo));

			ComplexRecipe.RecipeElement[] input = new ComplexRecipe.RecipeElement[]
			{ 
				new ComplexRecipe.RecipeElement(MinionConfig.ID, 1),
				new ComplexRecipe.RecipeElement(coal, 100)
			};
			
			ComplexRecipe.RecipeElement[] output = new ComplexRecipe.RecipeElement[]
			{	new ComplexRecipe.RecipeElement(coal, 2000)	};

			ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("Kiln", input, output), input, output);
			recipe.time = 35f;
			recipe.description = string.Format
				(descBurn, "Corpses", ElementLoader.FindElementByHash(SimHashes.Carbon).ProperName());
			recipe.fabricators = new List<Tag> {	TagManager.Create("Kiln")	};
			recipe.description = "Burn Corpse";
			recipe.displayInputAndOutput = true;
		}

		private bool CanAutoAssignTo(MinionAssignablesProxy worker)
		{
			bool flag = false;
			MinionIdentity minionIdentity = worker.target as MinionIdentity;
			if (minionIdentity != null)
			{
				if(minionIdentity.GetComponent<Health>().State.Equals("Dead"))
				{	assignable.assignee = worker;	}
			
			}
			return flag;
		}
		*/

}	}