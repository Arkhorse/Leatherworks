﻿using UnityEngine.AddressableAssets;
using UnityEngine;
using Il2Cpp;
using Unity.VisualScripting;
using MelonLoader;

namespace Leatherworks
{
    internal static class LeatherworksUtils
    {
        public static Panel_Inventory inventory;
        public static GameObject treebark = Addressables.LoadAssetAsync<GameObject>("GEAR_Treebark").WaitForCompletion();
        public static GearItem leatherParts = Addressables.LoadAssetAsync<GameObject>("GEAR_LeatherScraped").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem knife1 = Addressables.LoadAssetAsync<GameObject>("GEAR_Knife").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem knife2 = Addressables.LoadAssetAsync<GameObject>("GEAR_KnifeImprovised").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem hammer1 = Addressables.LoadAssetAsync<GameObject>("GEAR_Hammer").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem hammer2 = Addressables.LoadAssetAsync<GameObject>("GEAR_Stone").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem tanFilledBox = Addressables.LoadAssetAsync<GameObject>("GEAR_MetalBoxTanFilled").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem boxTanStart = Addressables.LoadAssetAsync<GameObject>("GEAR_MetalBoxTanning").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem flour = Addressables.LoadAssetAsync<GameObject>("GEAR_Flour").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem barkFriedPile = Addressables.LoadAssetAsync<GameObject>("GEAR_BarkPreparedFriedPile").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem barkPile = Addressables.LoadAssetAsync<GameObject>("GEAR_BarkPreparedPile").WaitForCompletion().GetComponent<GearItem>();
        public static GameObject GetPlayer()
        {
            return GameManager.GetPlayerObject();
        }
        public static bool IsFur(string gearItemName)
        {
            if (Settings.instance.noCured == true)
            {
                string[] fur = { "GEAR_MooseHide", "GEAR_LeatherHide", "GEAR_RabbitPelt", "GEAR_WolfPelt", "GEAR_BearHide", "GEAR_MooseHideCured", "GEAR_LeatherHideCured", "GEAR_RabbitPeltCured", "GEAR_WolfPeltCured", "GEAR_BearHideCured" };
                for (int i = 0; i < fur.Length; i++)
                {
                    if (gearItemName == fur[i]) return true;
                }
                return false;
            }
            else
            {
                string[] fur = { "GEAR_MooseHideCured", "GEAR_LeatherHideCured", "GEAR_RabbitPeltCured", "GEAR_WolfPeltCured", "GEAR_BearHideCured" };
                for (int i = 0; i < fur.Length; i++)
                {
                    if (gearItemName == fur[i]) return true;
                }
                return false;
            }
        }

        public static bool IsFriedBark(string gearItemName)
        {
            string[] friedBark = { "GEAR_BarkPreparedFried", "GEAR_BarkPreparedFriedPile" };
            for (int i = 0; i < friedBark.Length; i++)
            {
                if (gearItemName == friedBark[i]) return true;
            }
            return false;
        }

        public static bool IsFriedBarkPileable(string gearItemName)
        {
            string[] friedBark = { "GEAR_BarkPreparedFried" , "GEAR_BarkPrepared"};
            for (int i = 0; i < friedBark.Length; i++)
            {
                if (gearItemName == friedBark[i]) return true;
            }
            return false;
        }

        public static bool IsTanFilled(string gearItemName)
        {
            string[] tanFilled = { "GEAR_MetalBoxTanFilled" };
            for (int i = 0; i < tanFilled.Length; i++)
            {
                if (gearItemName == tanFilled[i]) return true;
            }
            return false;
        }

        public static bool IsTanEmpty(string gearItemName)
        {
            string[] tanEmpty = { "GEAR_MetalBoxForge" };
            for (int i = 0; i < tanEmpty.Length; i++)
            {
                if (gearItemName == tanEmpty[i]) return true;
            }
            return false;
        }

        public static T? GetComponentSafe<T>(this Component? component) where T : Component
        {
            return component == null ? default : GetComponentSafe<T>(component.GetGameObject());
        }
        public static T? GetComponentSafe<T>(this GameObject? gameObject) where T : Component
        {
            return gameObject == null ? default : gameObject.GetComponent<T>();
        }
        public static T? GetOrCreateComponent<T>(this Component? component) where T : Component
        {
            return component == null ? default : GetOrCreateComponent<T>(component.GetGameObject());
        }
        public static T? GetOrCreateComponent<T>(this GameObject? gameObject) where T : Component
        {
            if (gameObject == null)
            {
                return default;
            }

            T? result = GetComponentSafe<T>(gameObject);

            if (result == null)
            {
                result = gameObject.AddComponent<T>();
            }

            return result;
        }
        internal static GameObject? GetGameObject(this Component? component)
        {
            try
            {
                return component == null ? default : component.gameObject;
            }
            catch (System.Exception exception)
            {
                MelonLoader.MelonLogger.Msg($"Returning null since this could not obtain a Game Object from the component. Stack trace:\n{exception.Message}");
            }
            return null;
        }

    }

}
