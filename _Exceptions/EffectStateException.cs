using System;


namespace InventoryCoreLib
{
    public class EffectStateException : InvalidOperationException
    {
        public const string MSG = "Cannot change effect state while effect is applied";

        public EffectStateException(string? effectName): base($"{effectName} :: {MSG}")
        { 
        }

    }
}
