﻿using LivingThing.TCCS.Interface;
using System.Reflection;

namespace LivingThing.TCCS.Lexicon
{
    internal static class Extension
    {
        public static ICodeConstruct TryNavigate(this CodeConstruct from, MethodInfo method, object[] parameters)
        {
            if (method.Name.StartsWith("set_"))
            {
                return new PropertySetter(from.Scope, from, method, parameters);
            }
            else if (method.Name.StartsWith("get_"))
            {
                return new PropertyGetter(from.Scope, from, method, parameters);
            }
            else
            {
                return new Method(from.Scope, from, method, parameters);
            }
            return null;
        }
    }
}
