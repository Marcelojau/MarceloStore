using System;
using System.Collections.Generic;
using System.Text;

namespace MarceloStore.Shared.Commands
{
    public interface ICommand
    {
        bool Valid();
    }
}
