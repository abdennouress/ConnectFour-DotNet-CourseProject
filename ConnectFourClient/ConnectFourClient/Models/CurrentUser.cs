// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Client - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourClient.Models
{
    public static class CurrentUser
    {
        public static int Id => Player?.Id ?? -1;
        public static Player Player { get; set; }
        public static int Identifier => Player?.Identifier ?? -1;
    }
}
