using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommand<TRequest>
    {
        void Excecute(TRequest request);
    }

    public interface ICommand<TRequest, TResult> {
        TRequest Execute(TRequest request);
    }
}
