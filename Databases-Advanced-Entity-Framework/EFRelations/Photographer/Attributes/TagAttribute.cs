using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photographer.Attributes
{
    public class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object tag)
        {
            string tagValue = (string) tag;
            if (!tagValue.StartsWith("#"))
            {
                return false;
            }
            if (tagValue.Contains(" ") || tagValue.Contains("\t"))
            {
                return false;
            }
            if (tagValue.Contains("\t"))
            {
                return false;
            }
            if (tagValue.Length > 20)
            {
                return false;
            }
            return true;
        }
    }
}
