using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net4Logger
{
    public interface ILogManager
    {
        void Info(string message);

        void Debug(string message);

        void Warn(string message);

        void Error(string message);
    }
}
