﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass02_Opt1_Ass01
{
    public class Worker : Bee
    {
        public override void Damge(int value)
        {
            base.Damge(value);
            if (Health < 70)
            {
                Console.WriteLine("Worker: Dead");
            }
        }
    }
}