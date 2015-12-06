namespace Auction.Model.Serializer
{
    interface IModelSerializer <in T> where T : IModel
    {
        string SerializeObjectAsJson(T t);
    }
}
