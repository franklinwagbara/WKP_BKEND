using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nes_workflow
{
    public interface QuartzSchedulerJob
    {
        string Name
        {
            get;
        }

        void Run();
    }
}