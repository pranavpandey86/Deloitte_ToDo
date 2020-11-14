using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksToDo.Commands
{
    public abstract class SingleEntityCommandBase
    {
        public int Id { get; set; }

    }
}
