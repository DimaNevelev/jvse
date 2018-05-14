using JFrogVSPlugin.Data;
using Microsoft.VisualStudio.Imaging.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFrogVSPlugin
{
    class JFrogMonikerSelector
    {
        private static readonly Guid JFrogMonikerGuid = new Guid("86a2727e-a627-4c99-a8cc-c5622bc3479c");
        public static ImageMoniker GetSeverityMoniker(Severity severity)
        {
            int id = 0;
            switch (severity)
            {
                case Severity.Critical:
                    {
                        id = 10;
                        break;
                    }
                case Severity.Major:
                    {
                        id = 50;
                        break;
                    }
                case Severity.Minor:
                    {
                        id = 60;
                        break;
                    }
                case Severity.Normal:
                    {
                        id = 70;
                        break;
                    }
                case Severity.Unknown:
                    {
                        id = 90;
                        break;
                    }
            }
            return new ImageMoniker { Guid = JFrogMonikerGuid, Id = id };
        }
    }
}
