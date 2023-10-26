using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExchangeCompanySoftware
{
    interface IToolBar
    {
        Boolean ADD();
        Boolean SAVE();
        Boolean EDIT();
        Boolean QUERY();
        Boolean UNDO();
        Boolean EXIT();
        Boolean DELETE();
        Boolean NEXT();
        Boolean PREVIOUS();
        Boolean LAST();
        Boolean FIRST();
        Boolean AUTHORIZE();
        Boolean PRINT();
    }
}
