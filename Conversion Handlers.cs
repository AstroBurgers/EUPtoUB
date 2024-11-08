using Rage.Native;

namespace EUPtoUB
{
    internal static class ConversionHandlers
    {
        internal static int GetDrawableId(PedComponent component)
        {
            return NativeFunction.Natives.x67F3780DD425D4FC<int>(EntryPoint.MainPlayer, (int)component) + 1; // GET_PED_DRAWABLE_VARIATION
        }

        internal static int GetTextureId(PedComponent component)
        {
            return NativeFunction.Natives.x04A355E041E004E6<int>(EntryPoint.MainPlayer, (int)component) + 1; // GET_PED_TEXTURE_VARIATION
        }

        internal static int GetPropId(PropType prop)
        {
            return NativeFunction.Natives.x898CC20EA75BACD8<int>(EntryPoint.MainPlayer, (int)prop) + 1; // GET_PED_PROP_INDEX
        }

        internal static int GetPropTextureId(PropType prop)
        {
            return NativeFunction.Natives.xE131A28626F81AB2<int>(EntryPoint.MainPlayer, (int)prop) + 1; // GET_PED_PROP_TEXTURE_INDEX
        }
    }
}