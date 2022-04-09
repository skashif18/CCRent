using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appo.Server.Data
{
    public class Validation
    {
        public class Package
        {
            public const int MaxDescriptionLenth = 5000;
            public const int MaxHeadingLenth = 500;

        }
        public class User {
            public const int MaxNameLenth = 72;
            public const int MaxBiographyLenth = 150;
        }
    }
}
