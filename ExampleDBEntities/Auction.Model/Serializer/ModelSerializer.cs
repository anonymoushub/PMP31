using Newtonsoft.Json;

namespace Auction.Model.Serializer
{
    public class ModelSerializer<T> : IModelSerializer<T> where T : IModel
    {
        public string SerializeObjectAsJson(T t)
        {
            return JsonConvert.SerializeObject(t);
        }
    }
}
