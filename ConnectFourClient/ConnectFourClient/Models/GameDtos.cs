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
    public class MoveDecisionRequest
    {
        public int[][] Board { get; set; }
    }

    public class MoveDecisionResponse
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
