using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker.Managers
{
    public static class BiscuitMakerSettingsValidator
    {
        internal static bool AreValid(BiscuitMakerSettings settings, bool throws = false)
        {
            var errorMessage = "";

            errorMessage += GetErrorMessage(throws, settings == null && string.IsNullOrEmpty(errorMessage), "Settings can not be null");

            throw new NotImplementedException();
        }

        private static string GetErrorMessage(bool throws, bool predicate, string errorMessage)
        {
            if (predicate && throws)
            {
                throw new ArgumentException(errorMessage);
            }

            if (predicate)
            {
                return errorMessage + "; ";
            }

            return "";
        }
    }
}
