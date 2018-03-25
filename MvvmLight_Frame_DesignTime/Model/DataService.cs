using System;

namespace MvvmLight_Frame_DesignTime.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light", "Screen1", "Screen2", "Screen3");
            callback(item, null);
        }
    }
}