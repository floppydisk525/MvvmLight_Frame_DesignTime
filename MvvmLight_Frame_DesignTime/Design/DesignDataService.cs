using System;
using MvvmLight_Frame_DesignTime.Model;

namespace MvvmLight_Frame_DesignTime.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]", "Screen1 Design", "Screen2 Design", "Screen3 Design");
            callback(item, null);
        }
    }
}