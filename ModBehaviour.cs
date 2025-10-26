using System;
using System.Collections.Generic;
using System.Linq;

namespace RecycleLuckyNote
{
    public class ModBehaviour : Duckov.Modding.ModBehaviour
	{
		public static bool was_recipes_added = false;
        public static List<CraftingFormula>? craftingFormulas;
		public readonly static CraftingFormula recipe_red_envelope = new CraftingFormula()
		{
			id = "recycle_lucky_note:note_to_red_envelope",
			unlockByDefault = true,
			tags = new string[] { "WorkBenchAdvanced" },
			requirePerk = "",
			hideInIndex = false,
			cost = new Duckov.Economy.Cost((445, 1L)),
			result = new CraftingFormula.ItemEntry()
			{
				id = 444,
				amount = 1
			}
		};
		public readonly static CraftingFormula recipe_cash = new CraftingFormula()
		{
			id = "recycle_lucky_note:note_to_cash",
			unlockByDefault = true,
			tags = new string[] { "WorkBenchAdvanced" },
			requirePerk = "",
			hideInIndex = false,
			cost = new Duckov.Economy.Cost((445, 1L), (938, 1L)),
			result = new CraftingFormula.ItemEntry()
			{
				id = 451,
				amount = 2888
			}
		};
		private void OnEnable()
		{
			SceneLoader.onFinishedLoadingScene += OnSceneLoaded;
		}
		private void OnDisable()
		{
			SceneLoader.onFinishedLoadingScene -= OnSceneLoaded;
			RemoveRecipes();
		}
		public void OnSceneLoaded(SceneLoadingContext _context)
		{
			if (craftingFormulas == null)
			{
				GetListRef();
			}
			if (!was_recipes_added)
			{
				AddRecipes();
			}
		}
		public static void AddRecipes()
        {
			if (craftingFormulas != null)
			{
				craftingFormulas.Add(recipe_red_envelope);
				craftingFormulas.Add(recipe_cash);
				was_recipes_added = true;
				UnityEngine.Debug.Log("RecycleLuckyNote: 已添加配方");
			}
		}
        public static void RemoveRecipes()
        {
			if (craftingFormulas != null)
			{
				craftingFormulas.Remove(recipe_red_envelope);
				craftingFormulas.Remove(recipe_cash);
				was_recipes_added = false;
				UnityEngine.Debug.Log("RecycleLuckyNote: 已移除配方");
			}
		}
        public static void GetListRef()
        {
            craftingFormulas = (List<CraftingFormula>)CraftingFormulaCollection.Instance.Entries.GetType().GetProperty("Items", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(CraftingFormulaCollection.Instance.Entries);
		}
    }
}
