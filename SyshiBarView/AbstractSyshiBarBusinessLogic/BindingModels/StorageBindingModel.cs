using System.Collections.Generic;
namespace AbstractSyshiBarBusinessLogic.BindingModels
{
    public class StorageBindingModel
    {
        public int Id { get; set; }
        public string StorageName { get; set; }
        public List<StorageSeafoodBindingModel> StorageSeafoods { get; set; }
    }
}
