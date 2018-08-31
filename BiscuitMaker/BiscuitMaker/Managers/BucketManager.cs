﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiscuitMaker.Managers
{
    public class BucketManager
    {
        public static void HandleMotorPulse(object sender, OnMotorPulseEventArgs e)
        {
            var conveyor = e.Maker.FirstConveyor;
            var bucket = e.Maker.FirstBucket;
            var last = conveyor.Belt.LastOrDefault();
            if (last != null)
            {
                var biscuit = Biscuit.Create(
                    isExtruded: last.IsExtruded,
                    isStamped: last.IsStamped,
                    isDone: true
                );

                bucket.Biscuits.Add(biscuit);
            }
        }
    }
}
