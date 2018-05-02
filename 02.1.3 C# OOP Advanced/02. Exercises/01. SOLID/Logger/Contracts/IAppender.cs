using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(IError error);

        ErrorLevel Level { get; }
    }
}
